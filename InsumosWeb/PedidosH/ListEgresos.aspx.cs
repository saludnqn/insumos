using System;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using Salud.Security.SSO;


public partial class ProvisionesH_ListEgresos : System.Web.UI.Page
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
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        //ddlProveedor.Items.Insert(0, new ListItem("Todos", "0"));

        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoPedido.Schema);
        tp.Where(InsTipoPedido.Columns.IdTipoMovimiento).IsEqualTo(2);
        tp.OrderAsc("Nombre");
        dllTipoPedido.DataSource = tp.ExecuteTypedList<InsTipoPedido>();
        dllTipoPedido.DataBind();
        dllTipoPedido.Items.Insert(0, new ListItem("Todos", "0"));
    }

    private void Buscar()
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
        //int proveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
        int proveedor = 0;
        int tipoPedido = Convert.ToInt32(dllTipoPedido.SelectedValue);
        int deposito = Convert.ToInt32(ddlDeposito.SelectedValue);

        DataTable dt = SPs.InsGetConsultasProvisionesH(finicio, ffin, tipoPedido, proveedor, idEfector,2, deposito).GetDataSet().Tables[0];

        gvProvisiones.DataSource = dt;
        gvProvisiones.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Buscar();
    }

    protected void gvProvisiones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string efector = "HOSPITAL DE AREA CENTENARIO - DR. NATALIO BURD";
        string depo = ddlDeposito.SelectedItem.Text;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[0].Text != depo)
            {
                e.Row.Cells[4].Text = e.Row.Cells[0].Text;                
            }
            e.Row.Cells[0].Text = "";

            if (e.Row.Cells[5].Text != efector)
            {
                e.Row.Cells[4].Text = e.Row.Cells[5].Text;
            }
            e.Row.Cells[5].Text = "";

            if (e.Row.Cells[3].Text == "Receta Ambulatoria" || e.Row.Cells[3].Text == "Receta Remediar")
            {
                e.Row.Cells[4].Text = e.Row.Cells[8].Text;
            }
            e.Row.Cells[8].Text = "";
            //else
            //    e.Row.Cells[3].Text = "";
            
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
