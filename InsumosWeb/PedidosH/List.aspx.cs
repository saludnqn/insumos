using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;
using Salud.Security.SSO;


public partial class Pedidos_List : System.Web.UI.Page
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
        ddlDepositoSolicitante.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoSolicitante.DataBind();
        
        ddlDepositoProveedor.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoProveedor.DataBind();
        ddlDepositoProveedor.Items.Insert(0, new ListItem("(Todos)", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Codigo).IsEqualTo(362);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("(Todos)", "0"));

        SubSonic.Select ep = new Select();
        ep.From(InsEstadoPedido.Schema);
        ep.Where(InsEstadoPedido.Columns.Activo).IsEqualTo(1);
        ddlEstado.DataSource = ep.ExecuteTypedList<InsEstadoPedido>();
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("TODOS", "0"));
    }

    protected void ddlDepositoSolicitante_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int dep = Convert.ToInt32(ddlDepositoSolicitante.SelectedValue);

        //SubSonic.Select r = new SubSonic.Select();
        //r.From(InsRubro.Schema);
        ////r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        //r.Where(InsRubro.Columns.Padre).IsEqualTo(0);
        //r.OrderAsc("Nombre");
        //ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        //ddlRubro.DataBind();
        //ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));
        gvPedidos.DataSource = null;
        gvPedidos.DataBind();
        lblCantidad.Text = "Presione nuevamente Buscar ";

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = DateTime.Now.AddDays(-30);
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        //int ef = Convert.ToInt32(ddlEfector.SelectedValue);
        int depSolicitante = Convert.ToInt32(ddlDepositoSolicitante.SelectedValue);
        int depProveedor = Convert.ToInt32(ddlDepositoProveedor.SelectedValue);
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);
        int ep = Convert.ToInt32(ddlEstado.SelectedValue);
        int aut = Convert.ToInt32(ddlAutorizado.SelectedValue);
        //consulta de datos para la grilla
        DataTable dt = SPs.InsGetPedidosHGenerados(finicio, ffin, depSolicitante, depProveedor, rub, ep, aut, idEfector).GetDataSet().Tables[0];
        gvPedidos.DataSource = dt;
        gvPedidos.DataBind();
        lblCantidad.Text = "Registros existentes: " + dt.Rows.Count.ToString();
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
                case "4":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado4.png";
                        hlE.ToolTip = "CANCELADO";
                    }
                    break;
                case "5":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/Finalizado.png";
                        hlE.ToolTip = "FINALIZADO";
                    }
                    break;
                case "6":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/Pendiente.png";
                        hlE.ToolTip = "PENDIENTE";
                    }
                    break;
                case "7":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/EnPreparacion.png";
                        hlE.ToolTip = "En Preparación";
                    }
                    break;
                case "8":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/Preparado.png";
                        hlE.ToolTip = "PREPARADO";
                    }
                    break;
                case "9":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/EnTransporte.png";
                        hlE.ToolTip = "ENTREGADO/ENVIADO";
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
            if (e.Row.Cells[9].Text == "True")
            {
                e.Row.Cells[9].Text = "CONFIRMADO";
                e.Row.Cells[9].ToolTip = "Pedido Autorizado";
                e.Row.Cells[12].Text = "";  //oculta boton edit
                //e.Row.Cells[13].Text = "";  //oculta boton entregar
            }
            else
            {
                e.Row.Cells[9].Text = "NO CONFIRMADO";
                e.Row.Cells[9].ToolTip = "No Autorizado";
                e.Row.Cells[14].Text = "";                
            }

            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            if (lblEstado.Text == "True")
            {
                e.Row.Cells[14].Text = "";
            }

            Label lblIdPedido = (Label)e.Row.FindControl("lblIdPedido");
            hfIdPedido.Value = lblIdPedido.Text;
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
