using System;
using System.Data;
using System.IO;
using CrystalDecisions.Web;
using DalInsumos;

public partial class Recetas_InternacionView : System.Web.UI.Page
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
            CargarRecetaInternacion(id);
        }
    }

    private void CargarRecetaInternacion(int id)
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
        //traer el Nro Pedido generado
      /*  lblPedido.Text = "";
        if (p.IdCODCie10 > 0)
            lblDiagnostico.Text = p.SysCIE10.Codigo + "-" + p.SysCIE10.Nombre; //cartel de no tiene diag
        else lblDiagnostico.Text = "--";
        lblObservaciones.Text = p.Observaciones;*/
        if (p.IdProfesional > 0)
            lblProfesional.Text = p.SysProfesional.NombreCompleto;
        else lblProfesional.Text = "--";
        //detalle de la receta        
        gvReceta.DataSource = p.InsPrescripcionDetalleRecords;
        gvReceta.DataBind();
        //aca deberia traer una consulta que me traiga el precio unitario, fecha de vto y lote del insumo pedido
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        InsPrescripcion p = new InsPrescripcion(id);
        Response.Redirect("PedidoInternacionEdit.aspx?id=" + p.IdPrescripcion);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("PedidoInternacionEdit.aspx", false);
    }

    /* protected void gvReceta_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             InsPrescripcionDetalle pd = (InsPrescripcionDetalle)e.Row.DataItem;

             Label lblEntregado = (Label)e.Row.FindControl("lblEntregado");
             pd.CantidadEmitida = Convert.ToInt32(lblEntregado.Text);

             int deuda = Convert.ToInt32(pd.CantidadSolicitada - pd.CantidadEmitida);
             Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
             lblDeuda.Text = deuda.ToString();
         }
     }*/

    protected void lbImprimir_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPrescripcion p = new InsPrescripcion(id);
        Exportar(id);
    }

    private void Exportar(int id)
    {
        string informe = "RecetasInternacion.rpt";

        DataSet ds = CargarDatos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);
        oCr.DataBind();

        MemoryStream oStream; // using System.IO
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=RecetasInternacion.pdf");

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

   /* protected void btnPedido_Click(object sender, EventArgs e)
    {
        //deberia crear la primera linea de la tabla InternacionPedido para la grilla de los Pedidos
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        Response.Redirect("PedidoGenerado.aspx?idp=" + id.ToString());
    }*/
}
