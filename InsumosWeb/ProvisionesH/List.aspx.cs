using System;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using Salud.Security.SSO;


public partial class ProvisionesH_List : System.Web.UI.Page
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
        SubSonic.Select pr = new SubSonic.Select();
        pr.From(InsProveedor.Schema);
        pr.OrderAsc("Nombre");
        ddlProveedor.DataSource = pr.ExecuteTypedList<InsProveedor>();
        ddlProveedor.DataBind();
        ddlProveedor.Items.Insert(0, new ListItem("Todos", "0"));

        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoPedido.Schema);
        tp.Where(InsTipoPedido.Columns.IdTipoMovimiento).IsEqualTo(1);
        tp.OrderAsc("Nombre");
        ddlTipoPedido.DataSource = tp.ExecuteTypedList<InsTipoPedido>();
        ddlTipoPedido.DataBind();
        ddlTipoPedido.Items.Insert(0, new ListItem("Todos", "0"));

        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector por defecto del usuario
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);                
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
    }

    private void Buscar()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = DateTime.Now.AddDays(-31);
        DateTime ffin = DateTime.Now;
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        int proveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
        int tipoPedido = Convert.ToInt32(ddlTipoPedido.SelectedValue);
        int deposito = Convert.ToInt32(ddlDeposito.SelectedValue);

        DataTable dt = SPs.InsGetConsultasProvisionesH(finicio, ffin, tipoPedido, proveedor, idEfector, 1, deposito).GetDataSet().Tables[0];

        gvProvisiones.DataSource = dt;
        gvProvisiones.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Buscar();
    }

    protected void gvProvisiones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (e.Row.Cells[6].Text == "True")
            //{
            //    e.Row.Cells[6].Text = "Activo";
            //    e.Row.Cells[6].ToolTip = "Provisión ingresada y habilitada.";
            //}
            //else
            //{
            //    e.Row.Cells[6].Text = "Inactivo";
            //    e.Row.Cells[6].ToolTip = "Provisión NO Habilitada.";
            //}
            //if (e.Row.Cells[5].Text != "Finalizado")
            //{
            //    e.Row.Cells[8].Visible = true;
            //    e.Row.Cells[8].ToolTip = "Editar el Suministro o Provisión";
            //}
            //else
            //{
            //    e.Row.Cells[8].Visible = false;
            //}
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}
