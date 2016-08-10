using System;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using CrystalDecisions.Web;
using System.IO;

public partial class Dispensaciones_View : System.Web.UI.Page
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
            CargarDispensacion(id);
        }
    }

    private void CargarDispensacion(int id)
    {
        InsDispensacion d = new InsDispensacion(id);
        lblFecha.Text = Convert.ToDateTime(d.Fecha).ToShortDateString();
        lblPrescripcion.Text = d.InsTipoPrescripcion.Nombre;
        lblDocumento.Text = d.SysPaciente.NumeroDocumento.ToString();
        lblPaciente.Text = d.SysPaciente.Apellido + ", " + d.SysPaciente.Nombre;
        lblFechaNac.Text = Convert.ToDateTime(d.SysPaciente.FechaNacimiento).ToShortDateString();
        lblSexo.Text = d.SysPaciente.SysSexo.Nombre;
        if ((d.Edad > 0) & (d.Edad < 100)) lblEdad.Text = d.Edad.ToString() + " Años";
        else lblEdad.Text = "-";
        if (d.SysPaciente.SysObraSocial.Nombre == "SELECCIONAR")
            lblOSocial.Text = "--";
        else lblOSocial.Text = d.SysPaciente.SysObraSocial.Nombre;
        lblTratamiento.Text = d.InsTipoTratamiento.Nombre;
        lblDuracion.Text = d.Duracion.ToString();
        lblUnidadDuracion.Text = d.UnidadDuracion;
        if (d.IdTipoPrescripcion ==1)
        {
            gvReceta.Columns[4].Visible = true;  //dosis diaria
            gvReceta.Columns[5].Visible = true;  //unidad dosis
            gvReceta.Columns[6].Visible = false;
            gvReceta.Columns[7].Visible = false;
            gvReceta.Columns[8].Visible = true;     //entregado
            //gvReceta.Columns[9].Visible = false;     //deuda            
        }
        if (d.IdTipoTratamiento == 2)
        {
            upCronico.Visible = true;                        
        }
        if (d.IdCODCie10 > 0)
            lblDiagnostico.Text = d.SysCIE10.Codigo + "-" + d.SysCIE10.Nombre; //cartel de no tiene diag
        else lblDiagnostico.Text = "--";
        lblObservaciones.Text = d.Observaciones;
        if (d.IdProfesional > 0)
            lblProfesional.Text = d.SysProfesional.NombreCompleto;
        else lblProfesional.Text = "--";
        //detalle de la receta        
        gvReceta.DataSource = d.InsDispensacionDetalleRecords;
        gvReceta.DataBind();
        //debria filtar por tipoTratamiento: cronico o no, si es cronico y
        //tiene fecha de prosima dispensacion calcular la deuda y luego mostrarla en la grilla del cronico
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        InsDispensacion d = new InsDispensacion(id);
        //Response.Redirect("Default.aspx?id=" + p.IdPrescripcion + "&idD=" + pd.IdPrescripcionDetalle + "&idP=" + pac.IdPaciente.ToString());
        Response.Redirect("View.aspx?id=" + d.IdDispensacion);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void gvReceta_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsDispensacionDetalle dd = (InsDispensacionDetalle)e.Row.DataItem;

            Label lblSolicitado = (Label)e.Row.FindControl("lblSolicitado");
            dd.CantidadSolicitada = Convert.ToInt32(lblSolicitado.Text);

            Label lblEntregado = (Label)e.Row.FindControl("lblEntregado");
            dd.CantidadEmitida = Convert.ToInt32(lblEntregado.Text);

            //Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            //if (dd.CantidadEmitida > 0 && dd.CantidadSolicitada > 0)
            //{
            //    //debería buscar entregas anteriores                
            //    int deuda = Convert.ToInt32(dd.CantidadSolicitada - dd.CantidadEmitida);                
            //    lblDeuda.Text = deuda.ToString();
            //}
            //else
            //{ 
            //    lblDeuda.Text = "0";
            //}
        }
    }

    protected void lbTicket_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        //InsDispensacion d = new InsDispensacion(id);
        Exportar(id);
    }

    protected void lbCronico_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        //InsDispensacion p = new InsDispensacion(id);
        ExportarCronico(id);
    }

    private void Exportar(int id)
    {
        string informe = "Dispensacion.rpt";

        DataSet ds = CargarDatos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);
        oCr.DataBind();

        MemoryStream oStream;
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=Dispensacion.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private void ExportarCronico(int id)
    {
        string informe = "DispensacionCronico.rpt";

        DataSet ds = CargarDatos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);
        oCr.DataBind();

        MemoryStream oStream;
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=DispensacionCronico.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatos(int id)
    {
        DataSet ds = new DataSet();
        DataTable dtDispensacion = new DataTable("DSDispensacion");
        DataTable dtDispensacionDetalle = new DataTable("DSDDetalle");
        DataSet x = SPs.InsGetPrescripcion(id).GetDataSet();

        dtDispensacion = x.Tables[0].Copy();
        dtDispensacionDetalle = x.Tables[1].Copy();

        dtDispensacion.TableName = "DSDispensacion";

        ds.Tables.Add(dtDispensacion);
        ds.Tables.Add(dtDispensacionDetalle);

        return ds;
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/farmacia/default.aspx");
    }    
}