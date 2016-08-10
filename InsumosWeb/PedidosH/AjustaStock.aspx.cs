using System;
using SubSonic;
using System.Data;
using System.Web.UI.WebControls;
using DalInsumos;
using ExtensionMethods;
using Salud.Security.SSO;


public partial class PedidosH_AjustaStock : System.Web.UI.Page
{
    private InsPedidoDetalleCollection Detalles
    {
        get
        {
            return ViewState["detalles"] == null ? new InsPedidoDetalleCollection() : (InsPedidoDetalleCollection)ViewState["detalles"];
        }
        set { ViewState["detalles"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        string fullname = SSOHelper.CurrentIdentity.Fullname;

        CargarCombo();
        
        dtpFechaAjuste.Text = DateTime.Now.ToString();
        txtResponsable.Text = fullname;
        txtObservaciones.Text = "";
    }

    private void CargarCombo()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector);
        //d.And(InsDeposito.Columns.Selected);
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoPedido.Schema);
        tp.Where(InsTipoPedido.Columns.IdTipoMovimiento).IsEqualTo(2);
        ddlPedido.DataSource = tp.ExecuteTypedList<InsTipoPedido>();
        ddlPedido.DataBind();

        SubSonic.Select de = new SubSonic.Select();
        de.From(InsProveedor.Schema);
        de.Where(InsProveedor.Columns.Baja).IsEqualTo(0);
        de.And(InsProveedor.Columns.IdTipoProveedor).IsEqualTo(1);
        de.OrderAsc("nombre");
        ddlDestino.DataSource = de.ExecuteTypedList<InsProveedor>();
        ddlDestino.DataBind();

        SubSonic.Select tc = new SubSonic.Select();
        tc.From(InsTipoComprobante.Schema);
        tc.Where(InsTipoComprobante.Columns.Baja).IsNotEqualTo(1);
        ddlTipoComprobante.DataSource = tc.ExecuteTypedList<InsTipoComprobante>();
        ddlTipoComprobante.DataBind();
        ddlTipoComprobante.Items.Insert(0, new ListItem("Seleccionar", "0"));        
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {                
        string username = SSOHelper.CurrentIdentity.Username;
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        //Genero el registro del EGRESO en INS_PEDIDOS
        InsPedido p = new InsPedido();
        p.IdEfector = idEfector;
        p.IdEfectorProveedor = idEfector;
        p.IdDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);
        p.IdDepositoProveedor = Convert.ToInt32(ddlDeposito.SelectedValue);
        p.Fecha = Convert.ToDateTime(dtpFechaAjuste.Text);
        p.FechaRecepcion = p.Fecha;
        p.IdTipoPedido = Convert.ToInt32(ddlPedido.SelectedValue);
        p.IdTipoComprobante = int.Parse(ddlTipoComprobante.SelectedValue);
           //txtNroComprobante.Text;
        p.IdRubro = hfIdRubro.Value.ParseInt();
        p.IdEstadoPedido = 5; //Finalizado: ultimo estado por ajuste
        p.IdProveedor = Convert.ToInt32(ddlDestino.SelectedValue);
        p.Observaciones = txtObservaciones.Text;
        p.Responsable = txtResponsable.Text;
        p.Autorizado = true;
        p.Estado = true;
        p.Baja = false;
        p.Save(username);
        p.NumeroComprobante = p.IdPedido.ToString();
        p.Save(username);

        InsMovimiento m = new InsMovimiento();
        //copiar todos los datos aca ----
        m.IdPedido = p.IdPedido;
        m.IdEfector = p.IdEfector;
        m.IdEfectorProveedor = p.IdEfectorProveedor;
        m.IdDeposito = p.IdDeposito;
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
        m.CreatedOn = p.CreatedOn;
        m.ModifiedBy = p.ModifiedBy;
        m.ModifiedOn = p.ModifiedOn;
        m.Save(username);

        InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
        InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();
        
        foreach (GridViewRow gvr in gvInsumosDeposito.Rows)
        {
            TextBox txtCantidad = (TextBox)gvr.FindControl("txtCantidad");
            int Cantidad = txtCantidad.Text.TryParseInt(0);
            if(Cantidad != 0)
            {
                Label lblIdPedido = (Label)gvr.FindControl("lblIdPedido");
                int idPedido = Convert.ToInt32(lblIdPedido.Text);
                Label lblIdPedidoDetalle = (Label)gvr.FindControl("lblIdPedidoDetalle");
                int idPedidoDetalle = Convert.ToInt32(lblIdPedidoDetalle.Text);

                //creo un objeto pd de clase InsPedidoDetalle - como objeto (temp) para pasar datos
                InsPedidoDetalle pd = new InsPedidoDetalle();
                
                pd.IdPedido = idPedido;
                pd.IdPedidoDetalle = idPedidoDetalle;
                pd.FechaPedido = Convert.ToDateTime(dtpFechaAjuste.Text);
                Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);
                Label lblLote = (Label)gvr.FindControl("lblLote");
                pd.NumeroLote = lblLote.Text;
                Label lblVencimiento = (Label)gvr.FindControl("lblVencimiento");
                pd.FechaVencimiento = Convert.ToDateTime(lblVencimiento.Text);
                Label lblPrecioUnitario = (Label)gvr.FindControl("lblPrecioUnitario");
                pd.PrecioUnitario = Convert.ToDecimal(lblPrecioUnitario.Text);
                Label lblPresentacion = (Label)gvr.FindControl("lblPresentacion");
                pd.Presentacion = Convert.ToInt32(lblPresentacion.Text);
                Label lblStockActual = (Label)gvr.FindControl("lblStockActual");
                int stockActual = lblStockActual.Text.TryParseInt();
                pd.Cantidad = Cantidad;
                int StockReal = stockActual - Cantidad;            
                Label lblObservacion = (Label)gvr.FindControl("lblObservacion");
                pd.Observacion = lblObservacion.Text;
                pd.Stock = StockReal;
                pd.Renglon = gvr.DataItemIndex + 1;
            
                Label lblCR = (Label)gvr.FindControl("lblCantidadRecibida");
                int CR = lblCR.Text.TryParseInt();
                pd.CantidadRecibida = CR;
                Label lblCA = (Label)gvr.FindControl("lblCantidadAutorizada");
                int CA = lblCA.Text.TryParseInt();
                pd.CantidadAutorizada = CA;
                Label lblCE = (Label)gvr.FindControl("lblCantidadEmitida");
                int CE = lblCE.Text.TryParseInt();
                pd.CantidadEmitida = CE;
                pd.Baja = false;
                //pd.Observacion = "Ajuste de Stock. ";  //cambio la observación para el nuevo registro.             

                //*********************************************************************
                //creo otro objeto de clase pedidoDetalle y le asigno valores
                //InsPedido pAjuste = new InsPedido(idPedido);
                InsPedidoDetalle pdAjuste = new InsPedidoDetalle(idPedidoDetalle);
                //pdAjuste.IdPedido = pd.IdPedido; 
                //pdAjuste.FechaPedido = pd.FechaPedido;
                //pdAjuste.IdInsumo = pd.IdInsumo;
                //pdAjuste.NumeroLote = pd.NumeroLote;
                //pdAjuste.FechaVencimiento = pd.FechaVencimiento;
                //pdAjuste.PrecioUnitario = pd.PrecioUnitario;
                //pdAjuste.Presentacion = pd.Presentacion;
                //pdAjuste.Renglon = pd.Renglon;
                //pdAjuste.CantidadAutorizada = pd.CantidadAutorizada;
                //pdAjuste.CantidadEmitida = pd.CantidadEmitida;
                //pdAjuste.CantidadSolicitada = pd.CantidadSolicitada;
                //pdAjuste.CantidadRecibida = pd.CantidadRecibida;
                //pdAjuste.Cantidad = pd.Cantidad;
                pdAjuste.Stock = StockReal;
                pdAjuste.Observacion = lblObservacion.Text;
                //pdAjuste.Baja = false;
                pdAjuste.Save(username); //Alta de ajuste de Stock en INS_PedidoDetalle 

                //creo este objeto de clase pedidoDetalle para el registro nuevo del pedido "Ajuste de Stock"
                InsPedidoDetalle pdStock = new InsPedidoDetalle(idPedidoDetalle);
                //Ahora guardo los mismos datos pero con la modificación del stock 
                //********************************************************************
                pdStock.IdPedido = p.IdPedido;  //id del pedido nuevo
                //pdStock.FechaPedido = pd.FechaPedido;
                //pdStock.IdInsumo = pd.IdInsumo;
                //pdStock.NumeroLote = pd.NumeroLote;
                //pdStock.FechaVencimiento = pd.FechaVencimiento;
                //pdStock.PrecioUnitario = pd.PrecioUnitario;
                //pdStock.Presentacion = pd.Presentacion;
                pdStock.Stock = 0;  //al quedar con stock 0 este registro deja de tener uso
                //pdStock.Renglon = pd.Renglon;
                pdStock.CantidadAutorizada = Cantidad;
                pdStock.CantidadEmitida = Cantidad;
                pdStock.Cantidad = stockActual;
                pdStock.CantidadRecibida = Cantidad;
                pdStock.CantidadSolicitada = Cantidad;
                pdStock.Observacion = "Ajuste de Stock. Valor Anterior: " + stockActual + "; Valor Adicional: " + pdStock.CantidadRecibida;
                //pdStock.Baja = false;
                pdStock.Save(username);

                //*********************************************************************                   
                //
                pds.Add(pd);
            }
            else
            {
                string alertjs = @"<script language='javascript'> alert('La cantidad debe ser mayor a cero.'); </script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);      
            }

        }
        pds.SaveAll(username);

        //Ahora hago lo mismo para los movimientos
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

        Response.Redirect("AjustaStock.aspx", false);
    }


    protected void btnAgregarInsumo_Click(object sender, EventArgs e)
    {
        //panel de todos los insumos recibidos en el deposito
        upInsumosEnDeposito.Visible = true;

        //leo todos los insumos que posee el deposito
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int deposito = Convert.ToInt32(ddlDeposito.SelectedValue);
        int idInsumo = acInsumo.getInsumo();// acInsumoxEfector.getInsumo();
        

        if (deposito != 0)
        {
            DataTable dt = SPs.InsGetInsumosEfectorDeposito(idEfector, deposito, idInsumo).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                gvInsumosDeposito.DataSource = dt;
                gvInsumosDeposito.DataBind();
                btnGuardar.Enabled = true;
            }
            else gvInsumosDeposito.DataBind();

            Select i = new Select(new string[] { "rubro" }).Top("1");
                i.From(InsInsumo.Schema);
                i.Where(InsInsumo.CodigoColumn).IsEqualTo(idInsumo);
                hfIdRubro.Value = i.ExecuteScalar<string>();
        }
        else
        {
            string alertjs = @"<script language='javascript'> alert('Falta seleccionar un Depósito'); </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
        }
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}
