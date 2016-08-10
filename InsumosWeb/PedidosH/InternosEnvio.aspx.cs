using System;
using System.Web.UI.WebControls;
using DalInsumos;
using Salud.Security.SSO;


public partial class Pedidos_InternosEnvio : System.Web.UI.Page
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
        //debo traer el pedido para cambiar o no el estado
        InsPedido p = new InsPedido(id);
        //lblEstados.Text = p.InsEstadoPedido.Nombre + ". Pedido Nro: " + p.IdPedido;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblEfectorProveedor.Text = p.InsDeposito.SysEfector.Nombre;
        lblDepositoProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        //ddlEstados.SelectedValue = p.InsEstadoPedido.Nombre;
        //ckbBaja.Checked = p.Baja;
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;
        //cambia de estado: envia pedido al deposito con edicion de cantidades enviadas
        //lblEstados.Text = "";
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            InsPedido p = new InsPedido(id);
            if (!p.IsNew)
            {
                p.IdEstadoPedido = Convert.ToInt32(ddlEstados.SelectedValue);
                p.Observaciones = txtObservaciones.Text;
                //guardo por ddefecto la autorizacion del pedido
                p.Autorizado = true;
                p.Estado = true;
                //if (ckbBaja.Checked == true) p.Baja = true;
                //else 
                p.Baja = false;
                p.Save(username);

                //guardo en Movimiento
                InsMovimiento m = new InsMovimiento();
                m.IdPedido = p.IdPedido;
                m.IdEfector = p.IdEfector;
                m.IdDeposito = p.IdDeposito;
                m.IdEfectorProveedor = p.IdEfectorProveedor;
                m.IdDepositoProveedor = p.IdDepositoProveedor;
                m.Fecha = p.Fecha;
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

                    Label lblCAutorizada = (Label)gvr.FindControl("lblCAutorizada");
                    pd.CantidadAutorizada = Convert.ToInt32(lblCAutorizada.Text);

                    Label lblCEnviada = (Label)gvr.FindControl("lblCEnviada");
                    pd.CantidadEmitida = Convert.ToInt32(lblCEnviada.Text);

                    TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                    pd.Observacion = txtObservacion.Text;

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
                    md.CantidadSolicitada = item.CantidadSolicitada;
                    md.CantidadAutorizada = item.CantidadAutorizada;
                    md.CantidadEmitida = item.CantidadEmitida;
                    md.CantidadRecibida = item.CantidadRecibida;
                    md.PrecioUnitario = item.PrecioUnitario;
                    md.Observacion = item.Observacion;
                    md.Renglon = item.Renglon;
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
                Response.Redirect("View.aspx?id=" + p.IdPedido);
            }
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPedido p = new InsPedido(id);
        int ef = Convert.ToInt32(p.IdEfector);
    }
    //protected void btnCancelar_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("/farmacia/default.aspx");
    //}
}
