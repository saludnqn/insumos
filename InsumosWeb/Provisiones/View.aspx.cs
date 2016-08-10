using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.IO;

public partial class Provisiones_View : System.Web.UI.Page
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
        lblProveedor.Text = p.InsProveedor.Nombre;
        lblTComprobante.Text = p.InsTipoComprobante.Nombre;
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

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedidoDetalle pd = (InsPedidoDetalle)e.Row.DataItem;
            //solicitada = autorizada
            Label lblCRecibida = (Label)e.Row.FindControl("lblCRecibida");
            pd.CantidadRecibida = Convert.ToInt32(lblCRecibida.Text);

            Label lblCUnitario = (Label)e.Row.FindControl("lblCUnitario");
            pd.PrecioUnitario = Convert.ToDecimal(lblCUnitario.Text);

            decimal total = pd.CantidadRecibida * pd.PrecioUnitario;
            Label lblTotalInsumo = (Label)e.Row.FindControl("lblTotalInsumo");
            lblTotalInsumo.Text = total.ToString();
        }
    }

    protected void lbImprimir_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPedido p = new InsPedido(id);
        Exportar(id);
    }

    private void Exportar(int id)
    {
        string informe = "Provision.rpt";

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
        Response.AddHeader("Content-Disposition", "attachment;filename=Provision.pdf");

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
