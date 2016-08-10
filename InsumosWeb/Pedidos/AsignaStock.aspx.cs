using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;
using System.Data;
using ExtensionMethods;

public partial class Pedidos_AsignaStock : System.Web.UI.Page
{
    public bool tieneStock { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            btnAsignar.Visible = false;
            lblMensaje.Text = "";
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            if (id > 0)
            {
                CargarPedido(id);
            }
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarPedido(int id)
    {
        //traigo el pedido
        InsPedido p = new InsPedido(id);
        lblPedidoNro.Text = p.IdPedido.ToString();
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFechaPedido.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblFecha.Text = p.ModifiedOn.ToString();
        lblEfector.Text = p.InsDeposito.SysEfector.Nombre;
        if (p.IdRubro != 0) lblRubro.Text = p.InsRubro.Nombre;
        else lblRubro.Text = "--";
        lblDeposito.Text = p.InsDeposito.Nombre;
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
        btnAsignar.Visible = tieneStock;
    }

    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        // Asignar stock y guardar descontando de PedidoDetalle 
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            if (DatosValidos(id))
            {
                InsPedido ped = new InsPedido(id);
                InsMovimiento mov = new InsMovimiento();
                mov.IdPedido = id;
                mov.IdEfector = ped.IdEfector;
                mov.IdEfectorProveedor = ped.IdEfectorProveedor;
                mov.IdProveedor = ped.IdProveedor;
                mov.IdRubro = ped.IdRubro;
                mov.IdEstadoPedido = ped.IdEstadoPedido;
                mov.Observaciones = ped.Observaciones;
                mov.NumeroComprobante = ped.NumeroComprobante;
                mov.OrdenCompra = ped.OrdenCompra;
                mov.IdTipoComprobante = ped.IdTipoComprobante;
                mov.IdTipoPedido = ped.IdTipoPedido;
                mov.Fecha = ped.Fecha;
                mov.FechaRecepcion = ped.FechaRecepcion;
                mov.Estado = ped.Estado;
                mov.Autorizado = ped.Autorizado;
                mov.IdDeposito = ped.IdDeposito;
                mov.IdDepositoProveedor = ped.IdDepositoProveedor;
                mov.Responsable = ped.Responsable;
                mov.Save(us.Username);

                foreach (GridViewRow gvr in gvPedidos.Rows)
                {
                    Label lblidPedidoDetalle = (Label)gvr.FindControl("lblidPedidoDetalle");
                    int idPD = Convert.ToInt32(lblidPedidoDetalle.Text);

                    InsPedidoDetalle pdExterno = new InsPedidoDetalle(idPD);
                    GridView gvInsumosStock = (GridView)gvr.FindControl("gvInsumosStock");
                    if (gvInsumosStock != null)
                    {
                        InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
                        InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

                        foreach (GridViewRow gvris in gvInsumosStock.Rows)
                        {
                            TextBox txtCantidad = (TextBox)gvris.FindControl("txtCantidad");
                            HiddenField hfIdPedidoDetalle = (HiddenField)gvris.FindControl("hfIdPedidoDetalle");

                            InsPedidoDetalle pdMio = new InsPedidoDetalle(hfIdPedidoDetalle.Value);

                            int CantidadEmitida = txtCantidad.Text.TryParseInt();
                            pdMio.Stock -= CantidadEmitida;

                            pdExterno.CantidadEmitida += CantidadEmitida;
                            pdExterno.Presentacion = pdMio.Presentacion;
                            pdExterno.PrecioUnitario = pdMio.PrecioUnitario;
                            pdExterno.NumeroLote = pdMio.NumeroLote;
                            pdExterno.FechaVencimiento = pdMio.FechaVencimiento;
                            pdExterno.RenglonOC = pdMio.RenglonOC;

                            pdMio.Save(us.Username);
                            pdExterno.Save(us.Username);

                            pds.Add(pdMio);
                            pds.Add(pdExterno);
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
                        mds.SaveAll(us.Username);
                    }
                }
                Response.Redirect("Envia.aspx?id=" + id);
            }
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private bool DatosValidos(int id)
    {
        //validar la cantidad asignada, segun la presentacion del insumo

        return true;
    }
}
