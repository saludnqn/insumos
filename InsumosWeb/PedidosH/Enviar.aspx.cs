using System;
using System.Web.UI.WebControls;
using DalInsumos;
using Salud.Security.SSO;


public partial class PedidosH_Enviar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarPedido(id);
        }
    }

    private void CargarPedido(int id)
    {
        InsPedido p = new InsPedido(id);
        lblEstados.Text = "Se ha generado el pedido Nro: " + p.IdPedido;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblEfectorProveedor.Text = p.InsDeposito.SysEfector.Nombre;
        lblDepositoProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        txtResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        lblEstados.Text = "Estado del Pedido: " + p.InsEstadoPedido.Nombre;
        ckbBaja.Checked = p.Baja;
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;
        //cambia de estado a Autorizado
        lblEstados.Text = "";
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            InsPedido p = new InsPedido(id);
            if (!p.IsNew)
            {
                p.Responsable = txtResponsable.Text;
                p.Observaciones = txtObservaciones.Text;
                //guardo el estado para envio
                p.Estado = true;
                if (ckbBaja.Checked == true) p.Baja = true;
                else p.Baja = false;
                p.Save(username);

                //guardo en Movimiento
                InsMovimiento m = new InsMovimiento();
                m.IdPedido = p.IdPedido;
                m.IdEfector = p.IdEfector;
                m.IdDeposito = p.IdDeposito;
                m.IdEfectorProveedor = p.IdEfectorProveedor;
                m.IdDepositoProveedor = p.IdDepositoProveedor;
                m.Fecha = p.Fecha;
                m.IdTipoComprobante = p.IdTipoComprobante;
                m.NumeroComprobante = p.NumeroComprobante;
                m.OrdenCompra = p.OrdenCompra;
                m.IdTipoPedido = p.IdTipoPedido;
                m.IdRubro = p.IdRubro;
                m.IdEstadoPedido = p.IdEstadoPedido;
                m.IdProveedor = p.IdProveedor;
                m.Observaciones = p.Observaciones;
                m.Responsable = p.Responsable;
                m.Autorizado = p.Autorizado;
                m.Estado = p.Estado;
                m.Baja = p.Baja;
                m.CreatedBy = p.CreatedBy;
                p.CreatedOn = p.CreatedOn;
                m.ModifiedBy = p.ModifiedBy;
                m.ModifiedOn = p.ModifiedOn;
                m.Save(username);

                //guardar los datos de la grilla o detalle del pedido
                InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
                InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

                foreach (GridViewRow gvr in gvInsumos.Rows)
                {
                    Label lblId = (Label)gvr.FindControl("lblidPedidoDetalle");
                    string idPD = lblId.Text;

                    InsPedidoDetalle pd = new InsPedidoDetalle(idPD);
                    pd.IdPedido = p.IdPedido;
                    pd.FechaPedido = Convert.ToDateTime(lblFecha.Text);

                    Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                    pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                    pd.Baja = false;
                    pds.Add(pd);
                }
                pds.SaveAll(username);
                //guardo en movimientosdetalle
                foreach (InsPedidoDetalle item in pds)
                {
                    InsMovimientoDetalle md = new InsMovimientoDetalle();
                    md.IdMovimiento = m.IdMovimiento;

                    md.IdPedido = item.IdPedido;
                    md.IdPedidoDetalle = item.IdPedidoDetalle;
                    md.IdInsumo = item.IdInsumo;
                    md.FechaPedido = item.FechaPedido;
                    md.Cantidad = item.Cantidad;
                    md.Presentacion = item.Presentacion;
                    md.CantidadSolicitada = item.CantidadSolicitada;
                    md.CantidadAutorizada = item.CantidadAutorizada;
                    md.CantidadEmitida = item.CantidadEmitida;
                    md.CantidadRecibida = item.CantidadRecibida;
                    md.Stock = item.Stock;
                    md.PrecioUnitario = item.PrecioUnitario;
                    md.Observacion = item.Observacion;
                    md.Renglon = item.Renglon;
                    md.RenglonOC = item.RenglonOC;
                    md.NumeroLote = item.NumeroLote;
                    md.FechaVencimiento = item.FechaVencimiento;
                    md.Baja = item.Baja;
                    md.CreatedBy = item.CreatedBy;
                    md.CreatedOn = item.CreatedOn;
                    md.ModifiedBy = item.ModifiedBy;
                    md.ModifiedOn = item.ModifiedOn;
                    mds.Add(md);
                }
                mds.SaveAll(username);
                //NO se envia mas pedido a la base deposito
                Response.Redirect("GeneradoView.aspx?id=" + p.IdPedido);
            }
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        lblEstados.Text = "";
        InsPedido p = new InsPedido(id);
        int ef = Convert.ToInt32(p.IdEfector);
        Response.Redirect("Edit1.aspx?idE=" + ef);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}
