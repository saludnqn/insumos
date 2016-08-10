using System;
using DalInsumos;
using System.Web.UI.WebControls;

public partial class Recetas_PacienteCronico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idP = SubSonic.Sugar.Web.QueryString<int>("idPaciente");
        if (idP > 0)
        {
            string ambulatorio = SubSonic.Sugar.Web.QueryString<string>("ambulatorio");
            if (ambulatorio == "si")
            {
                CargarRecetaAmbulatoria(idP);
            }
            string internado = SubSonic.Sugar.Web.QueryString<string>("internado");
            if (internado == "si")
            {
                CargarRecetaInternado(idP);
            }
        }
    }

    private void CargarRecetaAmbulatoria(int idPaciente)
    {
        SubSonic.Select qi = new SubSonic.Select(new string[] { "idPrescripcion, idTipoPrescripcion, idTipoTratamiento, fecha, idProfesional, idCODCie10" });
        qi.From(InsPrescripcion.Schema);
        qi.Where(InsPrescripcion.IdPacienteColumn).IsEqualTo(idPaciente);
        qi.And(InsPrescripcion.IdTipoPrescripcionColumn).IsEqualTo(1);
        // qi.And(InsPrescripcion.IdTipoTratamientoColumn).IsEqualTo(2);

        gvRecetasCronicas.DataSource = qi.ExecuteTypedList<InsPrescripcion>();
        gvRecetasCronicas.DataBind();
    }

    private void CargarRecetaInternado(int idPaciente)
    {
        SubSonic.Select qi = new SubSonic.Select(new string[] { "idPrescripcion, idTipoPrescripcion, idTipoTratamiento, fecha, idProfesional, idCODCie10" });
        qi.From(InsPrescripcion.Schema);
        qi.Where(InsPrescripcion.IdPacienteColumn).IsEqualTo(idPaciente);
        qi.And(InsPrescripcion.IdTipoPrescripcionColumn).IsEqualTo(2);
        qi.And(InsPrescripcion.IdTipoTratamientoColumn).IsEqualTo(3);

        gvRecetasCronicas.DataSource = qi.ExecuteTypedList<InsPrescripcion>();
        gvRecetasCronicas.DataBind();
    }

    protected void gvRecetasCronicas_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //debo setear las columnas a mostrar: 6 y 7 / 8 y 9
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTipoPrescripcion = (Label)e.Row.FindControl("lblTipoPrescripcion");
            if (lblTipoPrescripcion.Text == "1")
            {
                HyperLink verra = (HyperLink)e.Row.FindControl("verra");
                verra.Visible = true;
                HyperLink edra = (HyperLink)e.Row.FindControl("edra");
                edra.Visible = true;
                HyperLink verri = (HyperLink)e.Row.FindControl("verri");
                verri.Visible = false;
                HyperLink edri = (HyperLink)e.Row.FindControl("edri");
                edri.Visible = false;
            }
            if (lblTipoPrescripcion.Text == "2")
            {
                HyperLink verra = (HyperLink)e.Row.FindControl("verra");
                verra.Visible = false;
                HyperLink edra = (HyperLink)e.Row.FindControl("edra");
                edra.Visible = false;
                HyperLink verri = (HyperLink)e.Row.FindControl("verri");
                verri.Visible = true;
                HyperLink edri = (HyperLink)e.Row.FindControl("edri");
                edri.Visible = true;
            }
        }
    }
}
