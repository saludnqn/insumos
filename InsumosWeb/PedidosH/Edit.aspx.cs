using System;
using System.Linq;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;
using Salud.Security.SSO;


public partial class PedidosH_Edit : System.Web.UI.Page
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
        txtFecha.Text = DateTime.Now.ToShortDateString();
        txtResponsable.Text = fullname;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarPedido(id);
        }
    }

    private void CargarPedido(int id)
    {
        //datos del encabezado del Pedido
        InsPedido p = new InsPedido(id);
        if (!p.IsNew)
        {
            UpdatePanel2.Visible = true;
            ddlPedido.SelectedValue = p.IdTipoPedido.ToString();
            ddlDeposito.SelectedValue = p.IdDeposito.ToString();
            txtFecha.Text = p.Fecha.ToString();
            //acRubro1.setRubro(p.IdRubro.Value);
            ddlRubro.SelectedValue = p.IdRubro.ToString();
            ddlEfectorProveedor.SelectedValue = p.IdEfectorProveedor.ToString();
            ddlDepositoProveedor.SelectedValue = p.IdDepositoProveedor.ToString();
            ddlEfectorProveedor_SelectedIndexChanged(null, null);
            ddlRubro_SelectedIndexChanged(null, null);
            //estado del pedido = Generado
            txtObservaciones.Text = p.Observaciones;
            txtResponsable.Text = p.Responsable;
            //autorizado por = idUsuario
            p.Baja = false;
            //pedidodetalle    
            SubSonic.Select pd = new Select();
            pd.From(Schemas.InsPedidoDetalle);
            pd.Where(InsPedidoDetalle.Columns.IdPedido).IsEqualTo(id);

            gvInsumos.DataSource = pd.ExecuteTypedList<InsPedidoDetalle>();
            gvInsumos.DataBind();
        }
    }

    private void CargarCombo()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //deposito del usuario
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select e = new SubSonic.Select();
        e.From(SysEfector.Schema);
        //e.Where(SysEfector.Columns.Complejidad).IsGreaterThan(Convert.ToInt32("2"));
        //e.Or(SysEfector.Columns.IdEfectorSuperior).IsEqualTo(227);
        e.Where(SysEfector.Columns.IdEfector).IsEqualTo(idEfector);
        e.OrderAsc("Nombre");
        ddlEfectorProveedor.DataSource = e.ExecuteTypedList<SysEfector>();
        ddlEfectorProveedor.DataBind();
        ddlEfectorProveedor.Items.Insert(0, new ListItem("Seleccionar", "0"));

        //deposito del efector a quien se pide
        SubSonic.Select dp = new SubSonic.Select();
        dp.From(InsDeposito.Schema);
        dp.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        dp.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector);
        ddlDepositoProveedor.DataSource = dp.ExecuteTypedList<InsDeposito>();
        ddlDepositoProveedor.DataBind();
        ddlDepositoProveedor.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoPedido.Schema);
        tp.Where(InsTipoPedido.IdTipoPedidoColumn).IsNotEqualTo(2);
        ddlPedido.DataSource = tp.ExecuteTypedList<InsTipoPedido>();
        ddlPedido.DataBind();

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Codigo).IsEqualTo(362);
        //r.Where(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        //r.And(InsRubro.Columns.Baja).IsEqualTo(0);
        r.OrderAsc("nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        //ddlRubro.Items.Insert(0, new ListItem("Seleccionar Rubro", "0"));
    }

    protected void lbActualizar_Click(object sender, EventArgs e)
    {
        //UpdatePanel1.Visible = true;

        int idE = SSOHelper.CurrentIdentity.IdEfector;
        int idI = acInsumoxRubro.getInsumo();
        if ((idE > 0) && (idI > 0))
        {
            Response.Redirect("Stock.aspx?idE=" + idE + "&idI=" + idI);
        }
        else
        {
            return;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (true) //&& (Page.IsValid))// Page.Validate("1");
        {
            InsPedido p = new InsPedido(id);
            p.IdEfector = idEfector;
            p.IdEfectorProveedor = idEfector; //Convert.ToInt32(ddlEfectorProveedor.SelectedValue);
            p.IdDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);
            p.IdDepositoProveedor = Convert.ToInt32(ddlDepositoProveedor.SelectedValue);
            p.Fecha = Convert.ToDateTime(txtFecha.Text);
            p.IdTipoPedido = Convert.ToInt32(ddlPedido.SelectedValue);
            //p.IdRubro = acRubro1.getRubro();
            p.IdRubro = Convert.ToInt32(ddlRubro.SelectedValue);
            p.IdTipoComprobante = 0;
            p.NumeroComprobante = p.IdPedido.ToString();
            p.OrdenCompra = "";
            p.IdEstadoPedido = 1; //GENERADO
            p.IdProveedor = 286; //SERVICIO INTERNO
            p.Observaciones = txtObservaciones.Text;
            p.Responsable = txtResponsable.Text; //deberia traer el nombre del usuario            
            p.Estado = false;
            p.Baja = false;

            if (CbPedidoConfirmado.Checked)
            {
                p.Autorizado = true;
                p.IdEstadoPedido = 6;  //Pendiente
            }
            else
                p.Autorizado = false;

            p.Save(username);

            InsMovimiento m = new InsMovimiento();
            //copiar todos los datos aca
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
            p.CreatedOn = p.CreatedOn;
            m.ModifiedBy = p.ModifiedBy;
            m.ModifiedOn = p.ModifiedOn;
            m.Save(username);

            InsPedidoDetalle.Delete("idPedido", id);
            InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
            InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

            foreach (GridViewRow gvr in gvInsumos.Rows)
            {
                //detalle del pedido
                Label lblIdPedidoDetalle = (Label)gvr.FindControl("lblIdPedidoDetalle");
                int idPD = Convert.ToInt32(lblIdPedidoDetalle.Text);

                InsPedidoDetalle pd = new InsPedidoDetalle();
                pd.IdPedido = p.IdPedido;

                pd.FechaPedido = Convert.ToDateTime(txtFecha.Text);
                //pd.IdRubro = pd.InsInsumo.IdRubro;

                Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                TextBox txtCantidad = (TextBox)gvr.FindControl("txtCantidad");
                pd.CantidadSolicitada = Convert.ToInt32(txtCantidad.Text);

                TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                pd.Observacion = txtObservacion.Text;

                pd.Renglon = gvr.DataItemIndex + 1;
                /**/
                pd.CantidadAutorizada = pd.CantidadSolicitada;
                pd.CantidadEmitida = 0;
                pd.CantidadRecibida = 0;
                pd.PrecioUnitario = 0;
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

            string pedido = p.IdPedido.ToString();
            string url = "View.aspx?id=" + pedido;
            
            Response.Redirect(url);

            //string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=700,height=400,scrollbars=yes,top=80, left=80');</script>";
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
                                               
        }
    }

    //private bool DatosValidos(int id)
    //{
    //    SubSonic.Select ped = new SubSonic.Select();
    //    ped.From(InsPedido.Schema);
    //    ped.Where(InsPedido.Columns.IdPedido).IsNotEqualTo(id);
    //    ped.And(InsPedido.Columns.IdTipoPedido).IsNotEqualTo(1);
    //    DataTable dtd = ped.ExecuteDataSet().Tables[0];
    //    if (dtd.Rows.Count == 0)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    protected void ddlRubro_SelectedIndexChanged(object sender, EventArgs e)
    {
        //acInsumoxRubro.IdRubro = ddlRubro.SelectedValue.TryParseInt();
        Session["idRubro"] = ddlRubro.SelectedValue;
    }

    protected void btnAgregarInsumo_Click(object sender, EventArgs e)
    {
        UpdatePanel2.Visible = true;        
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            //detalle del pedido
            InsPedidoDetalle pd = new InsPedidoDetalle();
            pd.IdPedido = id;
            pd.FechaPedido = Convert.ToDateTime(txtFecha.Text);
            //pd.IdRubro = pd.InsInsumo.IdRubro;

            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
            pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

            TextBox txtCantidad = (TextBox)gvr.FindControl("txtCantidad");
            pd.CantidadSolicitada = Convert.ToInt32(txtCantidad.Text);

            TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
            pd.Observacion = txtObservacion.Text;

            pd.Renglon = gvr.DataItemIndex + 1;
            /**/
            pd.CantidadAutorizada = pd.CantidadSolicitada;
            pd.CantidadEmitida = 0;
            pd.CantidadRecibida = 0;
            pd.PrecioUnitario = 0;
            pd.Baja = false;

            pds.Add(pd);
        }
        int idNuevoInsumo = acInsumoxRubro.getInsumo(); //acInsumoxEfector.getInsumo(); // Convert.ToInt32(ddlInsumo.SelectedValue);
        InsPedidoDetalle ipd = pds.FirstOrDefault(x => x.IdInsumo == idNuevoInsumo);
        if (ipd == null)
        {
            // agrego el nuevo insumo
            InsPedidoDetalle pd1 = new InsPedidoDetalle();
            pd1.IdPedido = id;
            pd1.FechaPedido = Convert.ToDateTime(txtFecha.Text);
            pd1.IdInsumo = acInsumoxRubro.getInsumo(); // acInsumoxEfector.getInsumo(); //Convert.ToInt32(ddlInsumo.SelectedValue);
            pd1.CantidadSolicitada = 1;
            pd1.Observacion = "";
            pd1.Renglon = 0;
            /**/
            pd1.CantidadAutorizada = 0;
            pd1.CantidadEmitida = 0;
            pd1.CantidadRecibida = 0;
            pd1.PrecioUnitario = 0;
            pd1.Observacion = txtObservaciones.Text;
            pd1.Baja = false;

            pds.Add(pd1);
        }
        else return;

        Detalles = pds;
        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    protected void ibBorrar_Command(object sender, CommandEventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
        int idInsumoBorrar = Convert.ToInt32(e.CommandArgument);

        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            // busco el registro a eliminar o saltear
            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
            int idIns = Convert.ToInt32(lblIdInsumo.Text);
            if (idIns != idInsumoBorrar)
            {
                //detalle del pedido
                InsPedidoDetalle pd = new InsPedidoDetalle();
                pd.IdPedido = id;
                pd.FechaPedido = Convert.ToDateTime(txtFecha.Text);
                pd.IdInsumo = idIns;

                TextBox txtCantidad = (TextBox)gvr.FindControl("txtCantidad");
                pd.CantidadSolicitada = Convert.ToInt32(txtCantidad.Text);

                TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                pd.Observacion = txtObservacion.Text;

                pd.Renglon = gvr.DataItemIndex + 1;
                /**/
                pd.CantidadAutorizada = pd.CantidadSolicitada;
                pd.CantidadEmitida = 0;
                pd.CantidadRecibida = 0;
                pd.PrecioUnitario = 0;
                pd.Baja = false;

                pds.Add(pd);
            }
        }

        Detalles = pds;
        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    protected void ddlEfectorProveedor_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ef = Convert.ToInt32(ddlEfectorProveedor.SelectedValue);

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(ef);
        ddlDepositoProveedor.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoProveedor.DataBind();
        //acInsumoxEfector.IdEfector = ef;
        //Session["idRubro"] = acRubro1.getRubro();
        Session["idRubro"] = Convert.ToInt32(ddlRubro.SelectedValue);
    }

    void acInsumoxRubro_Seleccion(object sender, Select ca)
    {
        // Y aqui dentro de la pagina hago lo que quiero...
        //LoadInsumos();
        //acInsumoxEfector.IdEfector = ef;
        Session["idRubro"] = acInsumoxRubro.getInsumo();
        //Session["idRubro"] = Convert.ToInt32(ddlRubro.SelectedValue);
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx", false);
    }

}
