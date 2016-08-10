using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;

public partial class Proveedores_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombos();
    }

    private void CargarCombos()
    {
        SubSonic.Select ef = new SubSonic.Select();
        ef.From(SysEfector.Schema);
        ef.Where(SysEfector.Columns.Complejidad).IsGreaterThan(Convert.ToInt32("2"));// o el del usuario??
        ef.Or(SysEfector.Columns.IdEfectorSuperior).IsEqualTo(227);
        ef.OrderAsc("Nombre");
        ddlEfector.DataSource = ef.ExecuteTypedList<SysEfector>();
        ddlEfector.DataBind();
        ddlEfector.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ef = Convert.ToInt32(ddlEfector.SelectedValue);
        SubSonic.Select p = new SubSonic.Select();
        p.From(InsProveedor.Schema);
        p.Where(InsProveedor.Columns.Baja).IsEqualTo(0);
        
        //p.And(InsProveedor.Columns.IdEfector).IsEqualTo(ef);

        gvProveedores.DataSource = p.ExecuteTypedList<InsProveedor>();
        gvProveedores.DataBind();
    }
}
