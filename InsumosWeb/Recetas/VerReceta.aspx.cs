using System;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;
using CrystalDecisions.Web;
using System.IO;

public partial class Recetas_VerReceta : System.Web.UI.Page
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
        if (p.SysPaciente.SysObraSocial.Nombre == "SELECCIONAR")
            lblOSocial.Text = "--";
        else lblOSocial.Text = p.SysPaciente.SysObraSocial.Nombre;
        lblTratamiento.Text = p.InsTipoTratamiento.Nombre;
        lblDuracion.Text = p.Duracion.ToString();
        lblUnidadDuracion.Text = p.UnidadDuracion;


        if (p.IdTipoPrescripcion == 1)   //RECETA AMBULATORIA
        {
            gvReceta.Columns[5].Visible = true;
            gvReceta.Columns[6].Visible = true;
            gvReceta.Columns[7].Visible = true;
            //gvReceta.Columns[8].Visible = false;
            gvReceta.Columns[9].Visible = false;
            if (p.IdTipoTratamiento == 2)  //Trat. Prolongado
            {
                //lbCronico.Visible = true;
                upCronico.Visible = true;
                gvReceta.Columns[7].Visible = false;
                //lblUnidadDuracion.Text = p.UnidadDuracion;
                //lblProximaFecha.Text = Convert.ToDateTime(p.ProximaFecha).ToShortDateString();
                //lblNroDispensacion.Text = p.NumeroDispensación.ToString();
                //calcular la fecha de vencimiento de la receta
                //lblFechaVencimiento.Text = ""; //Convert.ToDateTime(p.ProximaFecha - p.Fecha).ToShortDateString();
            }
            else
            {
                //gvReceta.Columns[7].Visible = true;
                //gvReceta.Columns[8].Visible = true;
                upCronico.Visible = false;
            }
        }
        else if(p.IdTipoPrescripcion ==2)  //receta remediar
        {
            //gvReceta.Columns[8].Visible = false;   //prescripcion mensual
            gvReceta.Columns[9].Visible = true;   //prescripcion total
                        
            if (p.IdTipoTratamiento == 2)
            {               
                upCronico.Visible = true;
                gvReceta.Columns[7].Visible = true;   //dias tratamiento
                gvReceta.Columns[8].Visible = true; //prescripción mensual
                gvReceta.Columns[9].Visible = true; //prescripción total                
            }
            else
            {
                //lbCronico.Visible = false;
                upCronico.Visible = false;                               
                //gvReceta.Columns[11].Visible = false;  //entregado

            }
        }
        if (p.IdCODCie10 > 0)
            lblDiagnostico.Text = p.SysCIE10.Codigo + "-" + p.SysCIE10.Nombre; //cartel de no tiene diag
        else lblDiagnostico.Text = "--";
        lblObservaciones.Text = p.Observaciones;
        if (p.IdProfesional > 0)
            lblProfesional.Text = p.SysProfesional.NombreCompleto;
        else lblProfesional.Text = "--";
        //detalle de la receta        
        gvReceta.DataSource = p.InsPrescripcionDetalleRecords;
        gvReceta.DataBind();
        //debria filtar por tipoTratamiento: cronico o no, si es cronico y
        //tiene fecha de prosima dispensacion calcular la deuda y luego mostrarla en la grilla del cronico

        //controlo si tiene dispensaciones
        SubSonic.SqlQuery q = new SubSonic.Select()
         .From(InsDispensacion.Schema)
         .Where(InsDispensacion.Columns.IdPrescripcion).IsEqualTo(p.IdPrescripcion);         

        DataTable dt = q.ExecuteDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnEditar.Visible = false;
            btnDispensar.Visible = false;
        }
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        InsPrescripcion p = new InsPrescripcion(id);
        //Response.Redirect("Default.aspx?id=" + p.IdPrescripcion + "&idD=" + pd.IdPrescripcionDetalle + "&idP=" + pac.IdPaciente.ToString());
        Response.Redirect("Edit.aspx?id=" + p.IdPrescripcion);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    //protected void btnNuevo_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../Dispensaciones/New.aspx?id="
    //        , false);
    //}

    protected void gvReceta_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //InsPrescripcionDetalle pd = (InsPrescripcionDetalle)e.Row.DataItem;

            //Label lblSolicitado = (Label)e.Row.FindControl("lblSolicitado");
            //pd.CantidadSolicitada = Convert.ToInt32(lblSolicitado.Text);

            //Label lblEntregado = (Label)e.Row.FindControl("lblEntregado");
            //pd.CantidadEmitida = Convert.ToInt32(lblEntregado.Text);

            //int deuda = Convert.ToInt32(pd.CantidadSolicitada - pd.CantidadEmitida);
            //Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            //lblDeuda.Text = deuda.ToString();
        }
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


    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx", false);
    }
    protected void btnDispensar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        Response.Redirect("../Dispensaciones/New.aspx?dpl=si&id=" + id);        
    }
    
}