using System;
using System.Data;
using DalInsumos;
using CrystalDecisions.Web;
using System.IO;

public partial class Recetas_VerDispensaRapida : System.Web.UI.Page
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
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarReceta(id);
        }
    }

    private void CargarReceta(int id)
    {
        InsPrescripcion p = new InsPrescripcion(id);
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblPrescripcion.Text = p.InsTipoPrescripcion.Nombre;
        lblDocumento.Text = p.SysPaciente.NumeroDocumento.ToString();
        lblPaciente.Text = p.SysPaciente.Apellido + ", " + p.SysPaciente.Nombre;
        lblFechaNac.Text = Convert.ToDateTime(p.SysPaciente.FechaNacimiento).ToShortDateString();
        lblSexo.Text = p.SysPaciente.SysSexo.Nombre;
        if ((p.Edad > 0) & (p.Edad < 100)) lblEdad.Text = p.Edad.ToString() + " Años";
        else lblEdad.Text = "-";
        lblObservaciones.Text = p.Observaciones;
        if (p.IdProfesional > 0)
            lblProfesional.Text = p.SysProfesional.NombreCompleto;
        else lblProfesional.Text = "--";
        //detalle de la receta        
        gvReceta.DataSource = p.InsPrescripcionDetalleRecords;
        gvReceta.DataBind();
        //debria filtar por tipoTratamiento: cronico o no, si es cronico y
        //tiene fecha de prosima dispensacion calcular la deuda y luego mostrarla en la grilla del cronico
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        InsPrescripcion p = new InsPrescripcion(id);
        //Response.Redirect("Default.aspx?id=" + p.IdPrescripcion + "&idD=" + pd.IdPrescripcionDetalle + "&idP=" + pac.IdPaciente.ToString());
        Response.Redirect("DispensaRapida.aspx?id=" + p.IdPrescripcion);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("DispensaRapida.aspx", false);
    }

    protected void lbTicket_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPrescripcion p = new InsPrescripcion(id);
        Exportar(id);
    }

    protected void lbCronico_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPrescripcion p = new InsPrescripcion(id);
        ExportarCronico(id);
    }

    private void Exportar(int id)
    {
        string informe = "Recetas.rpt";

        DataSet ds = CargarDatos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);
        oCr.DataBind();

        MemoryStream oStream;
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=Receta.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private void ExportarCronico(int id)
    {
        string informe = "RecetaCronico.rpt";

        DataSet ds = CargarDatos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);
        oCr.DataBind();

        MemoryStream oStream;
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=RecetaCronico.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatos(int id)
    {
        DataSet ds = new DataSet();
        DataTable dtReceta = new DataTable("DSReceta");
        DataTable dtRecetaDetalle = new DataTable("DSRDetalle");
        DataSet x = SPs.InsGetPrescripcion(id).GetDataSet();

        dtReceta = x.Tables[0].Copy();
        dtRecetaDetalle = x.Tables[1].Copy();

        dtReceta.TableName = "DSReceta";
        dtRecetaDetalle.TableName = "DSRDetalle";

        ds.Tables.Add(dtReceta);
        ds.Tables.Add(dtRecetaDetalle);

        return ds;
    }
}
