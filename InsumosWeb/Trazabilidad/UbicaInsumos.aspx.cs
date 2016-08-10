using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class Trazabilidad_UbicaInsumos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
            gvInsumos.DataBind();
            CargarCombo();
    }

    private void CargarCombo()
    {
        SubSonic.Select e = new SubSonic.Select();
        e.From(SysEfector.Schema);
        e.Where(SysEfector.Columns.IdZona).IsEqualTo(9);
        e.OrderAsc("Nombre");
        
        ddlEfector.DataSource = e.ExecuteTypedList<SysEfector>();

        ddlEfector.DataBind();
        ddlEfector.Items.Insert(0, new ListItem("Todos >>", "0"));
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //int efector = Convert.ToInt32(ddlEfector.SelectedValue);
        int efector = SSOHelper.CurrentIdentity.IdEfector;

        int codigo = Insumo.getInsumo();

        DataSet dt = SPs.InsGetUInsumos(efector, codigo).GetDataSet();

        gvInsumos.DataSource = dt;
        gvInsumos.DataBind();
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}
