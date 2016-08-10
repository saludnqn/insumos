using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using DalInsumos;
using System.Data;
using SubSonic;
using ExtensionMethods;

public partial class Provisiones_Edit : System.Web.UI.Page
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
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            lblMensaje.Text = "";
            cargarCombos();
            txtFecha.Text = DateTime.Now.ToShortDateString();
            hlNuevoDeposito.NavigateUrl = "~/Depositos/Edit.aspx";
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            if (id > 0)
            {
                CargarProvision(id);
            }
            acInsumoxEfector.IdEfector = us.IdEfector; //aca el efector del usuario
            txtResponsable.Text = us.Apellido + ", "+ us.Nombre;
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarProvision(int id)
    {
        InsPedido p = new InsPedido(id);
        if (!p.IsNew)
        {
            ddlEfector.SelectedValue = p.IdEfector.ToString();
            ddlEfector_SelectedIndexChanged(null, null);
            ddlDeposito.SelectedValue = p.IdDeposito.ToString();
            txtFecha.Text = Convert.ToDateTime(p.FechaRecepcion).ToShortDateString();
            ddlProveedor.SelectedValue = p.IdProveedor.ToString();
            ddlTipoComprobante.SelectedValue = p.IdTipoComprobante.ToString();
            txtNroComprobante.Text = p.NumeroComprobante;
            txtOCompra.Text = p.OrdenCompra;
            if (p.Estado == true) ddlEstado.SelectedValue = "true";
            else ddlEstado.SelectedValue = "false";
            txtResponsable.Text = p.Responsable;
            txtObservaciones.Text = p.Observaciones;

            // cargar grilla con detallePedido o Insumos
            SubSonic.Select pds = new Select();
            pds.From(Schemas.InsPedidoDetalle);
            pds.Where(InsPedidoDetalle.Columns.IdPedido).IsEqualTo(id);

            gvInsumos.DataSource = pds.ExecuteTypedList<InsPedidoDetalle>();
            gvInsumos.DataBind();
        }
    }

    private void cargarCombos()
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);

        SubSonic.Select e = new SubSonic.Select();
        e.From(SysEfector.Schema);
        //e.Where(SysEfector.Columns.Complejidad).IsGreaterThan(2);
        e.Where(SysEfector.IdEfectorColumn).IsEqualTo(us.IdEfector);
        ddlEfector.DataSource = e.ExecuteTypedList<SysEfector>();
        ddlEfector.DataBind();
        //ddlEfector.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(Convert.ToInt32(ddlEfector.SelectedValue));
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select tc = new SubSonic.Select();
        tc.From(InsTipoComprobante.Schema);
        tc.Where(InsTipoComprobante.BajaColumn).IsEqualTo(0);
        tc.Or(InsTipoComprobante.IdTipoComprobanteColumn).IsEqualTo(8);
        ddlTipoComprobante.DataSource = tc.ExecuteTypedList<InsTipoComprobante>();
        ddlTipoComprobante.DataBind();
        ddlTipoComprobante.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(0);
        //r.And(InsRubro.Columns.Baja).IsEqualTo(0);
        r.OrderAsc("nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("Seleccionar", "0"));

        //traigo el proveedor del efector
        SubSonic.Select p = new SubSonic.Select();
        p.From(InsProveedor.Schema);
        //p.Where(InsProveedor.Columns.Baja).IsEqualTo(0);
        p.Where(InsProveedor.IdEfectorColumn).IsEqualTo(us.IdEfector);
        p.OrderAsc("nombre");
        ddlProveedor.DataSource = p.ExecuteTypedList<InsProveedor>();
        ddlProveedor.DataBind();
        ddlProveedor.Items.Insert(0, new ListItem("Seleccionar", "-1"));
    }

    protected void btnAgregarInsumo_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            //detalle de la provision/pedido
            InsPedidoDetalle pd = new InsPedidoDetalle();
            pd.IdPedido = id;
            pd.FechaPedido = Convert.ToDateTime(txtFecha.Text); //fecha de la provision

            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
            pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

            TextBox txtCantidad = (TextBox)gvr.FindControl("txtCantidad");
            pd.Cantidad = Convert.ToInt32(txtCantidad.Text);

            TextBox txtPresentacion = (TextBox)gvr.FindControl("txtPresentacion");
            pd.Presentacion = Convert.ToInt32(txtPresentacion.Text);

            //para la cantidad total calcularla y editarla?
            Label lblCantidadR = (Label)gvr.FindControl("lblCantidadR");
            pd.CantidadRecibida = Convert.ToInt32(lblCantidadR.Text);

            TextBox txtRenglon = (TextBox)gvr.FindControl("txtRenglon");
            pd.RenglonOC = Convert.ToInt32(txtRenglon.Text);

            TextBox txtPrecio = (TextBox)gvr.FindControl("txtPrecio");
            pd.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);

            TextBox txtLote = (TextBox)gvr.FindControl("txtLote");
            pd.NumeroLote = txtLote.Text;

            TextBox txtFVto = (TextBox)gvr.FindControl("txtFVto");
            if (txtFVto.Text != "")
                pd.FechaVencimiento = Convert.ToDateTime(txtFVto.Text);
            else pd.FechaVencimiento = Convert.ToDateTime("01/01/1900");

            TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
            pd.Observacion = txtObservacion.Text;

            pd.Renglon = gvr.DataItemIndex + 1;
            /**/
            pd.CantidadAutorizada = 0;
            pd.CantidadEmitida = 0;
            pd.CantidadRecibida = 0;
            pd.Baja = false;

            pds.Add(pd);
        }

        int idNuevoInsumo = acInsumoxEfector.getInsumo(); //Convert.ToInt32(ddlInsumo.SelectedValue);
        InsPedidoDetalle ipd = pds.FirstOrDefault(x => x.IdInsumo == idNuevoInsumo);
        if (ipd == null)
        {
            // agrego el nuevo insumo
            InsPedidoDetalle pd1 = new InsPedidoDetalle();
            pd1.IdPedido = id;
            pd1.FechaPedido = Convert.ToDateTime(txtFecha.Text);
            pd1.IdInsumo = acInsumoxEfector.getInsumo(); //Convert.ToInt32(ddlInsumo.SelectedValue);
            pd1.Cantidad = 0;
            pd1.Presentacion = 0;
            pd1.RenglonOC = 0;
            pd1.CantidadSolicitada = 0;
            pd1.NumeroLote = "";
            pd1.FechaVencimiento = Convert.ToDateTime("01/01/1900");
            pd1.Observacion = "";
            pd1.Renglon = 0;

            pd1.CantidadAutorizada = 0;
            pd1.CantidadEmitida = 0;
            pd1.CantidadRecibida = 0;
            pd1.PrecioUnitario = 0;
            //  pd1.Observacion = txtObservaciones.Text;
            pd1.Baja = false;
            pds.Add(pd1);
        }
        else
        {
            lblMensaje.Text = "El Item ya fue ingresado.";
        }

        Detalles = pds;
        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            // Page.Validate("1");
            if ((true) && (Page.IsValid))
            {
                InsPedido p = new InsPedido(id);
                p.IdEfector = Convert.ToInt32(ddlEfector.SelectedValue);
                p.IdDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);
                //p.Fecha = Convert.ToDateTime(txtFecha.Text);
                p.FechaRecepcion = Convert.ToDateTime(txtFecha.Text);
                p.IdTipoPedido = 6; //tipo: Provision
                p.IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
                p.IdEfectorProveedor = p.IdEfector;
                p.IdDepositoProveedor = 0;
                p.IdTipoComprobante = Convert.ToInt32(ddlTipoComprobante.SelectedValue);
                p.IdEstadoPedido = 5; //Finalizado
                p.IdRubro = Convert.ToInt32(ddlRubro.SelectedValue);// 0; Relacion debil con el rubro
                p.NumeroComprobante = txtNroComprobante.Text;
                p.OrdenCompra = txtOCompra.Text;
                p.Observaciones = txtObservaciones.Text;
                p.Responsable = txtResponsable.Text; //deberia traer el nombre del usuario
                p.Autorizado = true; //
                p.Estado = Convert.ToBoolean(ddlEstado.SelectedValue); //true;  xq son provisiones o ingreso de insumos
                p.Baja = false;
                p.Save(us.Username);

                //guardo en Movimiento
                InsMovimiento m = new InsMovimiento();
                m.IdPedido = p.IdPedido;
                m.IdEfector = p.IdEfector;
                m.IdEfectorProveedor = p.IdEfectorProveedor;
                m.IdDeposito = p.IdDeposito;
                m.IdDepositoProveedor = p.IdDepositoProveedor;
                m.Fecha = p.Fecha;
                m.FechaRecepcion = p.FechaRecepcion;
                m.IdTipoPedido = p.IdTipoPedido;
                m.IdRubro = p.IdRubro;
                m.IdEstadoPedido = p.IdEstadoPedido;
                m.IdProveedor = p.IdProveedor;
                m.IdTipoComprobante = p.IdTipoComprobante;
                m.NumeroComprobante = p.NumeroComprobante;
                m.OrdenCompra = p.OrdenCompra;
                m.Observaciones = p.Observaciones;
                m.Responsable = p.Responsable;
                m.Autorizado = p.Autorizado;
                m.Estado = p.Estado;
                m.Baja = p.Baja;
                m.CreatedBy = p.CreatedBy;
                p.CreatedOn = p.CreatedOn;
                m.ModifiedBy = p.ModifiedBy;
                m.ModifiedOn = p.ModifiedOn;
                m.Save(us.Username);

                InsPedidoDetalle.Delete("idPedido", id);
                InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
                InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

                foreach (GridViewRow gvr in gvInsumos.Rows)
                {
                    //detalle del pedido
                    InsPedidoDetalle pd = new InsPedidoDetalle();
                    pd.IdPedido = p.IdPedido;
                    pd.FechaPedido = Convert.ToDateTime(txtFecha.Text);

                    Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                    pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                    TextBox txtCantidad = (TextBox)gvr.FindControl("txtCantidad");
                    pd.Cantidad = Convert.ToInt32(txtCantidad.Text);

                    TextBox txtPresentacion = (TextBox)gvr.FindControl("txtPresentacion");
                    pd.Presentacion = Convert.ToInt32(txtPresentacion.Text);

                    //para la cantidad total calcularla y editarla?
                    Label lblCantidadR = (Label)gvr.FindControl("lblCantidadR");
                    pd.CantidadRecibida = Convert.ToInt32(lblCantidadR.Text);

                    TextBox txtRenglon = (TextBox)gvr.FindControl("txtRenglon");
                    pd.RenglonOC = Convert.ToInt32(txtRenglon.Text);

                    pd.Stock = pd.CantidadRecibida;

                    TextBox txtPrecio = (TextBox)gvr.FindControl("txtPrecio");
                    CultureInfo ci = null;
                    ci = CultureInfo.InvariantCulture;
                    if (!string.IsNullOrEmpty(txtPrecio.Text)) pd.PrecioUnitario = decimal.Parse(txtPrecio.Text.Replace(",", "."), ci);
                    else txtPrecio.Text = "0";

                    TextBox txtLote = (TextBox)gvr.FindControl("txtLote");
                    pd.NumeroLote = txtLote.Text;

                    TextBox txtFVto = (TextBox)gvr.FindControl("txtFVto");
                    pd.FechaVencimiento = Convert.ToDateTime(txtFVto.Text);

                    TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                    pd.Observacion = txtObservacion.Text;

                    pd.Renglon = gvr.DataItemIndex + 1;
                    /*estos datos no se llenan*/
                    pd.CantidadSolicitada = 0;
                    pd.CantidadAutorizada = 0;
                    pd.CantidadEmitida = 0;
                    pd.Baja = false;

                    pds.Add(pd);
                }
                pds.SaveAll(us.Username);
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
                    md.RenglonOC = item.RenglonOC;
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
                mds.SaveAll(us.Username);

                Response.Redirect("View.aspx?id=" + p.IdPedido.ToString());
            }
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private bool DatosValidos(int id)
    {
        SubSonic.Select ped = new SubSonic.Select();
        ped.From(InsPedido.Schema);
        ped.InnerJoin(InsPedidoDetalle.Schema);
        ped.Where(InsPedido.Columns.IdPedido).IsNotEqualTo(id);
        ped.And(InsPedido.Columns.IdTipoPedido).IsNotEqualTo(6);
        DataTable dtd = ped.ExecuteDataSet().Tables[0];
        if (dtd.Rows.Count == 0)
        {
            return true;
        }
        return false;
    }

    protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);

        SubSonic.Select p = new SubSonic.Select();
        p.From(InsProveedor.Schema);
        //p.Where(InsProveedor.Columns.Baja).IsEqualTo(0);
        p.Where(InsProveedor.IdEfectorColumn).IsEqualTo(us.IdEfector); 
        p.OrderAsc("nombre");
        ddlProveedor.DataSource = p.ExecuteTypedList<InsProveedor>();
        ddlProveedor.DataBind();
        ddlProveedor.Items.Insert(0, new ListItem("Seleccionar", "-1"));

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(Convert.ToInt32(ddlEfector.SelectedValue));
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();

        //SubSonic.Select i = new SubSonic.Select();
        //i.From(InsInsumo.Schema);
        //i.InnerJoin(InsRelInsumoEfector.Schema);
        //i.Where(InsRelInsumoEfector.IdEfectorColumn).IsEqualTo(ddlEfector.SelectedValue);
        //i.And(InsInsumo.Columns.Baja).IsEqualTo(0);
        //i.OrderAsc("Nombre");
        //ddlInsumo.DataSource = i.ExecuteTypedList<InsInsumo>();
        //ddlInsumo.DataBind();
        //ddlInsumo.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        //se ingresaran los insumo pero no estaran disponibles para mostrar ni distribuir
        lblActivo.Text = "";
        if (ddlEstado.SelectedValue == "0")
        {
            lblActivo.Text = "El Estado seleccionado no permitirá la visualización ni distribución de la presente provisión.";
        }
    }


    /*protected void ddlRubro_SelectedIndexChanged(object sender, EventArgs e)
    {
        int efector = Convert.ToInt32(ddlEfector.SelectedValue); //efector del usuario
        int codigo = ddlRubro.SelectedValue.TryParseInt();

        ddlInsumo.DataSource = SPs.InsGetInsumosEfectorxRubro(efector, codigo).GetDataSet();
        ddlInsumo.DataBind();
    }*/

    protected void ibBorrar_Command(object sender, CommandEventArgs e)
    {
        lblMensaje.Text = "";
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
                pd.FechaPedido = Convert.ToDateTime(txtFecha.Text); //fecha de la provision

                Label lblIdInsumo2 = (Label)gvr.FindControl("lblIdInsumo");
                pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                TextBox txtCantidad = (TextBox)gvr.FindControl("txtCantidad");
                pd.Cantidad = Convert.ToInt32(txtCantidad.Text);

                TextBox txtPresentacion = (TextBox)gvr.FindControl("txtPresentacion");
                pd.Presentacion = Convert.ToInt32(txtPresentacion.Text);

                //para la cantidad total calcularla y editarla?
                Label lblCantidadR = (Label)gvr.FindControl("lblCantidadR");
                pd.CantidadRecibida = Convert.ToInt32(lblCantidadR.Text);

                TextBox txtRenglon = (TextBox)gvr.FindControl("txtRenglon");
                pd.RenglonOC = Convert.ToInt32(txtRenglon.Text);

                TextBox txtLote = (TextBox)gvr.FindControl("txtLote");
                pd.NumeroLote = txtLote.Text;

                TextBox txtFVto = (TextBox)gvr.FindControl("txtFVto");
                pd.FechaVencimiento = Convert.ToDateTime(txtFVto.Text);

                TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                pd.Observacion = txtObservacion.Text;

                pd.Renglon = gvr.DataItemIndex + 1;
                /**/
                pd.CantidadSolicitada = 0;
                pd.CantidadAutorizada = 0;
                pd.CantidadEmitida = 0;
                pd.PrecioUnitario = 0;
                pd.Baja = false;

                pds.Add(pd);
            }
        }

        Detalles = pds;
        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    protected void txtPresentacion_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            ((Label)gvr.FindControl("lblCantidadR")).Text = (Convert.ToInt32(((TextBox)gvr.FindControl("txtCantidad")).Text) * Convert.ToInt32(((TextBox)gvr.FindControl("txtPresentacion")).Text)).ToString();
        }
    }

    //protected void txtPrecioTotal_TextChanged(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow gvr in gvInsumos.Rows)
    //    {
    //        ((TextBox)gvr.FindControl("txtPrecio")).Text = (Convert.ToInt32(((TextBox)gvr.FindControl("txtPrecioTotal")).Text) / (Convert.ToInt32(((TextBox)gvr.FindControl("txtPresentacion")).Text) * Convert.ToInt32(((TextBox)gvr.FindControl("txtCantidad")).Text))).ToString();
    //    }
    //}

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedidoDetalle pd = (InsPedidoDetalle)e.Row.DataItem;

            TextBox txtFVto = (TextBox)e.Row.FindControl("txtFVto");
            pd.FechaVencimiento = Convert.ToDateTime(txtFVto.Text);
            if (pd.FechaVencimiento == Convert.ToDateTime("01/01/1900"))
                txtFVto.Text = "";
        }

    }
}
