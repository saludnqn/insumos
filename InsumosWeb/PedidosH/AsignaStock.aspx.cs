using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using DalInsumos;
using System.Data;
using ExtensionMethods;
using Salud.Security.SSO;


public partial class PedidosH_AsignaStock : System.Web.UI.Page
{
    public bool tieneStock { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //CargarEstado();
        btnGuardar.Visible = false;
        lblMensaje.Text = "";
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarPedido(id);
        }
    }

    private void CargarPedido(int id)
    {
        //traigo el pedido
        InsPedido p = new InsPedido(id);
        lblPedidoNro.Text = p.IdPedido.ToString();
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFechaPedido.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblFecha.Text = p.ModifiedOn.ToString();
        lblDepositoDestino.Text = p.InsDeposito.Nombre;
        if (p.IdRubro != 0) lblRubro.Text = p.InsRubro.Nombre;
        else lblRubro.Text = "--";
        lblDepositoOrigen.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblResponsable.Text = p.Responsable;
        lblObservaciones.Text = p.Observaciones;
        //detalle del pedido     
        gvPedidos.DataSource = p.InsPedidoDetalleRecords;
        gvPedidos.DataBind();
    }

    protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPedido p = new InsPedido(id);

        int efector = p.IdEfectorProveedor.Value;
        int dep = p.IdDepositoProveedor.Value;
        //bindeo la segunda grilla
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblIdInsumo = (Label)e.Row.FindControl("lblIdInsumo");
            hfIdInsumo.Value = lblIdInsumo.Text;

            GridView gv = (GridView)e.Row.FindControl("gvInsumosStock");
            //solo los insumo con stock
            DataTable di = DalInsumos.SPs.InsGetInsumosDisponiblesStock(efector, dep, Convert.ToInt32(hfIdInsumo.Value)).GetDataSet().Tables[0];
            gv.DataSource = di;
            gv.DataBind();
            tieneStock |= di.Rows.Count > 0;
        }
        btnGuardar.Visible = tieneStock; 
    }

    //private void CargarEstado()
    //{
    //    SubSonic.Select es = new Select();
    //    es.From(InsEstadoPedido.Schema);
    //    es.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(0);
    //    ddlEstados.DataSource = es.ExecuteTypedList<InsEstadoPedido>();
    //    ddlEstados.DataBind();
    //}

    protected void generarEgreso(int id)
    {
        string username = SSOHelper.CurrentIdentity.Username;        
        //int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPedido p = new InsPedido(id);
        p.IdPedido = 0;
        p.IdEstadoPedido = 5;//ESTADO: FINALIZADO
        p.IdTipoPedido = 15; //Provisión Interna (Egreso)
        //p.Estado = true;
        p.Save(username);

    }

    
  /*  protected void txtCantidad_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gvInsumosStock.Rows)
        {
            int presentacion = Convert.ToInt32(((label)gvr.FindControl("lblPresentacion")).Text);
            ((TextBox)gvr.FindControl("txtCantidad")).Text = (Convert.ToInt32(((TextBox)gvr.FindControl("txtCantidad")).Text) * Convert.ToInt32(((TextBox)gvr.FindControl("txtPresentacion")).Text)).ToString();
        }
    }*/

    private bool DatosValidos(int id)
    {
        //validar la cantidad asignada, segun la presentacion del insumo
        foreach (GridViewRow gvr in gvPedidos.Rows)
        {
            Label lblidPedidoDetalle = (Label)gvr.FindControl("lblidPedidoDetalle");
            Label lblCantAutorizada = (Label)gvr.FindControl("lblCantAutorizada");
            int idPD = Convert.ToInt32(lblidPedidoDetalle.Text);
            int cantAsignada = 0;
                        
            GridView gvInsumosStock = (GridView)gvr.FindControl("gvInsumosStock");
            if (gvInsumosStock != null)  //Acá pregunto si hay lotes en la grilla
            {
                foreach (GridViewRow gvris in gvInsumosStock.Rows)
                {
                    //InsPedidoDetalle pdMio = new InsPedidoDetalle(id);

                    TextBox txtCantidad = (TextBox)gvris.FindControl("txtCantidad");
                    if (txtCantidad.Text != "" && txtCantidad.Text != "0")
                    {
                        Label txtStock = (Label)gvris.FindControl("lblStock");
                        if (int.Parse(txtStock.Text) < int.Parse(txtCantidad.Text))
                            return (false);
                        cantAsignada += int.Parse(txtCantidad.Text);
                    }
                }
            }

            if (int.Parse(lblCantAutorizada.Text) < cantAsignada)
                return (false);
        }

        return true;
    }

    //protected void btnCerrar_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Default.aspx", false);
    //}

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (DatosValidos(id))
        {
            InsPedido p = new InsPedido(id);
            p.IdEstadoPedido = 8;//ESTADO: PREPARADO ... Harcodeo? Naaaaa
            p.Responsable = lblResponsable.Text;
            p.Observaciones = lblObservaciones.Text;
            p.Save(username);

            //Genero un Egreso de tipo Provisión Interna
            InsPedido eg = new InsPedido();
            eg.IdEfector = p.IdEfector;
            eg.IdEfectorProveedor = p.IdEfectorProveedor;
            eg.IdProveedor = p.IdProveedor;
            eg.IdRubro = p.IdRubro;
            eg.IdTipoPedido = 15;
            eg.IdEstadoPedido = 8;
            eg.IdDeposito = p.IdDepositoProveedor;  //El Proveedor en este caso es el que entrega
            eg.IdDepositoProveedor = p.IdDeposito;

            eg.Fecha = p.Fecha;
            eg.FechaRecepcion = p.Fecha;
            eg.Observaciones = p.Observaciones;
            eg.NumeroComprobante = p.NumeroComprobante;
            eg.OrdenCompra = p.OrdenCompra;
            eg.IdTipoComprobante = p.IdTipoComprobante;
            eg.Estado = p.Estado;
            eg.Autorizado = p.Autorizado;
            eg.Responsable = p.Responsable;
            eg.Save(username);

            InsMovimiento movE = new InsMovimiento();
            movE.IdEfector = eg.IdEfector;
            movE.IdEfectorProveedor = eg.IdEfectorProveedor;
            movE.IdProveedor = eg.IdProveedor;
            movE.IdRubro = eg.IdRubro;
            movE.IdEstadoPedido = eg.IdEstadoPedido;
            movE.Observaciones = eg.Observaciones;
            movE.NumeroComprobante = eg.NumeroComprobante;
            movE.OrdenCompra = eg.OrdenCompra;
            movE.IdTipoComprobante = eg.IdTipoComprobante;
            movE.IdTipoPedido = eg.IdTipoPedido;
            movE.Fecha = eg.Fecha;
            movE.FechaRecepcion = eg.FechaRecepcion;
            movE.Estado = eg.Estado;
            movE.Autorizado = eg.Autorizado;
            movE.IdDeposito = eg.IdDeposito;
            movE.IdDepositoProveedor = eg.IdDepositoProveedor;
            movE.Responsable = eg.Responsable;
            movE.Save(username);


            InsMovimiento mov = new InsMovimiento();
            mov.IdPedido = id;
            mov.IdEfector = p.IdEfector;
            mov.IdEfectorProveedor = p.IdEfectorProveedor;
            mov.IdProveedor = p.IdProveedor;
            mov.IdRubro = p.IdRubro;
            mov.IdEstadoPedido = p.IdEstadoPedido;
            mov.Observaciones = p.Observaciones;
            mov.NumeroComprobante = p.NumeroComprobante;
            mov.OrdenCompra = p.OrdenCompra;
            mov.IdTipoComprobante = p.IdTipoComprobante;
            mov.IdTipoPedido = p.IdTipoPedido;
            mov.Fecha = p.Fecha;
            mov.FechaRecepcion = p.FechaRecepcion;

            mov.Estado = p.Estado;
            mov.Autorizado = p.Autorizado;
            mov.IdDeposito = p.IdDeposito;
            mov.IdDepositoProveedor = p.IdDepositoProveedor;
            mov.Responsable = p.Responsable;
            mov.Save(username);

            //Ahora actualizo los lotes 
            foreach (GridViewRow gvr in gvPedidos.Rows)
            {
                Label lblidPedidoDetalle = (Label)gvr.FindControl("lblidPedidoDetalle");
                int idPD = Convert.ToInt32(lblidPedidoDetalle.Text);

                InsPedidoDetalle pdExterno = new InsPedidoDetalle(idPD);
                InsPedidoDetalle pdEgreso = new InsPedidoDetalle();

                GridView gvInsumosStock = (GridView)gvr.FindControl("gvInsumosStock");
                if (gvInsumosStock != null)  //Acá pregunto si hay lotes en la grilla
                {
                    InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
                    InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

                    foreach (GridViewRow gvris in gvInsumosStock.Rows)
                    {
                        TextBox txtCantidad = (TextBox)gvris.FindControl("txtCantidad");
                        if (txtCantidad.Text != "" || txtCantidad.Text != "0")
                        {
                            HiddenField hfIdPedidoDetalle = (HiddenField)gvris.FindControl("hfIdPedidoDetalle");  //Acá tomo el idPedidoDetalle del lote seleccionado a descontar stock

                            InsPedidoDetalle pdMio = new InsPedidoDetalle(hfIdPedidoDetalle.Value);
                            int CantidadEmitida = txtCantidad.Text.TryParseInt();
                            pdMio.Stock -= CantidadEmitida;           //Acá descuento el stock

                            pdExterno.CantidadEmitida += CantidadEmitida;  //Acá lo incremento
                            pdExterno.Presentacion = pdMio.Presentacion;
                            pdExterno.PrecioUnitario = pdMio.PrecioUnitario;
                            pdExterno.NumeroLote = pdMio.NumeroLote;
                            pdExterno.FechaVencimiento = pdMio.FechaVencimiento;
                            pdExterno.RenglonOC = pdMio.RenglonOC;

                            pdEgreso.IdPedido = eg.IdPedido;
                            pdEgreso.IdInsumo = pdExterno.IdInsumo;
                            pdEgreso.FechaPedido = pdExterno.FechaPedido;
                            pdEgreso.Cantidad = pdExterno.Cantidad;
                            pdEgreso.Presentacion = pdExterno.Presentacion;
                            pdEgreso.CantidadSolicitada = pdExterno.CantidadSolicitada;
                            pdEgreso.CantidadAutorizada = pdExterno.CantidadAutorizada;
                            pdEgreso.CantidadEmitida = pdExterno.CantidadEmitida;
                            pdEgreso.CantidadRecibida = pdExterno.CantidadEmitida;
                            pdEgreso.PrecioUnitario = pdExterno.PrecioUnitario;
                            pdEgreso.Stock = pdExterno.Stock;
                            pdEgreso.Observacion = pdExterno.Observacion;
                            pdEgreso.Renglon = pdExterno.Renglon;
                            pdEgreso.RenglonOC = pdExterno.RenglonOC;
                            pdEgreso.NumeroLote = pdExterno.NumeroLote;
                            pdEgreso.FechaVencimiento = pdExterno.FechaVencimiento;
                            pdEgreso.Baja = pdExterno.Baja;

                            pdMio.Save(username); //stock descontado
                            pdExterno.Save(username);
                            pdEgreso.Save(username);

                            pds.Add(pdMio);
                            pds.Add(pdExterno);
                            pds.Add(pdEgreso);

                        }
                    }
                    //debo guardar en la tabla MovimientoDetalles
                    foreach (InsPedidoDetalle item in pds)
                    {
                        InsMovimientoDetalle md = new InsMovimientoDetalle();
                        md.IdMovimiento = mov.IdMovimiento;
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
                        mds.Add(md);
                    }
                    mds.SaveAll(username);
                }
            }
            //habre el form de entregar insumos
            //Response.Redirect("InternosEnvio.aspx?id=" + id);            
        }
        else
        {
            string alertjs = @"<script language='javascript'> alert('Revise las cantidades asignadas. Una de ellas no es válida.'); </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
        }
    }    
}
