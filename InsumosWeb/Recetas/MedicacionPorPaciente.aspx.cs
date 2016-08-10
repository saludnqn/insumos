using System;
using System.Data;
using DalInsumos;

public partial class Recetas_MedicacionPorPaciente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        txtDoc.Focus();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtDoc.Text.Length > 0)
        {
            int doc = Convert.ToInt32(txtDoc.Text);
            DataTable dt = DalInsumos.SPs.InsGetPacientes(doc).GetDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {                
                lblPaciente.Text = dt.Rows[0][1].ToString();                
                hfIdPaciente.Value = dt.Rows[0][0].ToString();
                
            }
            else
            {
                lblMensaje.Text = "El Paciente buscado no esta ingresado";
            }
        }
        else
        {
            lblMensaje.Text = "Debe ingresar un número de Documento válido";
        }
    }
}