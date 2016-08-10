using System;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using SubSonic;
using Salud.Security.SSO;


public partial class ProvisionesH_Recepcion : System.Web.UI.Page
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
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("TODOS", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(362);
        //r.And(InsRubro.Columns.Baja).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select ep = new Select();
        ep.From(InsEstadoPedido.Schema);
        ep.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(0);
        ddlEstado.DataSource = ep.ExecuteTypedList<InsEstadoPedido>();
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("TODOS", "0"));
    }

    protected void ddlDeposito_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(362);
        //r.And(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("Seleccionar", "0"));
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
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);
        int ep = Convert.ToInt32(ddlEstado.SelectedValue);
        //consulta de datos para la grilla
        DataTable dt = SPs.InsRecepcionInsumosH(finicio, ffin, dep, rub, ep).GetDataSet().Tables[0];
        gvPedidos.DataSource = dt;
        gvPedidos.DataBind();
    }

    protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[1].Text)
            {
                case "6":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado1.png";
                        hlE.ToolTip = "Estado Generado";
                    }
                    break;
                case "7":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado2.png";
                        hlE.ToolTip = "Estado Preparado Parcial";
                    }
                    break;
                case "8":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado3.png";
                        hlE.ToolTip = "Estado Preparado Total";
                    }
                    break;
                case "9":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado9.png";
                        hlE.ToolTip = "Estado Entregado";
                    }
                    break;
                case "10":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado5.png";
                        hlE.ToolTip = "Estado Canelado";
                    }
                    break;
                case "11":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado5.png";
                        hlE.ToolTip = "Estado Finalizado";
                    }
                    break;
            }
            //seteo lo q se mostrara segun el contenido
            if (e.Row.Cells[7].Text == "True")
            {
                e.Row.Cells[7].Text = "Autorizado";
                e.Row.Cells[7].ToolTip = "Pedido Autorizado y Enviado";
            }
            else
            {
                e.Row.Cells[7].Text = "No Autorizado";
                e.Row.Cells[7].ToolTip = "No Autorizado ni Enviado";
            }
            if ((e.Row.Cells[1].Text == "11") || (e.Row.Cells[1].Text == "5"))
            {
                e.Row.Cells[9].Text = "";
            }
            //else
            //{
            //    e.Row.Cells[9].Visible = true;
            //}
        }
    }
}
