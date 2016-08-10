using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;

public partial class InsumosEfector_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int idE = SubSonic.Sugar.Web.QueryString<int>("idEfector");
            CargarCombos();
            if (idE > 0)
            {
                ddlZona_SelectedIndexChanged(null,null);
                ddlEfector.SelectedValue = idE.ToString();
                ddlEfector_SelectedIndexChanged(null, null);
            }
        }
    }

    private void CargarCombos()
    {
        SubSonic.Select zo = new SubSonic.Select();
        zo.From(SysZona.Schema);
        zo.OrderAsc("nombre");
        //  lblComplejidad.Text = "Nivel de Complejidad: " + ef.ExecuteSingle<SysEfector.Columns.Complejidad>();
        ddlZona.DataSource = zo.ExecuteTypedList<SysZona>();
        ddlZona.DataBind();
        ddlZona.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
    }

    private void CargarGrilla(int efector)
    {
        SubSonic.Select p = new SubSonic.Select();
        p.From(InsInsumo.Schema);
        p.InnerJoin(InsRelInsumoEfector.Schema);
        p.Where(InsRelInsumoEfector.IdEfectorColumn).IsEqualTo(efector);
        p.And(InsRelInsumoEfector.BajaColumn).IsEqualTo(0);
        p.OrderAsc("nombre");

        List<InsInsumo> li = p.ExecuteTypedList<InsInsumo>();
        gvInsumos.DataSource = li;
        gvInsumos.DataBind();
        InsInsumo ii = new InsInsumo();
        if (li.Count > 0)
        {
            lblRegistros.Text = "Insumos relacionados: " + li.Count.ToString();
        }
        else lblRegistros.Text = "";
    }

    protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    {
       // int idE = SubSonic.Sugar.Web.QueryString<int>("idEfector");
        int efector = Convert.ToInt32(ddlEfector.SelectedValue);
        CargarGrilla(efector);
        CargarComplejidad(efector);
    }

    private void CargarComplejidad(int efector)
    {
        SysEfector e = new SysEfector(efector);
        lblComplejidad.Text = "Nivel de Complejidad: " + e.Complejidad;
    }

    protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInsumos.PageIndex = e.NewPageIndex;
        int efector = Convert.ToInt32(ddlEfector.SelectedValue);
        CargarGrilla(efector);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
       Response.Redirect("Default.aspx", false);
    }

    protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
    {
        SubSonic.Select ef = new SubSonic.Select();
        ef.From(SysEfector.Schema);
        ef.Where(SysEfector.Columns.IdZona).IsEqualTo(Convert.ToInt32(ddlZona.SelectedValue));
        ef.OrderAsc("nombre");
        ddlEfector.DataSource = ef.ExecuteTypedList<SysEfector>();
        ddlEfector.DataBind();
        ddlEfector.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
    }
}