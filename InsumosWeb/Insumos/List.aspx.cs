using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;

public partial class Insumos_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
     }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = usInsumo.getInsumo();
        if (id > 0)
        {
            Response.Redirect("Edit.aspx?id=" + id.ToString());
        }
    }

    protected void hlDatosfarmacia_Click(object sender, ImageClickEventArgs e)
    {
        int id = usInsumo.getInsumo();
        Response.Redirect("~/DatosFarmaceuticos/Edit.aspx?idI=" + id.ToString());
    }

    protected void hlDatosalarma_Click(object sender, ImageClickEventArgs e)
    {
        int id = usInsumo.getInsumo();
        Response.Redirect("~/Alarmas/Edit.aspx?idI=" + id.ToString());
    }
}
