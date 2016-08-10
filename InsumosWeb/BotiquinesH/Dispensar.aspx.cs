using System;
using System.Linq;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;
using Salud.Security.SSO;

public partial class BotiquinesH_Dispensar : System.Web.UI.Page
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
        lblPedido.Text = "";
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
            lblPedido.Text = p.InsTipoPedido.Nombre;
            ddlDeposito.SelectedValue = p.IdDepositoProveedor.ToString();
            ddlDeposito_SelectedIndexChanged(null, null);
            txtFecha.Text = p.Fecha.ToString();
            ddlServicio.SelectedValue = p.IdDeposito.ToString();
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (true) //&& (Page.IsValid))// Page.Validate("1");
        {

        }
    }

    private void CargarCombo()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        //deposito o area del hospital
        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //deposito del efector
        //d.And(InsDeposito.IdTipoDepositoColumn).IsEqualTo(2);
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("Seleccionar", "0"));

        //ddlServicio.DataSource = SPs.SysGetServicioByEfector(us.IdEfector).GetDataSet();
        //ddlServicio.DataBind();
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
            p.IdEfectorProveedor = idEfector;
            //p.IdDepositoProveedor = Convert.ToInt32(ddlDepositoProveedor.SelectedValue);
            p.IdDepositoProveedor = Convert.ToInt32(ddlDeposito.SelectedValue);
            p.IdDeposito = Convert.ToInt32(ddlServicio.SelectedValue);
            p.Fecha = Convert.ToDateTime(txtFecha.Text);
            p.FechaRecepcion = Convert.ToDateTime(txtFecha.Text);
            p.IdTipoPedido = 6;
            p.IdRubro = 326; //Medicamentos 
            p.IdTipoComprobante = 0;
            p.NumeroComprobante = p.IdPedido.ToString();
            p.OrdenCompra = "";
            p.IdEstadoPedido = 5; //Enviado
            p.IdProveedor = 0;
            p.Observaciones = txtObservaciones.Text;
            p.Responsable = txtResponsable.Text; //deberia traer el nombre del usuario
            p.Autorizado = true; //cuando el idEstadoPedido = 2 >> autorizado = true
            p.Estado = false;
            p.Baja = false;
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

                TextBox txtCantidadEnviada = (TextBox)gvr.FindControl("txtCantidadEnviada");
                pd.CantidadEmitida = Convert.ToInt32(txtCantidadEnviada.Text);

                TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                pd.Observacion = txtObservacion.Text;

                pd.Renglon = gvr.DataItemIndex + 1;
                /**/
                pd.CantidadAutorizada = pd.CantidadEmitida;
                pd.CantidadSolicitada = pd.CantidadEmitida;
                pd.CantidadRecibida = pd.CantidadEmitida;
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
            Response.Redirect("VerDispensa.aspx?id=" + p.IdPedido.ToString());
            //Response.Redirect("Dispensar.aspx?id=" + p.IdPedido.ToString());
            //si es la misma fecha volver a la misma pantalla para agregar medicamentos al pedido x servicio
            //hasta qye presione Imprimir...,
        }
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

            TextBox txtCantidadEnviada = (TextBox)gvr.FindControl("txtCantidadEnviada");
            pd.CantidadEmitida = Convert.ToInt32(txtCantidadEnviada.Text);

            TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
            pd.Observacion = txtObservacion.Text;

            pd.Renglon = gvr.DataItemIndex + 1;
            /**/
            pd.CantidadAutorizada = 0;
            pd.CantidadSolicitada = 0;
            pd.CantidadRecibida = 0;
            pd.PrecioUnitario = 0;
            pd.Baja = false;

            pds.Add(pd);
        }
        int idNuevoInsumo = Insumo.getInsumo();
        InsPedidoDetalle ipd = pds.FirstOrDefault(x => x.IdInsumo == idNuevoInsumo);
        if (ipd == null)
        {
            // agrego el nuevo insumo
            InsPedidoDetalle pd1 = new InsPedidoDetalle();
            pd1.IdPedido = id;
            pd1.FechaPedido = Convert.ToDateTime(txtFecha.Text);
            pd1.IdInsumo = Insumo.getInsumo();
            pd1.CantidadSolicitada = 1;
            pd1.Observacion = "";
            pd1.Renglon = 0;
            /**/
            pd1.CantidadAutorizada = 0;
            pd1.CantidadSolicitada = 0;
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

                TextBox txtCantidadEnviada = (TextBox)gvr.FindControl("txtCantidadEnviada");
                pd.CantidadEmitida = Convert.ToInt32(txtCantidadEnviada.Text);

                TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                pd.Observacion = txtObservacion.Text;

                pd.Renglon = gvr.DataItemIndex + 1;
                /**/
                pd.CantidadAutorizada = 0;
                pd.CantidadSolicitada = 0;
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

    protected void ddlDeposito_SelectedIndexChanged(object sender, EventArgs e)
    {
        //listo depositos y segun el depo seleccionado muestro los servicios
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);

        // "idConsulta",
        //               AprControlNiñoSano.Schema.TableName + ".IdControlNiñoSano",
        //               "IdIntervencion",
        //               SysProfesional.Schema.TableName + ".Apellido as ApellidosProfesional",
        //               SysCIE10.Schema.TableName + ".Nombre as NombreDiagnostico"
        //               .LeftOuterJoin(SysProfesional.IdProfesionalColumn, ConConsultum.IdProfesionalColumn)

        SubSonic.Select s = new SubSonic.Select("IdDeposito", "Nombre");
        s.From(InsDeposito.Schema);
        s.Where(InsDeposito.IdDepositoSuperiorColumn).IsEqualTo(dep);
        s.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector);
       //s.And(InsDeposito.IdTipoDepositoColumn).IsEqualTo(2);
        ddlServicio.DataSource = s.ExecuteDataSet();// s.ExecuteTypedList<SysServicio>(); 
        ddlServicio.DataBind();
    }
}
