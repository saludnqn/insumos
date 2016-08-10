using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Pedidos_Reportes_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (IsPostBack) return;
       txtFechaI.Text = "01/01/2012";
       txtFechaF.Text =  DateTime.Now.AddDays(1).ToShortDateString();
    }

    protected void btnEjecutar_Click(object sender, EventArgs e)
    {
        upReporte.Visible = true;

        Session["desde"] = Convert.ToDateTime(txtFechaI.Text);
        Session["hasta"] = Convert.ToDateTime(txtFechaF.Text);

        ReportParameter p = new ReportParameter("desde", Session["desde"].ToString());
        ReportParameter q = new ReportParameter("hasta", Session["hasta"].ToString());

        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] {p,q});
    }
}
