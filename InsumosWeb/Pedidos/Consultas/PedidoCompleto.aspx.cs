using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;

public partial class Pedidos_PedidoCompleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarPedidoCompleto(id);
        }
    }

    private void CargarPedidoCompleto(int id)
    {
        //debo traer el pedido para cambiar o no el estado
        InsPedido p = new InsPedido(id);
        lblEstados.Text = "<b>" + p.InsEstadoPedido.Nombre + "</b>";
        lblPedido.Text = "<b>" + p.IdPedido.ToString() + "</b>";
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        if (p.IdEfector == p.IdEfectorProveedor)
        {
            lblEfector.Text = "Efector Actual: " + p.SysEfector.Nombre + "<br>Depósito Originante: " + p.InsDeposito.Nombre;
            lblEfectorProveedor.Text = "Depósito Proveedor: " + p.InsDepositoToIdDepositoProveedor.Nombre;
        }
        else {
            lblEfector.Text = "Efector Originante: " + p.SysEfector.Nombre;
            lblEfectorProveedor.Text = "Efector Proveedor: " + p.SysEfectorToIdEfectorProveedor.Nombre;
        }
        lblRubro.Text = p.InsRubro.Nombre;
        lblResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        if (p.Autorizado == Convert.ToBoolean(1))
            lblAutorizado.Text = "Pedido Autorizado";
        else lblAutorizado.Text = "Pedido NO Autorizado";
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedidoDetalle pd = (InsPedidoDetalle)e.Row.DataItem;

            Label lblCAutorizada = (Label)e.Row.FindControl("lblCAutorizada");
            pd.CantidadAutorizada = Convert.ToInt32(lblCAutorizada.Text);

            Label lblCEnviada = (Label)e.Row.FindControl("lblCEnviada");
            pd.CantidadEmitida = Convert.ToInt32(lblCEnviada.Text);

            int deuda = pd.CantidadEmitida - pd.CantidadRecibida;
            Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            if (deuda > 0)
            {
                lblDeuda.ForeColor = System.Drawing.Color.Red;
                lblDeuda.Text = deuda.ToString();
            }
            else lblDeuda.Text = deuda.ToString();
        }
    }
}
