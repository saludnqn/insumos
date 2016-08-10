using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;

public partial class Pedidos_StockSuperior : System.Web.UI.Page
{
    int total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idE = SubSonic.Sugar.Web.QueryString<int>("idE");
        int idI = SubSonic.Sugar.Web.QueryString<int>("idI");
        if ((idE > 0) && (idI > 0))
        {
            CargarDatos(idE, idI);
        }
    }

    private void CargarDatos(int idE, int idI)
    {
        //Hacer la consutla que trae estos datos
        DataTable ds = SPs.InsGetStockxEfector(idE,0, 0, idI).GetDataSet().Tables[0];
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
        //debo calcular la suma por pedido
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cantidadRecibida"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = total.ToString();
        }
    }

    protected void gvStock_DataBound(object sender, EventArgs e)
    {
        lblTotal.Text = "Total Existente: " + total.ToString();
        total = 0;
    }
}
