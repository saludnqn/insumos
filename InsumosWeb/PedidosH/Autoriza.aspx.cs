using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;
using ExtensionMethods;
using Salud.Security.SSO;


public partial class Pedidos_Autoriza : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //CargarEstado();
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarPedido(id);
        }
    }

    //private void CargarEstado()
    //{
    //    SubSonic.Select es = new Select();
    //    es.From(InsEstadoPedido.Schema);
    //    es.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(1);  
    //    ddlEstados.DataSource = es.ExecuteTypedList<InsEstadoPedido>();
    //    ddlEstados.DataBind();
    //}

    private void CargarPedido(int id)
    {
        //debo traer el pedido para cambiar o no el estado
        InsPedido p = new InsPedido(id);
        lblEstados.Text = "Pedido Nro: " + p.IdPedido;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
       // lblEfectorProveedor.Text = p.InsDeposito.SysEfector.Nombre;
        lblDepositoProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        txtResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        //ddlEstados.SelectedValue = p.InsEstadoPedido.Nombre;
        ckbBaja.Checked = p.Baja;
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //hacer que la columna  cantidadSolicitada = cantidadAutorizada
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedidoDetalle pd = (InsPedidoDetalle)e.Row.DataItem;
            Label lblIdInsumo = (Label)e.Row.FindControl("lblIdInsumo");

            Label lblCantidadSolicitada = (Label)e.Row.FindControl("lblCantidadSolicitada");
            //pd.CantidadSolicitada = Convert.ToInt32(lblCantidadSolicitada.Text);

            TextBox txtCAutorizada = (TextBox)e.Row.FindControl("txtCAutorizada");
            txtCAutorizada.Text = lblCantidadSolicitada.Text;
        }
    }

    protected void btnAutorizar_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;

        //cambia de estado a Autorizado
        lblEstados.Text = "";
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            InsPedido p = new InsPedido(id);
            if ((!p.IsNew) && (Page.IsValid))
            {
                p.IdEstadoPedido = 6;     //Estado Pendiente Preparación.
                p.Responsable = txtResponsable.Text;
                p.Observaciones = txtObservaciones.Text;
                //guardo por ddefecto la autorizacion del pedido
                p.Autorizado = true;
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
                m.IdTipoComprobante = p.IdTipoComprobante;
                m.NumeroComprobante = p.NumeroComprobante;
                m.OrdenCompra = p.OrdenCompra;
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

                    TextBox txtCAutorizada = (TextBox)gvr.FindControl("txtCAutorizada");
                    pd.CantidadAutorizada = Convert.ToInt32(txtCAutorizada.Text);
                    //pd.CantidadEmitida = Convert.ToInt32(txtCAutorizada.Text);

                    TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                    pd.Observacion = txtObservacion.Text;

                    pd.Baja = false;

                    pd.Cantidad = 0;
                    pd.Presentacion = 0;
                    pd.Stock = 0;
                    pd.RenglonOC = 0;

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
                    md.PrecioUnitario = item.PrecioUnitario;
                    md.Stock = item.Stock;
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
                //Response.Redirect("Envia.aspx?id=" + p.IdPedido);
                Response.Redirect("List.aspx", false);
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

    protected void VerificaCantidad(object sender, EventArgs e)
    {
        //control de las cantidades y actualizacion del combo de estados
        bool AutorizadaTotal = true;
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow && AutorizadaTotal)
            {
                //TextBox txtCantidadSolicitada = (TextBox)gvr.FindControl("txtCantidadSolicitada");
                Label lblCantidadSolicitada = (Label)gvr.FindControl("lblCantidadSolicitada");
                TextBox txtCAutorizada = (TextBox)gvr.FindControl("txtCAutorizada");
                int solicitada = lblCantidadSolicitada.Text.TryParseInt();
                int autorizada = txtCAutorizada.Text.TryParseInt();

                if (autorizada > solicitada) 
                {
                    AutorizadaTotal = false;
                }
                if (autorizada <= solicitada)
                {
                    //Autorizada2 = false;
                    return;
                }
            }
        }
        //ddlEstados.SelectedValue = AutorizadaTotal ? "3" : "2";
    }
}
