using System;
using System.Web.UI;
using DalInsumos;
using System.Data;


public partial class Insumos_ConsultaAsociados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idInsumo = SubSonic.Sugar.Web.QueryString<int>("idInsumo");
        if (idInsumo > 0)
        {
            CargarAsociados(idInsumo);
        }
    }

    private void CargarAsociados(int idInsumo)
    {
        if (idInsumo > 0)
        {
            idAsociados.Visible = true;
            InsInsumo oIns = new InsInsumo(idInsumo);
            Insumo1.setIns(idInsumo);

            SubSonic.Select s = new SubSonic.Select("idAsociacion", "idInsumoOrigen", "idInsumoEquivalente", "fechaAsociacion");
            s.From(InsInsumosEquivalente.Schema);
            s.InnerJoin(InsInsumo.Schema);
            s.Where(InsInsumosEquivalente.Columns.IdInsumoOrigen).IsEqualTo(idInsumo);

            gvMedicamentosAsociados.DataSource = s.ExecuteAsCollection<InsInsumosEquivalenteCollection>();
            gvMedicamentosAsociados.DataBind();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int Insumo = Insumo1.getInsumo();
        CargarAsociados(Insumo);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("AsociaMedicamentos.aspx", false);
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}