using System;
using CrystalDecisions.Web;
using System.Data;
using CrystalDecisions.Shared;
using System.IO;
using DalInsumos;
using Salud.Security.SSO;

public partial class BotiquinesH_VerDispensa : System.Web.UI.Page
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
        // id del IdPedido
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarPedido(id);
        }
    }

    private void CargarPedido(int id)
    {
        //debo traer el pedido para cambiar o no el estado
        InsPedido p = new InsPedido(id);
        lblEstados.Text = p.InsEstadoPedido.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        if (p.InsDeposito.IdServicio > 0)
            lblServicio.Text = p.InsDeposito.SysServicio.Nombre;
        else lblServicio.Text = "";
        // lblEfectorProveedor.Text = p.SysEfectorToIdEfectorProveedor.Nombre;
        // lblDepositoProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        if (p.Autorizado == Convert.ToBoolean(1))
            lblAutorizado.Text = "Pedido Enviado";
        else lblAutorizado.Text = "";
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        lblEstados.Text = "";
        InsPedido p = new InsPedido(id);
        int ef = Convert.ToInt32(p.IdEfector);
        Response.Redirect("Dispensar.aspx?idE=" + ef);
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        lblEstados.Text = "";
        Response.Redirect("Dispensar.aspx?id=" + id);
    }

    protected void lkImprimir_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPedido p = new InsPedido(id);
        Exportar(id);
    }

    private void Exportar(int id)
    {
        SysEfector efector = null;
        efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

        string fullname = SSOHelper.CurrentIdentity.Username;

        string informe = "BotiquinEnvio.rpt";

        DataSet ds = CargarDatos(id);

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

        MemoryStream oStream; // using System.IO
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=BotiquinEnvio.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatos(int id)
    {
        DataSet ds = new DataSet();
        DataTable dtBotiquinE = new DataTable("DSBotiquinEnvio");
        DataTable dtBotiquinEDetalle = new DataTable("DSBotiquinEnvioDetalle");

        DataSet eb = SPs.InsGetEnviosBotiquin(id).GetDataSet();
        dtBotiquinE = eb.Tables[0].Copy();
        dtBotiquinEDetalle = eb.Tables[1].Copy();

        dtBotiquinE.TableName = "DSBotiquinEnvio";
        dtBotiquinEDetalle.TableName = "DSBotiquinEnvioDetalle";

        ds.Tables.Add(dtBotiquinE);
        ds.Tables.Add(dtBotiquinEDetalle);

        return ds;
    }
}
