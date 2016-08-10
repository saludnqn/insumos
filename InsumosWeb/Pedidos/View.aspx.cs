using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using SubSonic;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.IO;
using System.Data;

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
        lblEstados.Text = p.InsEstadoPedido.Nombre + ". Se ha generado el pedido Nro: " + p.IdPedido;
        lblTPedido.Text = p.InsTipoPedido.Nombre;
        lblFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
        //lblEfector.Text = p.InsDeposito.SysEfector.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblResponsable.Text = p.Responsable;
        txtObservaciones.Text = p.Observaciones;
        if (p.Autorizado == Convert.ToBoolean(1))
            lblAutorizado.Text = "Pedido Autorizado";
        else lblAutorizado.Text = "Pedido NO Autorizado";
        //detalle del pedido        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
       // Exportar(id);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        lblEstados.Text = "";
        InsPedido p = new InsPedido(id);
        int ef = Convert.ToInt32(p.IdEfector);
        Response.Redirect("Edit1.aspx?idE=" + ef);
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

            int deuda = pd.CantidadSolicitada - pd.CantidadAutorizada;
            Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            lblDeuda.Text = deuda.ToString();
        }
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        lblEstados.Text = "";
        InsPedido p = new InsPedido(id);
        int ef = Convert.ToInt32(p.IdEfector);
        Response.Redirect("Edit1.aspx?id=" + id + "&idE=" + ef);
        //Response.Redirect("Default.aspx?id=" + p.IdPrescripcion + "&idD=" + pd.IdPrescripcionDetalle + "&idP=" + pac.IdPaciente.ToString());
    }

    private void Exportar(int id)
    {
        string informe = "Pedido.rpt";

        SysUsuario us = new SysUsuario(Convert.ToInt32(Session["idUsuario"]));
        //SysEfector efector = new SysEfector(us.IdEfector);
        ParameterDiscreteValue efector = new ParameterDiscreteValue();
        //encabezado1.Value = efector.Nombre;
        ParameterDiscreteValue pedido = new ParameterDiscreteValue();
        //fecha1.Value = txtFecha.Text.ToString();
        DataSet ds = CargarDatos(id);

        oCr.Report.FileName = informe;
        oCr.ReportDocument.SetDataSource(ds);
        //oCr.ReportDocument.ParameterFields[0].CurrentValues.Add(efector);
        //oCr.ReportDocument.ParameterFields[1].CurrentValues.Add(pedido);

        oCr.DataBind();

        MemoryStream oStream; // using System.IO
        oStream = (MemoryStream)oCr.ReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=Pedido.pdf");

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

    protected void lbExportar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPedido p = new InsPedido(id);
        Exportar(id);
    }
}
