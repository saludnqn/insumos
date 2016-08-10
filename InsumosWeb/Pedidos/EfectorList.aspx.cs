using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;

public partial class Pedidos_EfectorList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            CargarCombos();
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarCombos()
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(us.IdEfector); //efector por defecto del usuario
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("TODOS", "0"));

        //SubSonic.Select r = new SubSonic.Select();
        //r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        //r.And(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        //r.OrderAsc("Nombre");
        //ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        //ddlRubro.DataBind();
        //ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));

     /*   SubSonic.Select ep = new Select();
        ep.From(InsEstadoPedido.Schema);
        ep.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(1);
        ddlEstado.DataSource = ep.ExecuteTypedList<InsEstadoPedido>();
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("TODOS", "0")); */
    }

//    protected void ddlDeposito_SelectedIndexChanged(object sender, EventArgs e)
 //   {
        //int dep = Convert.ToInt32(ddlDeposito.SelectedValue);

        //SubSonic.Select r = new SubSonic.Select();
        //r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        //r.And(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        //r.OrderAsc("Nombre");
        //ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        //ddlRubro.DataBind();
        //ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));
   // }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);

        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        //int ef = Convert.ToInt32(ddlEfector.SelectedValue);
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);
      //  int rub = Convert.ToInt32(ddlRubro.SelectedValue);
      //  int ep = 0; // Convert.ToInt32(ddlEstado.SelectedValue);
        int aut = Convert.ToInt32(ddlAutorizado.SelectedValue);
        //consulta de datos para la grilla
        SubSonic.Select c = new Select();
        c.From(InsPedido.Schema);
        //c.Where(InsPedido.Columns.Baja).IsEqualTo(0);
        c.Where(InsPedido.Columns.IdTipoPedido).IsNotEqualTo(6);
        // c.And(InsPedido.Columns.Autorizado).IsEqualTo(1);
        c.And(InsPedido.Columns.IdEfector).IsEqualTo(us.IdEfector);
        c.And(InsPedido.Columns.IdDeposito).IsEqualTo(dep);
      //  c.Or(InsPedido.Columns.IdRubro).IsEqualTo(rub);
      //  c.Or(InsPedido.Columns.IdRubro).IsEqualTo(27); //por defecto: Medicamentos
        c.And(InsPedido.Columns.Fecha).IsGreaterThanOrEqualTo(finicio);
        c.And(InsPedido.Columns.Fecha).IsLessThanOrEqualTo(ffin);
       // c.And(InsPedido.IdEstadoPedidoColumn).IsEqualTo(ep);
        c.And(InsPedido.Columns.Autorizado).IsEqualTo(aut);
        c.OrderAsc("IdPedido");

        DataSet de = c.ExecuteDataSet();
        if (de.Tables.Count > 0)
        {
            gvPedidos.DataSource = de;
            gvPedidos.DataBind();
            lblMensaje.Text = "";
        }
        else
        {
            lblMensaje.Text = "No existen registros";
            gvPedidos.DataBind();
        }
        gvPedidos.DataBind();
    }

    protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[1].Text)
            {
                case "1":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado1.png";
                        hlE.ToolTip = "Estado Generado";
                    }
                    break;
                case "2":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado2.png";
                        hlE.ToolTip = "Estado Autorizado Parcial";
                    }
                    break;
                case "3":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado3.png";
                        hlE.ToolTip = "Estado Autorizado Total";
                    }
                    break;
                case "4":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado4.png";
                        hlE.ToolTip = "Estado Eliminado";
                    }
                    break;
                case "5":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado5.png";
                        hlE.ToolTip = "Estado Finalizado";
                    }
                    break;
            }
            //autorizo y envio el pedido
            //guardo el dato en la DB
            CheckBox chk = (CheckBox)e.Row.FindControl("ckAutorizar");
            int idPedido = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "idPedido").ToString());

            int registros = new SubSonic.Select().From<InsPedido>()
                .Where("idPedido").IsEqualTo(idPedido)
                .And("autorizado").IsEqualTo(0).GetRecordCount();

            chk.Attributes.Add("idPedido", idPedido.ToString());

            //muestro u oculto las columnas segun autorizacion
            if (e.Row.Cells[7].Text == "True")
            {
                e.Row.Cells[6].Text = "Autorizado";
                e.Row.Cells[7].Text = "Enviado";
                e.Row.BackColor = System.Drawing.Color.FromName("#bdd9c0");
            }
            else
            {
                e.Row.Cells[7].Text = "No Enviado";
                e.Row.BackColor = System.Drawing.Color.FromName("#eef1d1");
            }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            int idPed = 0;
            //buscar y ubicar el pedido para luego actulaizar los datos: de modificacion y autorizacion
            foreach (GridViewRow row in gvPedidos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)row.FindControl("ckAutorizar");
                    Label lblIdPedido = (Label)row.FindControl("lblIdPedido");
                    idPed = Convert.ToInt32(lblIdPedido.Text);
                    if (chk.Checked)
                    {
                        InsPedido p = new InsPedido(idPed);
                        p.Autorizado = chk.Checked;
                        p.Save(us.Username);
                    }
                    Response.Redirect("EfListAutorizados.aspx?id=" + idPed.ToString());
                }
            }
        }
        else Response.Redirect("~/FinSesion.htm",false);
    }
}
