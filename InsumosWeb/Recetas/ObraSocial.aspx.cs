using System;
using System.Data;
using System.Net;

public partial class Recetas_ObraSocial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idDoc = SubSonic.Sugar.Web.QueryString<int>("idDoc");
        if (idDoc > 0)
        {
            CargarOS(idDoc);
        }
    }

    private void CargarOS(int Doc)
    {
        //cheuqeo la osocial registrada en SIPS
        /*  DataTable dtp = DalPadron.SPs.ListarObraSocial(idDoc).GetDataSet().Tables[0];
          if (dtp.Rows.Count > 0)
          {
              gvOSocial.DataSource = dtp;
              gvOSocial.DataBind();
          }
          else
          {
              lblMensaje.Text = "Paciente sin Obra Social.";
          } */

        if (Doc > 0)
        {
            WebRequest request = WebRequest.Create("http://10.1.232.8/wspadron/padron.asmx/Consultar?dni=" + Doc);
        }
        else
        {
            lblMensaje.Text = "Paciente sin Obra Social.";
        }
    }
}
