using System;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;

public partial class ProvisionesH_DatosInsumo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        int idInsumo = SubSonic.Sugar.Web.QueryString<int>("idInsumo");
        if ((id > 0) && (idInsumo > 0))
        {
            CargarInsumo(id, idInsumo);
        }
    }

    private void CargarInsumo(int id, int idInsumo)
    {
        InsPedido p = new InsPedido(id);
        SubSonic.Select c = new Select().Top("1");
        c.From(InsPedidoDetalle.Schema);
        c.Where(InsPedidoDetalle.Columns.IdInsumo).IsEqualTo(idInsumo);
        c.And(InsPedidoDetalle.PrecioUnitarioColumn).IsGreaterThan(0);
        c.OrderDesc("fechaPedido");

        gvInsumos.DataSource = c.ExecuteTypedList<InsPedidoDetalle>();
        gvInsumos.DataBind();
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        /*   if ((e.Row.Cells[3].Text != "") || (e.Row.Cells[4].Text != ""))
           {
               string cadena = e.Row.Cells[3].Text.ToString() + " x " + e.Row.Cells[4].Text.ToString();
               e.Row.Cells[3].Text = cadena; 
           }         
          */  
        }
    }
}
