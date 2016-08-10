using System;
using DalInsumos;
using System.Web.UI.WebControls;
using Salud.Security.SSO;


public partial class DepositosH_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarCombos();
        }
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        
        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector);
        d.And(InsDeposito.Columns.IdDepositoSuperior).IsEqualTo(0);
        d.And(InsDeposito.Columns.Baja).IsEqualTo(false);
        d.OrderAsc("nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        buscarDatos();
    }

    private void buscarDatos()
    {
        lblMensaje.Text = "";
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int deposito = Convert.ToInt32(ddlDeposito.SelectedValue);


        SubSonic.Select dep = new SubSonic.Select();
        dep.From(InsDeposito.Schema);
        //dep.InnerJoin(InsTipoDeposito.Schema);
        dep.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector);
        dep.And(InsDeposito.Columns.IdDepositoSuperior).IsEqualTo(deposito);        
        //dep.And(InsDeposito.Columns.Baja).IsEqualTo(false);

        GridView1.DataSource = dep.ExecuteTypedList<InsDeposito>();
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int efector = SSOHelper.CurrentIdentity.IdEfector;           
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int idP = Convert.ToInt32(e.Row.Cells[1].Text);
            GridView gv = (GridView)e.Row.FindControl("GridView2");

            SubSonic.Select sdep = new SubSonic.Select();
            sdep.From(InsDeposito.Schema);
            //sdep.InnerJoin(InsTipoDeposito.Schema);
            sdep.Where(InsDeposito.Columns.IdEfector).IsEqualTo(efector);
            sdep.And(InsDeposito.Columns.IdDepositoSuperior).IsEqualTo(idP);
            //sdep.And(InsDeposito.Columns.Baja).IsEqualTo(false);

            gv.DataSource = sdep.ExecuteTypedList<InsDeposito>();
            gv.DataBind();

            if (e.Row.Cells[6].Text == "True")
            {
                e.Row.Cells[6].Text = "BAJA";
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F8FF");
                e.Row.Cells[6].ToolTip = "El depósito fue dado de baja.";
            }
            else
                e.Row.Cells[6].Text = "ACTIVO";
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        buscarDatos();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text == "True")
            {
                e.Row.Cells[6].Text = "BAJA";
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F8FF");     
                e.Row.Cells[6].ToolTip = "El depósito fue dado de baja.";
            }
            else
                e.Row.Cells[6].Text = "ACTIVO";
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        string url = "Edit.aspx?id=" + ddlDeposito.SelectedValue;
        
        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=1000,height=800,scrollbars=yes,top=80, left=80');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }
}
