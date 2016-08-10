using System;
using System.Data;
using System.IO;
using CrystalDecisions.Web;
using DalInsumos;
using CrystalDecisions.Shared;
using Salud.Security.SSO;


public partial class Recetas_InsumosPorPaciente : System.Web.UI.Page
{
    public CrystalReportSource oCr = new CrystalReportSource();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        oCr.Report.FileName = "";
        oCr.CacheDuration = 0;
        oCr.EnableCaching = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        txtFechaInicio.Text = "01/10/2013";
        txtFechaFin.Text = DateTime.Now.AddDays(30).ToShortDateString();
        lblMensaje.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFechaInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFechaFin.Text, out fin))
            ffin = fin;

        int idInsumo = Medicamento.getInsumo();
        //traigo los datos desde el store
        DataTable dt = SPs.InsConsumoMedxPaciente(idInsumo, idEfector, finicio, ffin).GetDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblMensaje.Text = "";
            lbImprimir.Visible = true;
        }
        else
        {
            lblMensaje.Text = "No existen Dispensaciones del Medicamento en la fecha seleccionada";
            lbImprimir.Visible = false;
        }
        gvPedidos.DataSource = dt;
        gvPedidos.DataBind();
    }

    protected void lbImprimir_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;
        SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        string informe = "ConsumoPorPacientes.rpt";

        //int efector = idEfector;
        int idInsumo = Medicamento.getInsumo();
        DateTime fechainicio = Convert.ToDateTime(txtFechaInicio.Text);
        DateTime fechafin = Convert.ToDateTime(txtFechaFin.Text);

        DataSet ds = CargarDatos(idInsumo, idEfector, fechainicio, fechafin);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);

        var paramValuesEfector = new ParameterValues();
        var paramEfector = new ParameterDiscreteValue();
        paramEfector.Value = efector.Nombre;
        paramValuesEfector.Add(paramEfector);

        var paramValuesFinicio = new ParameterValues();
        var paramFinicio = new ParameterDiscreteValue();
        paramFinicio.Value = Convert.ToDateTime(txtFechaInicio.Text).ToShortDateString();
        paramValuesFinicio.Add(paramFinicio);

        var paramValuesFfin = new ParameterValues();
        var paramFfin = new ParameterDiscreteValue();
        paramFfin.Value = Convert.ToDateTime(txtFechaFin.Text).ToShortDateString();
        paramValuesFfin.Add(paramFfin);

        oCr.ReportDocument.DataDefinition.ParameterFields["@nombreefector"].ApplyCurrentValues(paramValuesEfector);
        oCr.ReportDocument.DataDefinition.ParameterFields["@finicio"].ApplyCurrentValues(paramValuesFinicio);
        oCr.ReportDocument.DataDefinition.ParameterFields["@ffin"].ApplyCurrentValues(paramValuesFfin);

        oCr.DataBind();

        MemoryStream oStream;
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=ConsumoPorPacientes.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatos(int idInsumo, int efector, DateTime fechainicio, DateTime fechafin)
    {
        DataSet ds = new DataSet();
        DataTable dtConsumo = new DataTable("DSConsumoPorPaciente");

        DataSet x = SPs.InsConsumoMedxPaciente(idInsumo, efector, fechainicio, fechafin).GetDataSet();
        dtConsumo = x.Tables[0].Copy();
        dtConsumo.TableName = "DSConsumoPorPaciente";

        ds.Tables.Add(dtConsumo);

        return ds;
    }
}
