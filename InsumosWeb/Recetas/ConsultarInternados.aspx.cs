using System;
using System.Web.UI.WebControls;
using WSInternados;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using DalInsumos;

public partial class Recetas_ConsultarInternados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        string dni = SubSonic.Sugar.Web.QueryString<string>("Documento");
        int doc = SubSonic.Sugar.Web.QueryString<int>("Documento");
        if (dni != "")
        {
            CargarMapaCama(dni);
            //Consulto en la DB el nombre del Paciente
            SysPaciente oPaciente = new SubSonic.Select("Nombre", "Apellido")
            .From(SysPaciente.Schema)
            .Where(SysPaciente.NumeroDocumentoColumn).IsEqualTo(doc)
            .ExecuteSingle<SysPaciente>();

            lblPaciente.Text = oPaciente.Apellido + ", " + oPaciente.Nombre + " - DU: " + dni;
        }
        else
        {
            lblPaciente.Text = "El Paciente no se encuentra internado.";
            gvInternados.DataBind();
        }
    }

    public bool CheckValidationResult(ServicePoint sp, X509Certificate cert, WebRequest req, int problem)
    {
        return true;
    }

    private void CargarMapaCama(string dni)
    {
        if (Request["Documento"] != null)
        {
            //consumiendo el WS Hcastro
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
            CredentialCache cache = new CredentialCache();

            WebServices we = new WebServices();
            WSInternacion[] bc = we.BuscarInternados(dni);

            //di.DefaultView.Sort = "Pac DESC";
            gvInternados.DataSource = bc;
            gvInternados.DataBind();
            //PISO no lo tengo, pero las habitaciones que tiene número, el primer dígito es el piso.
            //SECTOR que tengo es el campo habitación.
        }
    }

    public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }


    protected void gvInternados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInternados.PageIndex = e.NewPageIndex;
    }

    protected void gvInternados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //adquirir el numero de piso, sacar el primer digito del nro de cada
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCama = (Label)e.Row.FindControl("lblCama");
            Label lblPiso = (Label)e.Row.FindControl("lblPiso");
            if (lblCama.Text != "")
            {
                string cama = lblCama.Text.Substring(5, 1); //tomo 1 letra, despues del 5to lugar
                lblPiso.Text = cama;
            }
            else
            {
                lblPiso.Text = "";
            }
        }
    }
}
