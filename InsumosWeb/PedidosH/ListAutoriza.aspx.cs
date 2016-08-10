using System;
using System.Data;
using System.Web.UI.WebControls;
using DalInsumos;
using ExtensionMethods;
using Salud.Security.SSO;


public partial class PedidosH_ListAutoriza : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombos();
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector por defecto del usuario
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.OrderAsc("Nombre");
        ddlDepositoOrigen.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoOrigen.DataBind();
        ddlDepositoOrigen.Items.Insert(0, new ListItem("TODOS", "0"));
        //deposito proveedor
        ddlDepositoProveedor.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoProveedor.DataBind();
        ddlDepositoProveedor.Items.Insert(0, new ListItem("TODOS", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(362);
        //r.And(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        //r.And(InsRubro.Columns.Baja).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));
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
        int depp = Convert.ToInt32(ddlDepositoProveedor.SelectedValue);
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);
        int aut = Convert.ToInt32(ddlAutorizado.SelectedValue);
        //consulta de datos para la grilla
        DataTable dt = SPs.InsGetPedidosInternos(finicio, ffin, depp, rub, aut, idEfector).GetDataSet().Tables[0];
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
                case "6":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado1.png";
                        hlE.ToolTip = "Generado SSS";
                    }
                    break;
                case "7":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado2.png";
                        hlE.ToolTip = "Preparado Parcial SSS";
                    }
                    break;
                case "8":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado3.png";
                        hlE.ToolTip = "Preparado Total SSS";
                    }
                    break;
                case "9":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado9.png";
                        hlE.ToolTip = "Entregado";
                    }
                    break;
                case "10":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado4.png";
                        hlE.ToolTip = "Cancelado";
                    }
                    break;
                case "11":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado5.png";
                        hlE.ToolTip = "Finalizado";
                    }
                    break;

            }
            //seteo lo q se mostrara segun el contenido
            if (e.Row.Cells[10].Text == "True")
            {
                e.Row.Cells[10].Text = "Autorizado";
                e.Row.Cells[10].ToolTip = "Pedido Autorizado";
                e.Row.Cells[11].Text = ""; //ver
                e.Row.Cells[12].Visible = false; //editar
                e.Row.Cells[12].Text = ""; //editar
            }
            else
            {
                e.Row.Cells[10].Text = "No Autorizado";
                e.Row.Cells[10].ToolTip = "No Autorizado";
                e.Row.Cells[12].Visible = true; //editar
                e.Row.Cells[14].Text = ""; //asigna
            }
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            Label lblCantidadEnviada = (Label)e.Row.FindControl("lblCantidadEnviada");
            if (lblCantidadEnviada == null)
            {
                e.Row.Cells[14].Visible = false; //11: autorizar; 12: asignar
            }
            else
            {
                int cant = lblCantidadEnviada.Text.TryParseInt();
                if (cant < 0)
                {
                    e.Row.Cells[14].Visible = true; //autorizar
                    e.Row.Cells[13].Visible = false; //editar
                }
            }
            Label lblIdPedido = (Label)e.Row.FindControl("lblIdPedido");
            hfIdPedido.Value = lblIdPedido.Text;
            //controlar y validar los estados
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx", false);
    }
}
