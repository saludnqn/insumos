using System;
using DalInsumos;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Recetas_BuscarPaciente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtApellido.Focus();
            limpiarControles();
        }
    }

    private void limpiarControles()
    {
        txtApellido.Text = "";
        txtNombre.Text = "";
        gvPacientes.DataSource = null;
        gvPacientes.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        if ((string.IsNullOrEmpty(txtApellido.Text)) && (string.IsNullOrEmpty(txtNombre.Text)))
        {
            lblMensaje.Text = "Debe ingresar un Apellido y/o Nombre válido.";
            return;
        }
        else
        {
            if ((txtApellido.Text != null) || (txtNombre.Text != null))
            {
                //buscar = String.IsNullOrEmpty(txtApellido.Text) ? "" : txtApellido.Text; 
                SubSonic.Select p = new SubSonic.Select("idPaciente", "apellido", "nombre", "numeroDocumento", "fechaNacimiento", "idSexo");
                p.From(SysPaciente.Schema);
                p.InnerJoin(SysSexo.Schema);
                p.Where(SysPaciente.Columns.Apellido).Like(String.Format("%{0}%", txtApellido.Text));
                p.And(SysPaciente.Columns.Nombre).Like(String.Format("%{0}%", txtNombre.Text));
                p.And(SysPaciente.Columns.Activo).IsEqualTo(true);
                p.OrderAsc("Apellido");

                gvPacientes.DataSource = p.ExecuteTypedList<SysPaciente>();
                gvPacientes.DataBind();
            }
            else
            {
                lblMensaje.Text = "Debe ingresar un Apellido y/o Nombre válido.";
                return;
            }
        }
    }
    protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        btnBuscar_Click(null, null);
        gvPacientes.PageIndex = e.NewPageIndex;
        gvPacientes.DataBind();
    }
}
