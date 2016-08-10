using System;
using DalInsumos;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.IO;
using System.Data;
using Salud.Security.SSO;


public partial class PedidosH_ViewInterno : System.Web.UI.Page
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
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblTipoPedido.Text = p.InsTipoPedido.Nombre;

        if (p.IdDepositoProveedor == 0)
            lblProveedor.Text = "";//p.InsProveedor.Nombre;
        else
            lblProveedor.Text = p.InsProveedor.Nombre;//p.InsDepositoToIdDepositoProveedor.Nombre;

        //if (p.InsProveedor.Nombre == "")
        //    lblProveedor.Text = "";
        //else
            //lblProveedor.Text = p.InsProveedor.Nombre;
        
        lblTComprobante.Text = p.InsTipoComprobante.Nombre;
        lblNroComprobante.Text = p.NumeroComprobante;
        //lblOCompra.Text = p.OrdenCompra;
        if (p.Estado == true) lblEstado.Text = "Activo";
        else lblEstado.Text = "Inactivo";
        lblResponsable.Text = p.Responsable;
        lblObservaciones.Text = p.Observaciones;
        //detalle de la provision        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        InsPedido p = new InsPedido(id);
        Response.Redirect("Edit.aspx?id=" + p.IdPedido.ToString());
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx?", false);
    }

    protected void lbPInterna_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPedido p = new InsPedido(id);
        ExportarInterna(id);
    }

    private void ExportarInterna(int id)
    {
        string informe = "ProvisionInterna.rpt";

        ParameterDiscreteValue efector = new ParameterDiscreteValue();
        ParameterDiscreteValue pedido = new ParameterDiscreteValue();
        DataSet ds = CargarDatosInternos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);

        oCr.DataBind();

        MemoryStream oStream;
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=ProvisionInterna.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatosInternos(int id)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DataSet ds = new DataSet();
        DataTable dtProvisionI = new DataTable("dtProvisionI");
        DataTable dtProvisionDetalleI = new DataTable("dtProvisionDetalleI");

        dtProvisionI = SPs.InsGetProvisionInterna(id, idEfector).GetDataSet().Tables[0].Copy();
        dtProvisionDetalleI = SPs.InsGetProvisionInterna(id, idEfector).GetDataSet().Tables[1].Copy();

        dtProvisionI.TableName = "dtProvisionI";
        dtProvisionDetalleI.TableName = "dtProvisionDetalleI";

        ds.Tables.Add(dtProvisionI);
        ds.Tables.Add(dtProvisionDetalleI);

        return ds;
    }
}
