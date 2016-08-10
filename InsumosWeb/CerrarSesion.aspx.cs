using System;
using System.Web;

public partial class CerrarSesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session.Abandon();
        //Response.Redirect("http://" + HttpContext.Current.Request.Url.Host + "/Sips/Login.aspx", false);
    }
}
