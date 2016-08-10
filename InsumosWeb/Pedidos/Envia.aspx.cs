using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using SubSonic;

public partial class Pedidos_Envia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
         SysUsuario us = new SysUsuario(Session["idUsuario"]);
         if (!us.IsNew)
         {
             lblMensaje.Text = "";
             // id del IdPedido
             CargarEstados();
             int id = SubSonic.Sugar.Web.QueryString<int>("id");
             if (id > 0)
             {
                 CargarPedido(id);
             }
         }
         else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarEstados()
    {
        SubSonic.Select es = new Select();
        es.From(InsEstadoPedido.Schema);
        es.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(0);
        ddlEstado.DataSource = es.ExecuteTypedList<InsEstadoPedido>();
        ddlEstado.DataBind();
    }


    private void CargarPedido(int id)
    {
        SubSonic.Select p = new Select();
        p.From(InsPedido.Schema);
        p.InnerJoin(InsEstadoPedido.Schema);
        p.Where(InsPedido.IdPedidoColumn).IsEqualTo(id);

        gvPedido.DataSource = p.ExecuteTypedList<InsPedido>();
        gvPedido.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            //guardar y reload de la grilla con el nuevo estado
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            InsPedido p = new InsPedido(id);
            if (!p.IsNew)
            {
                p.IdEstadoPedido = Convert.ToInt32(ddlEstado.SelectedValue); //En trasnporte deberia ser
                p.Estado = true;
                p.Save(us.Username);
                //guardo en Movimiento
                InsMovimiento m = new InsMovimiento();
                m.IdPedido = p.IdPedido;
                m.IdEfector = p.IdEfector;
                m.IdEfectorProveedor = p.IdEfectorProveedor;
                m.IdDeposito = p.IdDeposito;
                m.IdDepositoProveedor = p.IdDepositoProveedor;
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
            }
            //CargarPedido(id); 
            //lblMensaje.Text = "Su Pedido fue enviado satisfactoriamente.";
            Response.Redirect("View.aspx?id=" + id);
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }
}
