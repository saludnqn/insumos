﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Globalization;
using System.Data;
using SubSonic;
using ExtensionMethods;

public partial class Pedidos_Autorizar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            // id del IdPedido
            CargarEstado();
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            if (id > 0)
            {
                CargarPedido(id);
            }
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarEstado()
    {
        SubSonic.Select es = new Select();
        es.From(InsEstadoPedido.Schema);
        es.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(0);
        ddlEstados.DataSource = es.ExecuteTypedList<InsEstadoPedido>();
        ddlEstados.DataBind();
    }

    private void CargarPedido(int id)
    {
        //debo traer el pedido para cambiar o no el estado
        InsPedido p = new InsPedido(id);
        lblEstados.Text = "Se ha generado el pedido Nro: " + p.IdPedido;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblEfector.Text = p.InsDeposito.SysEfector.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        txtResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        ddlEstados.SelectedValue = p.IdEstadoPedido.ToString();
        ckbAutoriza.Checked = p.Autorizado.Value;
        ckbBaja.Checked = p.Baja;
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            //cambia de estado a Autorizado
            lblEstados.Text = "";
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            if (id > 0)
            {
                InsPedido p = new InsPedido(id);
                if (!p.IsNew)
                {
                    //debo cambiar el estado del pedido
                    p.IdEstadoPedido = Convert.ToInt32(ddlEstados.SelectedValue);
                    p.Responsable = txtResponsable.Text;
                    p.Observaciones = txtObservaciones.Text;
                    //p.Estado = true; // cuando autorizo guardo el estado en true, o sea ya se envia??
                    if (ckbAutoriza.Checked == true) p.Autorizado = true;
                    else p.Autorizado = false;

                    if (ckbBaja.Checked == true) p.Baja = true;
                    else p.Baja = false;
                    p.Save(us.Username);

                    //guardo en Movimiento
                    InsMovimiento m = new InsMovimiento();
                    m.IdPedido = p.IdPedido;
                    m.IdEfector = p.IdEfector;
                    m.IdEfectorProveedor = p.IdEfectorProveedor;
                    m.IdDeposito = p.IdDeposito;
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
                    m.Save(us.Username);

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
                        //la cantidad autorizada por el efector = cantidad solicitada por el efector
                        TextBox txtCAutorizada = (TextBox)gvr.FindControl("txtCAutorizada");
                        pd.CantidadAutorizada = Convert.ToInt32(txtCAutorizada.Text);

                        TextBox txtObservacion = (TextBox)gvr.FindControl("txtObservacion");
                        pd.Observacion = txtObservacion.Text;

                        pd.Baja = false;
                        pds.Add(pd);
                    }
                    pds.SaveAll();
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
                        md.RenglonOC = item.RenglonOC;
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
                    //Response.Redirect("Prepara.aspx?id=" + p.IdPedido);
                    Response.Redirect("AsignaStock.aspx?id=" + p.IdPedido);
                }
            }
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }
}
