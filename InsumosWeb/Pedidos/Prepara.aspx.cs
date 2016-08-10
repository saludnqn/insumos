using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;

public partial class Pedidos_Prepara : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        // id del IdPedido
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarPedido(id);
        }
    }

    private void CargarPedido(int id)
    {
        //debo traer el pedido para cambiar o no el estado
        InsPedido p = new InsPedido(id);
        lblEstados.Text = "Se ha generado el pedido Nro: " + p.IdPedido;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFechaPedido.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblFecha.Text = p.ModifiedOn.ToString();
        lblEfector.Text = p.InsDeposito.SysEfector.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        //ddlEstados.SelectedValue = p.InsEstadoPedido.Nombre;
        lblEstados.Text = p.InsEstadoPedido.Nombre;
        //ckbBaja.Checked = p.Baja;
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        //deberia ir a Asignar el stock
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        lblEstados.Text = "";
        //Response.Redirect("Envia.aspx?id=" + id);
        Response.Redirect("AsignaStock.aspx?id=" + id);
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedidoDetalle pd = (InsPedidoDetalle)e.Row.DataItem;
            //solicitada = autorizada
            Label lblCAutorizada = (Label)e.Row.FindControl("lblCAutorizada");
            pd.CantidadAutorizada = Convert.ToInt32(lblCAutorizada.Text);

            Label lblCEmitida = (Label)e.Row.FindControl("lblCEmitida");
            pd.CantidadEmitida = Convert.ToInt32(lblCEmitida.Text);

            int deuda = pd.CantidadAutorizada - pd.CantidadEmitida;
            Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            lblDeuda.Text = deuda.ToString();

            //debo actualizar el stock en el pedidodetalle
          /*  Label lblIdPedidoDetalle = (Label)e.Row.FindControl("lblIdPedidoDetalle");
            pd.IdPedidoDetalle = Convert.ToInt32(lblIdPedidoDetalle.Text);
            pd.Stock = pd.Stock - pd.CantidadEmitida;
            pd.Save();
           */
        }
    }

}
