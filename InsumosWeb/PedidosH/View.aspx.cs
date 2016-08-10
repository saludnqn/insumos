using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.IO;



public partial class Pedidos_View : System.Web.UI.Page
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
        lblEstados.Text = "<b>" + p.InsEstadoPedido.Nombre + ". Se ha generado el pedido Nro: " + p.IdPedido + "</b>";
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        lblEfectorProveedor.Text = p.SysEfectorToIdEfectorProveedor.Nombre;
        lblDepositoProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        lblResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        if (p.Autorizado == Convert.ToBoolean(1))
            lblAutorizado.Text = "PEDIDO CONFIRMARDO";
        else lblAutorizado.Text = "PEDIDO NO CONFIRMADO";
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        //si es posible enviar el parametro del efector
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        lblEstados.Text = "";
        InsPedido p = new InsPedido(id);
        int ef = Convert.ToInt32(p.IdEfector);
        Response.Redirect("Edit.aspx?idE=" + ef);
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedidoDetalle pd = (InsPedidoDetalle)e.Row.DataItem;

            Label lblCSolicitada = (Label)e.Row.FindControl("lblCSolicitada");
            pd.CantidadSolicitada = Convert.ToInt32(lblCSolicitada.Text);

            Label lblCAutorizada = (Label)e.Row.FindControl("lblCAutorizada");
            pd.CantidadAutorizada = Convert.ToInt32(lblCAutorizada.Text);

            Label lblCEnviada = (Label)e.Row.FindControl("lblCEnviada");
            pd.CantidadEmitida = Convert.ToInt32(lblCEnviada.Text);

            // int deuda = pd.CantidadAutorizada - pd.CantidadEmitida;
            // Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            // lblDeuda.Text = deuda.ToString();
        }
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        lblEstados.Text = "";
        Response.Redirect("Edit.aspx?id=" + id);
    }

    protected void lkImprimir_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPedido p = new InsPedido(id);
        Exportar(id);
    }

    private void Exportar(int id)
    {
        string informe = "PedidoGenerado.rpt";

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
        Response.AddHeader("Content-Disposition", "attachment;filename=PedidoGenerado.pdf");

        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    }

    private DataSet CargarDatos(int id)
    {
        DataSet ds = new DataSet();
        DataTable dtPedido = new DataTable("dtPedido");
        DataTable dtPedidoDetalle = new DataTable("dtPedidoDetalle");

        dtPedido = SPs.InsGetPedidoEncabezado(id).GetDataSet().Tables[0].Copy();
        dtPedidoDetalle = SPs.InsGetPedidoEncabezado(id).GetDataSet().Tables[1].Copy();

        dtPedido.TableName = "dtPedido";
        dtPedidoDetalle.TableName = "dtPedidoDetalle";

        ds.Tables.Add(dtPedido);
        ds.Tables.Add(dtPedidoDetalle);

        return ds;
    }
    protected void btnAutorizar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        Response.Redirect("../PedidosH/Autoriza.aspx?&id=" + id);
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}
