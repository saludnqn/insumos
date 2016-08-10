using System;
using System.Data;
using System.IO;
using CrystalDecisions.Web;
using DalInsumos;
using CrystalDecisions.Shared;
using Salud.Security.SSO;


public partial class Recetas_ConsultasAmbulatorias : System.Web.UI.Page
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
        txtFecha.Text = DateTime.Now.AddHours(1).ToShortDateString();
        lblMensaje.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string fullname = SSOHelper.CurrentIdentity.Fullname;

        DateTime fecha = Convert.ToDateTime(txtFecha.Text);
        DateTime fecha2;
        if (DateTime.TryParse(txtFecha.Text, out fecha2))
            fecha = fecha2;
        //traigo los datos desde el store
        DataTable dt = SPs.InsGetListadoAmbulatorias(fecha).GetDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblMensaje.Text = "";
            lblArea.Text = "Area: " + dt.Rows[0][0].ToString();
            lblServicio.Text = "Servicio: " + dt.Rows[0][1].ToString();
            lbImprimir.Visible = true;
        }
        else
        {
            lblMensaje.Text = "No se realizaron dispensaciones Ambulatorias en la fecha seleccionda";
            lblArea.Text = "";
            lblServicio.Text = "";
            lbImprimir.Visible = false;
        }

        gvAmbulatorio.DataSource = dt;
        gvAmbulatorio.DataBind();
        lblUsuario.Text = "Emitido por: " + fullname;
    }

    protected void lbImprimir_Click(object sender, EventArgs e)
    {
        string fullname = SSOHelper.CurrentIdentity.Fullname;
        SysEfector efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

        string informe = "ListadoAmbulatorio.rpt";

        DateTime fecha = Convert.ToDateTime(txtFecha.Text);

        DataSet ds = CargarDatos(fecha);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);

        var paramValuesEfector = new ParameterValues();
        var paramEfector = new ParameterDiscreteValue();
        paramEfector.Value = efector.Nombre;
        paramValuesEfector.Add(paramEfector);

        var paramValuesUsuario = new ParameterValues();
        var paramUsuario = new ParameterDiscreteValue();
        paramUsuario.Value = fullname;
        paramValuesUsuario.Add(paramUsuario);

        oCr.ReportDocument.DataDefinition.ParameterFields["@nombreefector"].ApplyCurrentValues(paramValuesEfector);
        oCr.ReportDocument.DataDefinition.ParameterFields["@nombreusuario"].ApplyCurrentValues(paramValuesUsuario);

        oCr.DataBind();

        MemoryStream oStream;
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=ListadoAmbulatorio.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatos(DateTime fecha)
    {
        DataSet ds = new DataSet();
        DataTable dtReceta = new DataTable("DSListadoAmbulatorio");

        DataSet x = SPs.InsGetListadoAmbulatorias(fecha).GetDataSet();
        dtReceta = x.Tables[0].Copy();
        dtReceta.TableName = "DSListadoAmbulatorio";

        ds.Tables.Add(dtReceta);

        return ds;
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Editar.aspx", false);
    }
}
