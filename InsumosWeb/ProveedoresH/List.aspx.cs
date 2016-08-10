using System;
using System.Web.UI.WebControls;
using DalInsumos;
using Salud.Security.SSO;


public partial class ProveedoresH_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        btnBuscar_Click();
    }

    
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void btnBuscar_Click()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        //DateTime fecha1 = Convert.ToDateTime(txtFInicio.Text);
        //DateTime fecha2 = Convert.ToDateTime(txtFFin.Text);
        string codigo = txtCodigo.Text;
        string nombre = txtNombre.Text;

        SubSonic.Select p = new SubSonic.Select();
        p.From(InsProveedor.Schema);
        //p.Where(InsProveedor.Columns.IdEfector).IsEqualTo(idEfector); //efector del usuario
        p.Where(InsProveedor.Columns.Baja).IsEqualTo(0);
        p.And(InsProveedor.Columns.Codigo).IsNotEqualTo(0);
        p.OrderAsc("nombre");
        //p.And(InsProveedor.Columns.Codigo).Like(string.Format("%{0}%", codigo));
        //p.And(InsProveedor.Columns.Nombre).Like(string.Format("%{0}%", nombre));
        //p.And(InsProveedor.Columns.CreatedOn).IsGreaterThanOrEqualTo(fecha1);
        //p.And(InsProveedor.Columns.CreatedOn).IsLessThanOrEqualTo(fecha2);

        gvProveedores.DataSource = p.ExecuteTypedList<InsProveedor>();
        gvProveedores.DataBind();
    }

    protected void gvProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //seteo lo q se mostrara segun el contenido
            if (e.Row.Cells[8].Text == "True")
            {
                e.Row.Cells[8].Text = "Si";
                e.Row.Cells[8].ToolTip = "Proveedor No Activo";
            }
            else
            {
                e.Row.Cells[8].Text = "No";
                e.Row.Cells[8].ToolTip = "Proveedor Activo";
            }
        }
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }

}
