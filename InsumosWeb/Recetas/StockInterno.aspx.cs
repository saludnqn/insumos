using System;
using DalInsumos;
using Salud.Security.SSO;


public partial class Recetas_StockInterno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idD = SubSonic.Sugar.Web.QueryString<int>("idD");
        if (idD > 0)
        {
            CargarStock(idD);
        }
    }

    private void CargarStock(int idD)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        gvStock.DataSource = SPs.InsGetStockInterno(idD, idEfector).GetDataSet().Tables[0];
        gvStock.DataBind();
    }
}
