using System;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using Salud.Security.SSO;


public partial class ProvisionesH_InternosRecepcion : System.Web.UI.Page
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
        //ddlDepositoOrigen.Items.Insert(0, new ListItem("TODOS", "0"));
        //deposito proveedor
        ddlDepositoProveedor.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDepositoProveedor.DataBind();
        ddlDepositoProveedor.Items.Insert(0, new ListItem("(Todos)", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(362);
        //r.And(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("(Todos)", "0"));

        /* SubSonic.Select ep = new Select();
         ep.From(InsEstadoPedido.Schema);
         ep.Where(InsEstadoPedido.Columns.Interno).IsEqualTo(1);
         ddlEstado.DataSource = ep.ExecuteTypedList<InsEstadoPedido>();
         ddlEstado.DataBind();
         ddlEstado.Items.Insert(0, new ListItem("TODOS", "0"));*/
    }

    protected void ddlDeposito_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dep = Convert.ToInt32(ddlDepositoProveedor.SelectedValue);

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.Where(InsRubro.Columns.Padre).IsNull();
        //r.And(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
       // ddlRubro.Items.Insert(0, new ListItem("Seleccionar", "0"));
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
        int depSol = Convert.ToInt32(ddlDepositoSolicitante.SelectedValue);
        int depPro = Convert.ToInt32(ddlDepositoProveedor.SelectedValue);
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);
        //int ep = Convert.ToInt32(ddlEstado.SelectedValue);
        //consulta de datos para la grilla
        DataTable dt = SPs.InsRecepcionInternaInsumos(finicio, ffin, depSol, depPro, rub, idEfector).GetDataSet().Tables[0];
        gvPedidos.DataSource = dt;
        gvPedidos.DataBind();
    }

    protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[1].Text)
            {
                case "9":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/images/EnTransporte.png";
                        hlE.ToolTip = "ENTREGADO";
                    }
                    break;
            }
        }   
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}
