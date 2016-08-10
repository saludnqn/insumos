using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class Recetas_StockInsumo : System.Web.UI.Page
{
    int totalentregados = 0;
    int totaladeudados = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idD = SubSonic.Sugar.Web.QueryString<int>("idD");
        int idI = SubSonic.Sugar.Web.QueryString<int>("idI");
        if ((idD > 0) && (idI > 0))
        {
            CargarInsumo(idD, idI);
        }
    }

    private void CargarInsumo(int idD, int idI)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        //INS_GetStockMedicamentos 5, 16
        DataTable ds = SPs.InsGetStockPrescripcion(idD, idI, idEfector).GetDataSet().Tables[0];
        //DataTable ds = SPs.InsGetStockMedicamentos(idD, idI).GetDataSet().Tables[0];
        if (ds.Rows.Count > 0)
        {
            gvStock.DataSource = ds;
            gvStock.DataBind();
        }
        else
        {
            lblTotal.Text = "";
        }
        gvStock.DataBind();
    }

    protected void gvStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSolicitado = (Label)e.Row.FindControl("lblSolicitado");
            int sol = Convert.ToInt32(lblSolicitado.Text);

            Label lblEntregado = (Label)e.Row.FindControl("lblEntregado");
            int env = Convert.ToInt32(lblEntregado.Text);

            int deuda = sol - env;
            Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            lblDeuda.Text = deuda.ToString();

            totalentregados += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cantidadEmitida"));
            totaladeudados += deuda;
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            totaladeudados = 0;
            totalentregados = 0;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = "Entregados: " + totalentregados.ToString();
            e.Row.Cells[5].Text = "Adeudados: " + totaladeudados.ToString();
        }
    }

    protected void gvStock_DataBound(object sender, EventArgs e)
    {
        lblTotal.Text = "Total Entregados: " + totalentregados.ToString();
        totalentregados = 0;
    }
}
