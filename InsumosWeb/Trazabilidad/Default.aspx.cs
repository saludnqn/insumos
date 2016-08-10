using System;
using System.Data;
using DalInsumos;


public partial class Trazabilidad_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvDatos.DataBind();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        int ins = acInsumo.getInsumo();

        DataTable dt = SPs.InsGetTrazabilidadxRubro(finicio, ffin, 0, ins).GetDataSet().Tables[0];
        gvDatos.DataSource = dt;
        gvDatos.DataBind();
    }
}
