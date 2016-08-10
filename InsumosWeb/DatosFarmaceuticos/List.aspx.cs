using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;

public partial class DatosFarmaceuticos_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombos();
    }

    private void CargarCombos()
    {
        //solo traigo aquellos insumos que poseen datos farmaceuticos
        SubSonic.Select ins = new SubSonic.Select();
        ins.From(InsInsumo.Schema);
        ins.InnerJoin(InsDatoFarmaceutico.Schema);
        ins.OrderAsc("nombre");

        ddlInsumos.DataSource = ins.ExecuteTypedList<InsInsumo>(); //son 8 por ahora
        ddlInsumos.DataBind();
        ddlInsumos.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void ddlInsumos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int insu = Convert.ToInt32(ddlInsumos.SelectedValue);

        SubSonic.Select df = new SubSonic.Select();
        df.From(InsDatoFarmaceutico.Schema);
        df.Where(InsDatoFarmaceutico.Columns.Baja).IsEqualTo(0);
        df.And(InsDatoFarmaceutico.Columns.IdInsumo).IsEqualTo(insu);

        gvDatos.DataSource = df.ExecuteTypedList<InsDatoFarmaceutico>();
        gvDatos.DataBind();
    }
}
