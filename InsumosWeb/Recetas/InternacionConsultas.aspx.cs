using System;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;
using Salud.Security.SSO;


public partial class Recetas_InternacionConsultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //CargarCombos();
        upRecetas.Visible = false;
    }

    //private void CargarCombos()
    //{
    //    SubSonic.Select tp = new SubSonic.Select();
    //    tp.From(InsTipoTratamiento.Schema);
    //    ddlTratamiento.DataSource = tp.ExecuteTypedList<InsTipoTratamiento>();
    //    ddlTratamiento.DataBind();
    //    ddlTratamiento.Items.Insert(0, new ListItem("Seleccionar ", "0"));
    //}

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        BuscarDatos();
    }

    protected void gvRecetas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRecetas.PageIndex = e.NewPageIndex;
        BuscarDatos();
    }

    private void BuscarDatos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;

        InsPrescripcionCollection pc = new Select()
                .From(InsPrescripcion.Schema)
                .Where(InsPrescripcion.Columns.IdTipoPrescripcion).IsEqualTo(2)
                .And(InsPrescripcion.Columns.Fecha).IsGreaterThanOrEqualTo(finicio)
                .And(InsPrescripcion.Columns.Fecha).IsLessThanOrEqualTo(ffin)
                .And(InsPrescripcion.Columns.IdEfector).IsEqualTo(idEfector)
                .OrderDesc("Fecha")
                .ExecuteAsCollection<InsPrescripcionCollection>();

        upRecetas.Visible = true;
        gvRecetas.DataSource = pc;
        gvRecetas.DataBind();
    }
}
