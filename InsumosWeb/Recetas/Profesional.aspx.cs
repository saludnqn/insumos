using System;
using DalInsumos;
using System.Data;

public partial class Recetas_Profesional : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idProf = SubSonic.Sugar.Web.QueryString<int>("idProf");
        if (idProf > 0)
        {
            CargarProfesional(idProf);
        }
    }

    private void CargarProfesional(int idProf)
    {
        //muestro datos de los profesionales en los centros de salud
        SubSonic.Select p = new SubSonic.Select("numeroDocumento");
        p.From(SysProfesional.Schema);
        p.Where(SysProfesional.Columns.IdProfesional).IsEqualTo(idProf);
        
        DataTable dt = p.ExecuteDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            int dniProf = Convert.ToInt32(dt.Rows[0][0]);

            DataTable dtp = SPs.SysGetProfesionalesByEfector(0, dniProf).GetDataSet().Tables[0];
            if (dtp.Rows.Count > 0)
            {
                gvProfesional.DataSource = dtp;
                gvProfesional.DataBind();
            }
            else
            {
                lblMensaje.Text = "El Profesional no está asociado a ningun Efector.";
            }
        } else
            lblMensaje.Text = "El Profesional no registrado en el Sips.";
    }
}
