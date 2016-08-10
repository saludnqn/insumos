using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;
using Salud.Security.SSO;


public partial class Pedidos_ListDepo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombos();
        txtFInicio.Text = DateTime.Now.AddDays(-31).ToShortDateString();
        txtFFin.Text = DateTime.Now.ToShortDateString();
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector por defecto del usuario
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.OrderAsc("Nombre");
        ddlDepositoDestino.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoDestino.DataBind();
        ddlDepositoDestino.Items.Insert(0, new ListItem("(Todos)", "0"));
        
        ddlDepositoProveedor.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoProveedor.DataBind();
        //ddlDepositoProveedor.Items.Insert(0, new ListItem("TODOS", "0"));


        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Codigo).IsEqualTo(362);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));

        SubSonic.Select ep = new Select();
        ep.From(InsEstadoPedido.Schema);
        ep.Where(InsEstadoPedido.Columns.Activo).IsEqualTo(1);
        ddlEstado.DataSource = ep.ExecuteTypedList<InsEstadoPedido>();
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("TODOS", "0"));
    }

    protected void ddlDepositoDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int dep = Convert.ToInt32(ddlDepositoDestino.SelectedValue);

        //SubSonic.Select r = new SubSonic.Select();
        //r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Padre).IsEqualTo(0);
        //r.OrderAsc("Nombre");
        //ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        //ddlRubro.DataBind();
        //ddlRubro.Items.Insert(0, new ListItem("(Todos)", "0"));

        gvPedidos.DataSource = null;
        gvPedidos.DataBind();
        lblCantidad.Text = "Presione nuevamente Buscar ";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        //int ef = Convert.ToInt32(ddlEfector.SelectedValue);
        int depositoProveedor = Convert.ToInt32(ddlDepositoProveedor.SelectedValue);
        int deposito = Convert.ToInt32(ddlDepositoDestino.SelectedValue);
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);
        int ep = Convert.ToInt32(ddlEstado.SelectedValue);
        //int aut = Convert.ToInt32(ddlAutorizado.SelectedValue);
        //consulta de datos para la grilla
        DataTable dt = SPs.InsGetPedidosH(finicio, ffin, depositoProveedor, deposito, rub, ep, -1, idEfector).GetDataSet().Tables[0];
        gvPedidos.DataSource = dt;
        gvPedidos.DataBind();
        lblCantidad.Text = "Registros existentes: " + dt.Rows.Count.ToString();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx");
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
                        hlE.ImageUrl = "../App_Themes/images/Generado.png";
                        hlE.ToolTip = "GENERADO";
                        e.Row.Cells[12].Text = "";
                        e.Row.Cells[13].Text = "";
                    }
                    break;
                //case "2":
                //    {
                //        Image hlE = new Image();
                //        hlE = (Image)e.Row.FindControl("imgEstado");
                //        hlE.ImageUrl = "../App_Themes/Default/images/estado1.png";
                //        hlE.ToolTip = "AUTORIZADO";
                //    }
                //    break;
                //case "3":
                //    {
                //        Image hlE = new Image();
                //        hlE = (Image)e.Row.FindControl("imgEstado");
                //        hlE.ImageUrl = "../App_Themes/Default/images/estado1.png";
                //        hlE.ToolTip = "AUTORIZADO";
                //    }
                //    break;
                //case "4":
                //    {
                //        Image hlE = new Image();
                //        hlE = (Image)e.Row.FindControl("imgEstado");
                //        hlE.ImageUrl = "../App_Themes/Default/images/estado4.png";
                //        hlE.ToolTip = "Cancelado";               
                //    }
                //    break;
                case "5":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/Finalizado.png";
                        hlE.ToolTip = "FINALIZADO";
                        e.Row.Cells[12].Text = "";
                        e.Row.Cells[13].Text = "";
                    }
                    break;
                case "6":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/Pendiente.png";
                        hlE.ToolTip = "PENDIENTE";
                        e.Row.Cells[13].Text = "";
                    }
                    break;
                case "7":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/EnPreparacion.png";
                        hlE.ToolTip = "EN PREPARACION";
                        e.Row.Cells[12].Text = "";
                        
                    }
                    break;
                case "8":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/Preparado.png";
                        hlE.ToolTip = "PREPARADO";
                        e.Row.Cells[12].Text = "";
                    }
                    break;
                case "9":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/EnTransporte.png";
                        hlE.ToolTip = "ENTREGADO/ENVIADO";
                        e.Row.Cells[12].Text = "";
                        e.Row.Cells[13].Text = "";
                    }
                    break;
                //case "10":
                //    {
                //        Image hlE = new Image();
                //        hlE = (Image)e.Row.FindControl("imgEstado");
                //        hlE.ImageUrl = "../App_Themes/Default/images/estado4.png";
                //        hlE.ToolTip = "Cancelado";
                //    }
                //    break;
                //case "11":
                //    {
                //        Image hlE = new Image();
                //        hlE = (Image)e.Row.FindControl("imgEstado");
                //        hlE.ImageUrl = "../App_Themes/Default/images/estado5.png";
                //        hlE.ToolTip = "Entregado";
                //    }
                //    break;

            }
            
            //seteo lo q se mostrara segun el contenido
            
            //if (e.Row.Cells[9].Text == "True")
            //{
            //    e.Row.Cells[9].Text = "CONFIRMADO";
            //    e.Row.Cells[9].ToolTip = "Pedido Autorizado";
            //    //e.Row.Cells[12].Text = "";  //oculta boton edit
            //    //e.Row.Cells[13].Text = "";  //oculta boton entregar
            //}
            //else
            //{
            //    e.Row.Cells[9].Text = "NO CONFIRMADO";
            //    e.Row.Cells[9].ToolTip = "No Autorizado";

            //}
        }
    }

    //protected void btnEnviar_Click(object sender, EventArgs e)
    //{
    //    //boton que permite q el dir del Hospital envie el pedido a SSS
    //    int id = Convert.ToInt32(hfIdPedido.Value);
    //    if (id != 0)
    //        Response.Redirect("Autoriza.aspx?id=" + id);
    //    else return;
    //}

}
