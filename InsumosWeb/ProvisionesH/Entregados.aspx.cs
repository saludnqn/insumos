using System;
using DalInsumos;
using System.Data;


public partial class ProvisionesH_Entregados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarStock(id);
        }
    }

    private void CargarStock(int id)
    {
        DataTable dt = SPs.InsGetStockInsumo(id).GetDataSet().Tables[0];
        gvEntregados.DataSource = dt;
        gvEntregados.DataBind();
    }
}
