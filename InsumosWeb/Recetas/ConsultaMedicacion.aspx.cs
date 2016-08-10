using System;
using System.Data;
using DalInsumos;

public partial class Recetas_ConsultaMedicacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
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
        int med = acInsumos.getInsumo();

        DataTable pc = SPs.InsGetMedicamentos(med, finicio, ffin).GetDataSet().Tables[0];

        if (pc.Rows.Count > 0)
        {
        //    upRecetas.Visible = true;
            gvRecetas.DataSource = pc;
            gvRecetas.DataBind();
        }
        else
        {
        //    upRecetas.Visible = false;
            gvRecetas.DataBind();
        }
    }
}
