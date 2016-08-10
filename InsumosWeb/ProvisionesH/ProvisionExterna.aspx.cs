using System;
using System.Data;
using DalInsumos;
using Salud.Security.SSO;
using System.Configuration;


public partial class ProvisionesH_ProvisionExterna : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        txtFInicio.Text = DateTime.Now.AddDays(-30).ToShortDateString();
        txtFFin.Text = DateTime.Now.ToShortDateString();
        lblMensaje.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select reg = new SubSonic.Select();
        reg.From(InsDepositoZona.Schema);
        reg.Where(InsDepositoZona.IdEfectorColumn).IsEqualTo(idEfector);
        InsDepositoZona dep = reg.ExecuteSingle<InsDepositoZona>();

        if (dep.IdEfectorSistemaIntegrado != 0) 
        {
            DateTime fechaInicio = DateTime.Now.AddDays(-15);
            DateTime ffin = DateTime.Now.AddDays(1);
            DateTime inicio;
            DateTime fin;
            if (DateTime.TryParse(txtFInicio.Text, out inicio))
                fechaInicio = inicio;
            if (DateTime.TryParse(txtFFin.Text, out fin))
                ffin = fin;

            //consulta de datos para la grilla            
            DataTable dt = SPs.InsGetProvisionExterna(fechaInicio, ffin, dep.IdEfectorSistemaIntegrado, dep.IpDepositoZona).GetDataSet().Tables[0];
            gvPedidos.DataSource = dt;
            gvPedidos.DataBind();
        }
        else {
            lblMensaje.Text = "Sistema en Modo Prueba.";
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}
