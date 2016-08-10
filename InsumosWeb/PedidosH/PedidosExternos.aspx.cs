using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using ExtensionMethods;
using SubSonic;
using System.Data;
using System.Globalization;
using System.Web.Services;
using Salud.Security.SSO;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

public partial class PedidosH_PedidosExternos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSistemaIntegrado_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        SubSonic.SqlQuery q = new SubSonic.Select()
         .From(InsDepositoZona.Schema)
         .Where(InsDepositoZona.Columns.IdEfector).IsEqualTo(idEfector);
         
        DataTable depo = q.ExecuteDataSet().Tables[0];

        if (depo.Rows.Count > 0)
        {
            string url = depo.Rows[0][4].ToString();
            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=600,WIDTH=820,top=50,left=50,toolbar=yes,scrollbars=yes,resizable=yes');</script>");

            //otra forma
            //Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=600,WIDTH=820,top=50,left=50,toolbar=yes,scrollbars=yes,resizable=yes');</script>");

            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("window.open('");
            //sb.Append(url);
            //sb.Append("');");
            //sb.Append("</script>");
            //ClientScript.RegisterStartupScript(this.GetType(),
            //        "script", sb.ToString());
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}
