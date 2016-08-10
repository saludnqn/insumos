using System;
using DalInsumos;
using System.Data;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.IO;


public partial class ProvisionesH_Finalizado : System.Web.UI.Page
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
            CargarProvision(id);
        }
    }

    private void CargarProvision(int id)
    {
        InsPedido p = new InsPedido(id);
        lblEfector.Text = p.InsDeposito.SysEfector.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.FechaRecepcion).ToShortDateString();
        if (p.IdDepositoProveedor == 0)
            lblProveedor.Text = p.InsProveedor.Nombre;
        else lblProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblTComprobante.Text = p.IdTipoComprobante.ToString();
        lblNroComprobante.Text = p.NumeroComprobante;
        lblOCompra.Text = p.OrdenCompra;
        if (p.Estado == true) lblEstado.Text = "Activo";
        else lblEstado.Text = "Inactivo";
        lblResponsable.Text = p.Responsable;
        lblObservaciones.Text = p.Observaciones;
        //detalle de la provision        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }

    //protected void btnVolver_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Recepcion.aspx", false);
    //}


    protected void lbImprimir_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPedido p = new InsPedido(id);
        Exportar(id);
    }

    private void Exportar(int id)
    {
        string informe = "RecibirProvision.rpt";

        ParameterDiscreteValue efector = new ParameterDiscreteValue();
        ParameterDiscreteValue pedido = new ParameterDiscreteValue();
        DataSet ds = CargarDatos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);

        oCr.DataBind();

        MemoryStream oStream; // using System.IO
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=RecibirProvision.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatos(int id)
    {
        DataSet ds = new DataSet();
        DataTable dtProvision = new DataTable("dtProvision");
        DataTable dtProvisionDetalle = new DataTable("dtProvisionDetalle");

        dtProvision = SPs.InsGetProvision(id).GetDataSet().Tables[0].Copy();
        dtProvisionDetalle = SPs.InsGetProvision(id).GetDataSet().Tables[1].Copy();

        dtProvision.TableName = "dtProvision";
        dtProvisionDetalle.TableName = "dtProvisionDetalle";

        ds.Tables.Add(dtProvision);
        ds.Tables.Add(dtProvisionDetalle);

        return ds;
    }
}
