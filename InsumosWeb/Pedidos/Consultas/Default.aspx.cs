using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using SubSonic;

public partial class Pedidos_Consultas_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        txtFechaI.Text = "01/01/2012";
        txtFechaF.Text = DateTime.Now.AddDays(1).ToShortDateString();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFechaI.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFechaF.Text, out fin))
            ffin = fin;

        SubSonic.Select c = new Select();
        c.From(InsPedido.Schema);
        //c.InnerJoin(InsPedidoDetalle.Schema);
        c.Where(InsPedido.Columns.Autorizado).IsEqualTo(1);
        c.And(InsPedido.Columns.Estado).IsEqualTo(1);
        //c.And(InsPedidoDetalle.CantidadRecibidaColumn).IsGreaterThanOrEqualTo(0);
        c.And(InsPedido.FechaColumn).IsBetweenAnd(finicio, fin);
        c.OrderAsc("idPedido");

        gvPedidos.DataSource = c.ExecuteAsCollection<InsPedidoCollection>();
        gvPedidos.DataBind();
    }

    protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEfector = (Label)e.Row.FindControl("lblEfector");
            Label lblEfectorProveedor = (Label)e.Row.FindControl("lblEfectorProveedor");

            if (lblEfector.Text != lblEfectorProveedor.Text)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#eef1d1");
            }
        }
    }
}
