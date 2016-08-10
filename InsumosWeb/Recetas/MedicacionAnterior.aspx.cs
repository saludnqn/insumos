using System;
using System.Data;
using DalInsumos;
using Salud.Security.SSO;

public partial class Recetas_MedicacionAnterior : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idPaciente = SubSonic.Sugar.Web.QueryString<int>("idPaciente");
        txtFInicio.Text = DateTime.Now.AddDays(-31).ToShortDateString();
        txtFFin.Text = DateTime.Now.ToShortDateString();
        hdfIdPaciente.Value = idPaciente.ToString();
        if (idPaciente > 0)
        {            
            CargarPaciente(idPaciente);
            CargarMedicacion(idPaciente);
        }
        else return;

    }

    private void CargarPaciente(int idPaciente)
    {
        SysPaciente p = new SysPaciente(idPaciente);
        lblPaciente.Text = p.NumeroDocumento.ToString() + " - " + p.Apellido + ", " + p.Nombre;
        txtDoc.Text = p.NumeroDocumento.ToString();
        lblSexo.Text = "Sexo:" + p.SysSexo.Nombre;
        lblOSocial.Text = p.SysObraSocial.Nombre;
        lblFechaNac.Text = Convert.ToDateTime(p.FechaNacimiento).ToShortDateString();
    }

    private void CargarMedicacion(int idPaciente)
    {
        //por ahora toda la medicacion entregada al paciente
        DateTime finicio = DateTime.Now.AddDays(-31);
        DateTime ffin = DateTime.Now;
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        DataTable ds = SPs.InsGetMedicacionAnterior(idPaciente, finicio, ffin).GetDataSet().Tables[0];
        gvMedicacion.DataSource = ds;
        gvMedicacion.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarMedicacion(int.Parse(hdfIdPaciente.Value));
    }

    protected void btnAsignaPaciente_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        if (txtDoc.Text.Length > 0)
        {
            int doc = Convert.ToInt32(txtDoc.Text);
            DataTable dt = DalInsumos.SPs.InsGetPacientes(doc).GetDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                hfIdPaciente.Value = dt.Rows[0][0].ToString();
                lblPaciente.Text = dt.Rows[0][1].ToString();
                lblSexo.Text = "Sexo: " + dt.Rows[0][3].ToString();                
                lblFechaNac.Text = dt.Rows[0][5].ToString();
                lblOSocial.Text = dt.Rows[0][7].ToString();
                CargarMedicacion(int.Parse(hdfIdPaciente.Value));
            }
            else
            {
                lblMensaje.Text = "No se encuentra al paciente buscado";
            }
        }
        else
        {
            lblMensaje.Text = "El número ingresado no es válido";
        }
    }
    protected void hkOtraBusqueda_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recetas/BuscarPaciente.aspx");
    }

}
