using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;
using DalInsumos;
using ExtensionMethods;
using Salud.Security.SSO;
using System.Linq;
using System.Globalization;
using SubSonic;
using Salud.Security.SSO;

public partial class ProvisionesH_Movimientos : System.Web.UI.Page
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
        CargarCombos();
        txtFInicio.Text = DateTime.Now.AddDays(-31).ToShortDateString();
        txtFFin.Text = DateTime.Now.ToShortDateString();
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector del usuario
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("(Seleccione su Servicio/Depósito)", "0"));

        SubSonic.Select m = new SubSonic.Select();
        m.From(InsTipoMovimiento.Schema);
        ddlTipoMovimiento.DataSource = m.ExecuteTypedList<InsTipoMovimiento>();
        ddlTipoMovimiento.DataBind();
        ddlTipoMovimiento.Items.Insert(0, new ListItem("(Todos)", "0"));

        //SubSonic.Select r = new SubSonic.Select();
        //r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Padre).IsNull();
        //r.OrderAsc("Nombre");
        //ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        //ddlRubro.DataBind();
        //ddlRubro.Items.Insert(0, new ListItem("(Todos)", "0"));
    }
    
    private void buscarDatos()
    {
        //debo descontar del stock lo que di en la receta
        int efector = SSOHelper.CurrentIdentity.IdEfector;

        int deposito = Convert.ToInt32(ddlDeposito.SelectedValue);
        int tipoMov = Convert.ToInt32(ddlTipoMovimiento.SelectedValue);

        int idInsumo = ucInsumo.getInsumo();
        if (idInsumo < 0) idInsumo = 0;

        DateTime finicio = DateTime.Now.AddDays(-30);
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;

        DataTable ds = SPs.InsGetMovimientosDepositoEfector(finicio,ffin,tipoMov,deposito, efector,idInsumo).GetDataSet().Tables[0];
        
        if (ds.Rows.Count > 0)
        {
            gvStock.DataSource = ds;
            gvStock.DataBind();
        }
        else
        {
            lblTotal.Text = "";
            gvStock.DataBind();
        }
    }


    private DataTable GetDatos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int dep = ddlDeposito.SelectedValue.TryParseInt();
        int rubro = 0;// ddlRubro.SelectedValue.TryParseInt();
        int ins = 0;

        return SPs.InsGetStockxEfector(idEfector, rubro, dep, ins).GetDataSet().Tables[0];
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
    
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        buscarDatos();
    }
    protected void gvStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStock.PageIndex = e.NewPageIndex;
        buscarDatos();
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetDatos();
        if (dt.Rows.Count > 0)
        {
            string informe = "../ProvisionesH/StockActual.rpt";

            oCr.Report.FileName = informe;
            oCr.ReportDocument.SetDataSource(dt);

            oCr.DataBind();

            MemoryStream oStream;
            oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=StockActual.pdf");

            Response.BinaryWrite(oStream.ToArray());
            Response.End();
        }
    }
}