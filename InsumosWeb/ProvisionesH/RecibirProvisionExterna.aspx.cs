using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;
using Salud.Security.SSO;
using System.Configuration;
//using System.Globalization;
//using System.Linq;




public partial class ProvisionesH_RecibirProvisionExterna : System.Web.UI.Page
{

    //private InsPedidoDetalleCollection Detalles
    //{
    //    get
    //    {
    //        return ViewState["detalles"] == null ? new InsPedidoDetalleCollection() : (InsPedidoDetalleCollection)ViewState["detalles"];
    //    }
    //    set { ViewState["detalles"] = value; }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarRecepcion(id);
            CargarDepositos();
        }
    }

    private void CargarDepositos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector del usuario
        d.OrderAsc("Nombre");
                       
        ddlDepositoReceptor.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoReceptor.DataBind();        
    }

    private void CargarRecepcion(int id)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select reg = new SubSonic.Select();
        reg.From(InsDepositoZona.Schema);
        reg.Where(InsDepositoZona.IdEfectorColumn).IsEqualTo(idEfector);
        InsDepositoZona dep = reg.ExecuteSingle<InsDepositoZona>();

        DataTable dt = SPs.InsGetPedidoProvisionExterna(dep.IdEfectorSistemaIntegrado, id, dep.IpDepositoZona).GetDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblPedido.Text = dt.Rows[0][0].ToString();
            lblDepositoProveedor.Text = "Abastecimiento Depósito Central";
            lblFechaPedido.Text = dt.Rows[0][2].ToString();
            lblFechaDespacho.Text = dt.Rows[0][7].ToString();
            txtResponsable.Text = dt.Rows[0][4].ToString();
            txtObservaciones.Text = dt.Rows[0][5].ToString();
        }
        gvInsumos.DataSource = SPs.InsGetPedidoProvisionExterna(dep.IdEfectorSistemaIntegrado, id, dep.IpDepositoZona).GetDataSet().Tables[1];
        gvInsumos.DataBind();
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblIdInsumo = (Label)e.Row.FindControl("lblIdInsumo");

            Label lblCantidadEnviada = (Label)e.Row.FindControl("lblCantidadEnviada");

            TextBox txtCantidadRecibida = (TextBox)e.Row.FindControl("txtCantidadRecibida");
            txtCantidadRecibida.Text = lblCantidadEnviada.Text;
        }
        
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        //  int id = SubSonic.Sugar.Web.QueryString<int>("id"); //este id = pedido Nro del pedido de abastecimiento
        InsPedido p = new InsPedido();
        if (p.IsNew)
        {
            p.IdEfector = idEfector;
            p.IdEfectorProveedor = idEfector; 
            p.IdDeposito = Convert.ToInt32(ddlDepositoReceptor.SelectedValue); //primer deposito creado para el efector
            p.IdDepositoProveedor = 0;
            p.IdEstadoPedido = 5;  //"Finalizado"
            p.IdTipoPedido = 7;  //"PROVISION ZONA"
            p.Fecha = Convert.ToDateTime(lblFechaPedido.Text); //fecha del pedido
            p.FechaRecepcion = DateTime.Now;
            p.IdRubro = 250; //"Medicamentos"
            p.IdTipoComprobante = 7; //"REMITO"
            p.NumeroComprobante = lblPedido.Text; //aca va el nro de pedido
            p.OrdenCompra = "";
            p.Estado = true;
            p.Baja = false;
            p.Autorizado = true;
            p.Responsable = txtResponsable.Text;
            p.IdProveedor = 124; //"Subsec Salud"
            p.Observaciones = "Recibido por el Efector. " + txtObservaciones.Text;
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

            //guardar los datos de la grilla o detalle del pedido
            InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
            InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

            foreach (GridViewRow gvr in gvInsumos.Rows)
            {
                InsPedidoDetalle pd = new InsPedidoDetalle();
                pd.IdPedido = p.IdPedido;
                pd.FechaPedido = Convert.ToDateTime(lblFechaPedido.Text);

                Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                InsInsumo i = new InsInsumo("Codigo", lblIdInsumo.Text);
                pd.IdInsumo = i.Codigo;

                Label lblCantidadEnviada = (Label)gvr.FindControl("lblCantidadEnviada");
                pd.CantidadEmitida = Convert.ToInt32(lblCantidadEnviada.Text);

                TextBox txtCantidadRecibida = (TextBox)gvr.FindControl("txtCantidadRecibida");
                pd.CantidadRecibida = Convert.ToInt32(txtCantidadRecibida.Text);
                pd.Stock = pd.CantidadRecibida;

                TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservaciones");
                pd.Observacion = txtObservacion.Text;

                Label lblMultiplicador = (Label)gvr.FindControl("lblMultiplicador");
                pd.Presentacion = Convert.ToInt32(lblMultiplicador.Text);

                TextBox txtLote = (TextBox)gvr.FindControl("txtLote");
                pd.NumeroLote = txtLote.Text;

                TextBox txtFechaVencimiento = (TextBox)gvr.FindControl("txtFechaVencimiento");
                if (txtFechaVencimiento.Text != "")
                    pd.FechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);
                else pd.FechaVencimiento = Convert.ToDateTime("01/01/2050");   //medicamento sin vencimiento

                pd.Renglon = gvr.DataItemIndex + 1;

                pd.CantidadSolicitada = 0;
                pd.CantidadAutorizada = 0;
                pd.Cantidad = 0;                
                pd.PrecioUnitario = 0;
                pd.RenglonOC = 0;
                pd.Stock = pd.CantidadRecibida;
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
            Response.Redirect("VerProvisionExterna.aspx?id=" + p.IdPedido.ToString());
        }
    }   
}