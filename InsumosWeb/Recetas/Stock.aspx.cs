using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;
using Salud.Security.SSO;


public partial class Recetas_Stock : System.Web.UI.Page
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
        else
            CargarStock(idD);
    }

    private void CargarInsumo(int idD, int idI)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DataTable ds = SPs.InsGetStockPrescripcion(idD, idI, idEfector).GetDataSet().Tables[0];
        if (ds.Rows.Count > 0)
        {
            gvStock.DataSource = ds;
            gvStock.DataBind();

            //calculo el stock del insumo seleccionado
            int recibido = new Select("CantidadRecibida")
              .From(InsPedido.Schema)
              .InnerJoin(InsPedidoDetalle.Schema)
              .Where(InsPedido.Columns.IdDeposito).IsEqualTo(idD)
              .And(InsPedido.Columns.IdTipoPedido).IsEqualTo(6)
              .And(InsPedidoDetalle.Columns.IdInsumo).IsEqualTo(idI)
              .Execute();

            lblStock.Text = recibido.ToString();

            /*
  int entregado = new Select("CantidadEmitida")
  .From(InsPrescripcion.Schema)
  .InnerJoin(InsPrescripcionDetalle.Schema)
  .Where(InsPrescripcion.IdDepositoColumn).IsEqualTo(idD)
  .And(InsPrescripcionDetalle.IdInsumoColumn).IsEqualTo(idI)
  .Execute();
  //.GetRecordCount();
             
  int stock = recibido - entregado;
  if (stock > 0) lblStock.Text = stock.ToString();
  else lblStock.Text = "Insumo Sin Stock"; 
*/
        }
        else
        {
            lblTotal.Text = "";
            gvStock.DataBind();
        }
    }


    private void CargarStock(int idD)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DataTable ds = SPs.InsGetStockPrescripcion(idD, 0, idEfector).GetDataSet().Tables[0];
        gvStock.DataSource = ds;
        gvStock.DataBind();
        lblTotal.Text = ds.Rows.Count.ToString();
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