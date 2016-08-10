using System;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class Alarmas_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        txtFinicio.Text = "01/01/2012";
        txtFfin.Text = DateTime.Now.AddMonths(6).ToShortDateString();
        gvInsumos.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        lblMensaje.Text = "";
        DateTime? finicio = null;
        DateTime? ffin = null;
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFinicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFfin.Text, out fin))
            ffin = fin;

        DataSet dt = SPs.InsGetVencimiento(idEfector, finicio, fin).GetDataSet();

        gvInsumos.DataSource = dt; ;
        gvInsumos.DataBind();
    }
}
