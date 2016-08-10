using System;
using System.Web.UI.WebControls;
using WSCronicos;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using DalInsumos;
using Salud.Security.SSO;


public partial class Recetas_ConsultarCronicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        string dni = SubSonic.Sugar.Web.QueryString<string>("Documento");
        int doc = SubSonic.Sugar.Web.QueryString<int>("Documento");
        if (dni != "")
        {
            CargarCronicos(dni);
            //Consulto en la DB el nombre del Paciente
            SysPaciente oPaciente = new SubSonic.Select("Nombre", "Apellido") //SubSonic.Select("NroDosis")
            .From(SysPaciente.Schema)
            .Where(SysPaciente.NumeroDocumentoColumn).IsEqualTo(doc)
            .ExecuteSingle<SysPaciente>();

            lblPaciente.Text = oPaciente.Apellido + ", " + oPaciente.Nombre + " - DU: " + dni;
        }
        else
        {
            lblPaciente.Text = "No se encuentra al Paciente buscado.";
            gvCronicos.DataBind();
        }
    }

    public bool CheckValidationResult(ServicePoint sp, X509Certificate cert, WebRequest req, int problem)
    {
        return true;
    }

    private void CargarCronicos(string dni)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        if (Request["Documento"] != null)
        {
            if (idEfector == 205)
            {
                //llamo al wscronico por la consulta
                //consumiendo el WS Hcastro
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                CredentialCache cache = new CredentialCache();

                WSCronicos.WebService we = new WSCronicos.WebService();
                WSCronico[] bc = we.BuscarCronicos(dni);

                //di.DefaultView.Sort = "Pac DESC";
                gvCronicos.DataSource = bc;
                gvCronicos.DataBind();
                //Dni Ejemplo: 17140572, 92457625, 7291574
                //14470726, 23058775, 4698386, 92685133
            }
            else { 
            //buscar los ultimos diagnosticos que se realizo el paciente
            }
        }
    }

    public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }


    protected void gvCronicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCronicos.PageIndex = e.NewPageIndex;
    }
}
