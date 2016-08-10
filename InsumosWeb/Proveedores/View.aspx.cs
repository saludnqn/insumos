using System;
using DalInsumos;

public partial class Proveedores_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarProveedor(id);
        }
    }

    private void CargarProveedor(int id)
    {
       InsProveedor p = new InsProveedor(id);
        if (!p.IsNew)
        {
            lblCodigo.Text = p.Codigo;
            lblNombre.Text = p.Nombre;
            lblDescripcion.Text = p.Descripcion;
            lblCuit.Text = p.Cuit;
            lblDomicilio.Text = p.Domicilio;
            lblTelefono.Text = p.Telefono;
            lblTProveedor.Text = p.InsTipoProveedor.Nombre;
            lblCorreoE.Text = p.Email;
            lblObservaciones.Text = p.Observaciones;
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id == 0) Response.Redirect("Edit.aspx");
        else
        {
            Response.Redirect("Edit.aspx?id=" + id.ToString());
        }
    }
}
