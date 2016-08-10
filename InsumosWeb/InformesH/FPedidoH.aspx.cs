using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class InformesH_FPedidoH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        Session["efector"] = 1;
        Session["deposito"] = 0;
        Session["pedido"] = 0;

        ReportParameter r = new ReportParameter("efector", Session["efector"].ToString());
        ReportParameter s = new ReportParameter("deposito", Session["deposito"].ToString());
        ReportParameter t = new ReportParameter("pedido", Session["pedido"].ToString());

        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { r, s , t });

        ReportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;     

        //ObjectDataSource ObjectDataSource1 = new ObjectDataSource("Report.Part1.DataSet1TableAdapters.OrdersTableAdapter", "GetData");
        //Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1_Orders", ObjectDataSource1);
        //ReportViewer1.LocalReport.ReportPath = "Ordenes.rdlc";
        //ReportViewer1.LocalReport.DataSources.Add(rds); 
    }

    protected static void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        //DSPedidoHTableAdapters.INS_RPTPedidoHTableAdapter
        ObjectDataSource ObjectDataSource2 = new ObjectDataSource("Report.Part1.DSPedidoDetalleHTableAdapters.INS_PedidoDetalleTableAdapter", "GetData"); 
        e.DataSources.Add(new ReportDataSource("DSPedidoDetalleH_INS_PedidoDetalle", ObjectDataSource2)); 
        //ObjectDataSource ObjectDataSource2 = new ObjectDataSource("Report.Part1.DataSet2TableAdapters.Order_DetailsTableAdapter", "GetData"); 
        //e.DataSources.Add(new ReportDataSource ("DataSet2_Order_Details", objectDataSource2)); 
    }
}
