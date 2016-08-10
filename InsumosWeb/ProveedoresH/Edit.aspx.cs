using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class ProveedoresH_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombo();
        //idProveedor para edicion
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarProveedor(id);
        }
    }

    private void CargarProveedor(int id)
    {
        //cargo un proveedor existente
        InsProveedor pro = new InsProveedor(id);
        if (!pro.IsNew)
        {
            txtCodigo.Text = pro.Codigo;
            txtNombre.Text = pro.Nombre;
            txtDescripcion.Text = pro.Descripcion;
            txtCuit.Text = pro.Cuit;
            txtDomicilio.Text = pro.Domicilio;
            txtTelefono.Text = pro.Telefono;
            ddlTProveedor.SelectedValue = pro.IdTipoProveedor.ToString();
            txtCorreo.Text = pro.Email;
            txtObservaciones.Text = pro.Observaciones;
        }
    }

    private void CargarCombo()
    {
        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoProveedor.Schema);
        ddlTProveedor.DataSource = tp.ExecuteTypedList<InsTipoProveedor>();
        ddlTProveedor.DataBind();
        ddlTProveedor.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        // Page.Validate("1");
        if (DatosValidos(id)) //&& (Page.IsValid))
        {
            InsProveedor pr = new InsProveedor(id);
            pr.IdEfector = idEfector;
            pr.Codigo = txtCodigo.Text;
            pr.Nombre = txtNombre.Text;
            pr.Descripcion = txtDescripcion.Text;
            pr.Domicilio = txtDomicilio.Text;
            pr.Cuit = txtCuit.Text;
            pr.Email = txtCorreo.Text;
            pr.IdTipoProveedor = Convert.ToInt32(ddlTProveedor.SelectedValue);
            pr.Telefono = txtTelefono.Text;
            pr.Observaciones = txtObservaciones.Text;
            pr.Baja = false;
            pr.Save(username);
            Response.Redirect("View.aspx?id=" + pr.IdProveedor.ToString());
        }
    }

    private bool DatosValidos(int id)
    {
        lblMensaje.Text = string.Empty;

        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string codigo = txtCodigo.Text;

        SubSonic.Select p = new SubSonic.Select();
        p.From(InsProveedor.Schema);
        p.Where(InsProveedor.Columns.Codigo).IsNotEqualTo(0);
        p.And(InsProveedor.Columns.Codigo).IsEqualTo(codigo);
        //p.And(InsProveedor.Columns.IdEfector).IsEqualTo(idEfector); //proveedores del efector
        DataTable dtd = p.ExecuteDataSet().Tables[0];

        if (dtd.Rows.Count > 1)
        {
            lblMensaje.Text = "El código del proveedor ya existe.";
        }

        if (lblMensaje.Text == string.Empty)
        {
            return true;
        }
        return false;
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}
