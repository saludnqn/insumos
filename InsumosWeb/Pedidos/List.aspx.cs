using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;

public partial class Pedidos_List : System.Web.UI.Page
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
        SubSonic.Select e = new SubSonic.Select();
        e.From(SysEfector.Schema);
        e.Where(SysEfector.Columns.Complejidad).IsGreaterThan(Convert.ToInt32("2"));
        e.Or(SysEfector.Columns.IdEfectorSuperior).IsEqualTo(227);
        e.OrderAsc("Nombre");
        ddlEfector.DataSource = e.ExecuteTypedList<SysEfector>();
        ddlEfector.DataBind();
        ddlEfector.Items.Insert(0, new ListItem("TODOS", "0"));

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("TODOS", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));

   /*    SubSonic.Select ep = new Select();
        ep.From(InsEstadoPedido.Schema);
        // ep.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(0);
        ddlEstado.DataSource = ep.ExecuteTypedList<InsEstadoPedido>();
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("TODOS", "0"));*/
    }

    protected void ddlDeposito_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));
    }

    protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ef = Convert.ToInt32(ddlEfector.SelectedValue);

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(ef);
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        int ef = Convert.ToInt32(ddlEfector.SelectedValue);
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);
        int ep = 0; // Convert.ToInt32(ddlEstado.SelectedValue);
        int np = Convert.ToInt32(txtNroPedido.Text);

        gvPedidos.DataSource = SPs.InsGetConsultaPedidos(finicio, ffin, ef, dep, rub, ep, np).GetDataSet();
        gvPedidos.DataBind();
    }

    protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text == "True")
            {
                e.Row.Cells[4].Text = "Autorizado";
                e.Row.Cells[4].ToolTip = "Pedido Autorizado";
            }
            else
            {
                e.Row.Cells[4].Text = "No Autorizado";
                e.Row.Cells[4].ToolTip = "No Autorizado";
            }
            //seteo las acciones
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            switch (lblEstado.Text.ToLower())
            {
                case "generado":
                    {
                        e.Row.Cells[8].Visible = true;
                        e.Row.Cells[9].Text = "";
                        e.Row.Cells[10].Text = "";
                    }
                    break;
                case "confirmado parcial":
                    {
                        e.Row.Cells[8].Visible = true;
                        e.Row.Cells[9].Text = "";
                        e.Row.Cells[10].Text = "";
                    }
                    break;
                case "confirmado total":
                    {
                        e.Row.Cells[8].Visible = true;
                        e.Row.Cells[9].Text = "";
                        e.Row.Cells[10].Text = "";
                    }
                    break;
                case "preparado parcial":
                    {
                        e.Row.Cells[8].Text = "";
                        e.Row.Cells[9].Visible = true;
                      //  e.Row.Cells[10].Text = "";
                    }
                    break;
                case "preparado total":
                    {
                        e.Row.Cells[8].Text = "";
                        e.Row.Cells[9].Visible = true;
                      //  e.Row.Cells[10].Text = "";
                    }
                    break;
                case "entregado":
                    {
                        e.Row.Cells[8].Text = "";
                        e.Row.Cells[9].Text = "";
                        e.Row.Cells[10].Text = "";
                        e.Row.Cells[11].Visible = true;
                    }
                    break;
                case "cancelado":
                    {
                        e.Row.Cells[8].Text = "";
                        e.Row.Cells[9].Text = "";
                        e.Row.Cells[10].Text = "";
                    }
                    break;
                case "finalizado":
                    {
                        e.Row.Cells[8].Text = "";
                        e.Row.Cells[9].Text = "";
                        e.Row.Cells[10].Text = "";
                        e.Row.Cells[11].Visible = true;
                        e.Row.Cells[12].Visible = true;
                    }
                    break;
            }

            Label lblCantidadEnviada = (Label)e.Row.FindControl("lblCantidadEnviada");
            if (!string.IsNullOrEmpty(lblCantidadEnviada.Text))
            {
                int CantE = Convert.ToInt32(lblCantidadEnviada.Text);
                if (CantE > 0)
                {
                    e.Row.Cells[8].Text = "";
                    e.Row.Cells[9].Text = "";
                    e.Row.Cells[10].Text = "";
                    e.Row.Cells[11].Visible = true;
                }
            }

            Label lblCantidadRecibida = (Label)e.Row.FindControl("lblCantidadRecibida");
            if (!string.IsNullOrEmpty(lblCantidadRecibida.Text))
            {
                int CantR = Convert.ToInt32(lblCantidadRecibida.Text);
                if (CantR > 0)
                {
                    e.Row.Cells[8].Text = "";
                    e.Row.Cells[9].Text = "";
                    e.Row.Cells[10].Text = "";
                    e.Row.Cells[11].Visible = true;
                    e.Row.Cells[12].Visible = true;
                }
            }
            
            /*
            CheckBox chk = (CheckBox)e.Row.FindControl("chkPedidos");
            int idPedido = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "idPedido").ToString());
            chk.Attributes.Add("idPedido", idPedido.ToString());
            */

            //bindeo la segunda grilla
            int idP = Convert.ToInt32(e.Row.Cells[1].Text);
            hfIdPedido.Value = idP.ToString();
            GridView gv = (GridView)e.Row.FindControl("gvPedidoDetalle");

            //consulta que trae los detalles del pedido
            SubSonic.Select pd = new Select();
            pd.From(InsPedidoDetalle.Schema);
            pd.InnerJoin(InsInsumo.Schema);
            pd.Where(InsPedidoDetalle.IdPedidoColumn).IsEqualTo(idP);

            List<InsPedidoDetalle> tmd = pd.ExecuteTypedList<InsPedidoDetalle>();
            gv.DataSource = tmd;
            gv.DataBind();
        }
    }

    /* protected void btnAutorizar_Click(object sender, EventArgs e)
     {
         //boton que permite q el deposito autorice y edite el pedido realizado desde el hospital
         int id =  Convert.ToInt32(hfIdPedido.Value);
         if (id != 0)
             Response.Redirect("Autoriza.aspx?id=" + id);
         else return;
     }*/
}
