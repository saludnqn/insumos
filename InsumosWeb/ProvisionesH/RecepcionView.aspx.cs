using System;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;
using Salud.Security.SSO;


public partial class ProvisionesH_RecepcionView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //CargarEstado();
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarRecepcion(id);
        }
    }

    //private void CargarEstado()
    //{
    //    SubSonic.Select es = new Select();
    //    es.From(InsEstadoPedido.Schema);
    //    es.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(0);
    //    es.Or(InsEstadoPedido.NombreColumn).IsEqualTo("Finalizado");
    //    ddlEstados.DataSource = es.ExecuteTypedList<InsEstadoPedido>();
    //    ddlEstados.DataBind();
    //}

    private void CargarRecepcion(int id)
    {
        InsPedido p = new InsPedido(id);
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblPedido.Text = p.IdPedido.ToString();
        lblFechaPedido.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblFechaEnvio.Text = Convert.ToDateTime(p.ModifiedOn).ToString();
        lblTipoPedido.Text = p.InsTipoPedido.Nombre; //debe pasar a ser suministro
        lblEstadoPedido.Text = p.InsEstadoPedido.Nombre;
        lblResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        //ddlEstados.SelectedValue = p.IdEstadoPedido.ToString();
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //cantidadSolicitada = cantidadAutorizada
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedidoDetalle pd = (InsPedidoDetalle)e.Row.DataItem;
            Label lblIdInsumo = (Label)e.Row.FindControl("lblIdInsumo");

            Label lblCantidadEmitida = (Label)e.Row.FindControl("lblCantidadEmitida");

            TextBox txtCRecibida = (TextBox)e.Row.FindControl("txtCRecibida");
            txtCRecibida.Text = lblCantidadEmitida.Text;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPedido p = new InsPedido(id);
        if (!p.IsNew)
        {
            p.IdEstadoPedido = 5; //FINALIZADO
            p.IdTipoPedido = 1;   // pasa de ser un pedido(1) a un ingreso(6)
            p.FechaRecepcion = DateTime.Now;
            p.IdTipoComprobante = 7; //remito
            p.NumeroComprobante = p.IdPedido.ToString();
            p.OrdenCompra = "";
            //p.IdProveedor = 
            //p.Estado = true;
            p.Responsable = lblResponsable.Text;
            p.Observaciones = txtObservaciones.Text;
            p.Save(username);  

            //guardo en Movimiento
            InsMovimiento m = new InsMovimiento();
            m.IdPedido = p.IdPedido;
            m.IdEfector = p.IdEfector;
            m.IdDeposito = p.IdDeposito;
            m.IdEfectorProveedor = p.IdEfectorProveedor;
            m.IdDepositoProveedor = p.IdDepositoProveedor;
            m.Fecha = p.Fecha;
            m.FechaRecepcion = p.FechaRecepcion;
            m.IdTipoPedido = p.IdTipoPedido;
            m.IdTipoComprobante = p.IdTipoComprobante;
            m.NumeroComprobante = p.NumeroComprobante;
            m.OrdenCompra = p.OrdenCompra;
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


            ///********* Ahora los datos del detalle del pedido************************
            //
            InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
            InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

            foreach (GridViewRow gvr in gvInsumos.Rows)
            {
                Label lblId = (Label)gvr.FindControl("lblidPedidoDetalle");
                string idPedidoDetalle = lblId.Text;

                InsPedidoDetalle pd = new InsPedidoDetalle(idPedidoDetalle);
                pd.IdPedido = p.IdPedido;

                Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                Label lblLote = (Label)gvr.FindControl("lblLote");
                pd.NumeroLote = lblLote.Text;

                Label lblVencimiento = (Label)gvr.FindControl("lblVencimiento");
                pd.FechaVencimiento = Convert.ToDateTime(lblVencimiento.Text);

                TextBox txtCRecibida = (TextBox)gvr.FindControl("txtCRecibida");
                pd.CantidadRecibida = Convert.ToInt32(txtCRecibida.Text);
                pd.Stock = pd.CantidadRecibida;

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
                md.Cantidad = item.Cantidad;
                md.Presentacion = item.Presentacion;
                md.CantidadSolicitada = item.CantidadSolicitada;
                md.CantidadAutorizada = item.CantidadAutorizada;
                md.CantidadEmitida = item.CantidadEmitida;
                md.CantidadRecibida = item.CantidadRecibida;
                md.Stock = item.CantidadRecibida;
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
            Response.Redirect("View.aspx?id=" + id);
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}
