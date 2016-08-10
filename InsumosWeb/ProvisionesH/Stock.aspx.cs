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

public partial class ProvisionesH_Stock : System.Web.UI.Page
{
    public CrystalReportSource oCr = new CrystalReportSource();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        oCr.Report.FileName = "";
        oCr.CacheDuration = 0;
        oCr.EnableCaching = false;
    }

    private DataTable dtDetalleLotes; //tabla para los lotes

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {          
            return;
        }
        CargarCombos();
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        hfIdEfector.Value = idEfector.ToString();
        InicializarTablaDetalleLotes();
    }

    private void InicializarTablaDetalleLotes()
    {
        ///Inicializa las sesiones para las tablas de diagnosticos y de determinaciones
        if (Session["Tabla1"] != null) Session["Tabla1"] = null;

        dtDetalleLotes = new DataTable();

        DataColumn col = new DataColumn("id", typeof(int));
        col.AutoIncrement = true;
        col.AutoIncrementSeed = 1;
        dtDetalleLotes.Columns.Add(col);
        dtDetalleLotes.Columns.Add("idInsumo", typeof(int));        
        dtDetalleLotes.Columns.Add("PresentacionNum", typeof(int));
        dtDetalleLotes.Columns.Add("numeroLote");
        dtDetalleLotes.Columns.Add("fechaVencimiento");
        dtDetalleLotes.Columns.Add("stock", typeof(int));        

        Session.Add("Tabla1", dtDetalleLotes);

        //gvLotes.DataSource = dtDetalleLotes;
        //gvLotes.DataBind();
        //gvLotes.UpdateAfterCallBack = true;
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
        //ddlDeposito.Items.Insert(0, new ListItem("TODOS", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Padre).IsNull();
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("Todos", "0"));
    }
    
    private void buscarDatos()
    {        
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        int deposito = Convert.ToInt32(ddlDeposito.SelectedValue);
        int rubro = Convert.ToInt32(ddlRubro.SelectedValue);

        int idInsumo = ucInsumo.getInsumo();
        if (idInsumo < 0) idInsumo = 0;

        DataTable ds = SPs.InsGetStockxEfector(idEfector, rubro, deposito, idInsumo).GetDataSet().Tables[0];
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
        int rubro = ddlRubro.SelectedValue.TryParseInt();
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
    protected void gvStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int efector = SSOHelper.CurrentIdentity.IdEfector;
            int dep = ddlDeposito.SelectedValue.TryParseInt();

            ////bindeo la segunda grilla
            Label lblIdInsumo = (Label)e.Row.FindControl("lblIdInsumo");
            hfIdInsumo.Value = lblIdInsumo.Text;

            GridView gvLotes = (GridView)e.Row.FindControl("gvLotes");
            ////solo los insumo con stock
            gvLotes.AutoGenerateColumns = false;

            DataTable di = DalInsumos.SPs.InsGetInsumosDisponiblesGrilla(efector, dep, Convert.ToInt32(hfIdInsumo.Value)).GetDataSet().Tables[0];
            gvLotes.DataSource = di;
            gvLotes.DataBind();
        }
    }
}