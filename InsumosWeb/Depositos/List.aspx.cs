using System;
using System.Data;
using DalInsumos;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class Depositos_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //seteo por defecto el efector del usuario
            CargarCombos();
        }
    }

    private void CargarCombos()
    {
        SubSonic.Select ef = new SubSonic.Select();
        ef.From(SysEfector.Schema);
        ef.Where(SysEfector.Columns.Complejidad).IsGreaterThan(Convert.ToInt32("2"));
        ef.Or(SysEfector.Columns.IdEfectorSuperior).IsEqualTo(227);
        ef.OrderAsc("nombre");
        ddlEfector.DataSource = ef.ExecuteTypedList<SysEfector>();
        ddlEfector.DataBind();
        ddlEfector.Items.Insert(0, new ListItem("SELECCIONAR", "0"));

        /*  SubSonic.Select tp = new SubSonic.Select();
          tp.From(InsTipoDeposito.Schema);
          ddlTipoDep.DataSource = tp.ExecuteTypedList<InsTipoDeposito>();
          ddlTipoDep.DataBind();
          ddlTipoDep.Items.Insert(0, new ListItem("SELECCIONAR", "0"));*/

    /*    //primero obtengo los depositos del primer nivel
        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdDepositoSuperior).IsEqualTo(0);
        d.OrderAsc(InsDeposito.Columns.Nombre);

        //ahora los cargo en una lista
        List<InsDeposito> lista = d.ExecuteTypedList<InsDeposito>();
        lit1.Text += "<ul id='treeData'>";
        lit1.Text += Recursivo(lista);
        lit1.Text += "</ul>"; */
    }

   /* private static string Recursivo(List<InsDeposito> lista)
    {
        string s = string.Empty;
        foreach (InsDeposito r in lista)
        {
            s += "<li id='" + r.Codigo + "'";
            List<InsDeposito> lst = GetHijos(r);
            if (lst.Count > 0)
            {
                s += "class = 'folder'>" + r.Nombre;
                s += "<ul>";
                s += Recursivo(lst);
                s += "</ul>";
            }
            s += ">" + r.Nombre;
            s += "</li>";
        }

        return s;
    }

    private static List<InsDeposito> GetHijos(InsDeposito r)
    {
        //obtengo los subrubros
        SubSonic.Select s = new SubSonic.Select();
        s.From(Schemas.InsDeposito);
        s.Where(InsDeposito.Columns.IdDepositoSuperior).IsEqualTo(r.Codigo);

        return s.ExecuteTypedList<InsDeposito>();
    } */

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        buscarDatos();
    }

    private void buscarDatos()
    {
        lblMensaje.Text = "";
        int efector = Convert.ToInt32(ddlEfector.SelectedValue);
        //consulta los depositos existentes en el efector

        SubSonic.Select dep = new SubSonic.Select();
        dep.From(InsDeposito.Schema);
        dep.Where(InsDeposito.Columns.IdEfector).IsEqualTo(efector);
        dep.And(InsDeposito.Columns.IdDepositoSuperior).IsEqualTo(0);
        dep.And(InsDeposito.Columns.Baja).IsEqualTo(false);

        DataTable ds = dep.ExecuteDataSet().Tables[0];
        if (ds.Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            lblMensaje.Text = "No se encontraron datos";
        }
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int efector;
        efector = Convert.ToInt32(ddlEfector.SelectedValue);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int idP = Convert.ToInt32(e.Row.Cells[5].Text);
            GridView gv = (GridView)e.Row.FindControl("GridView2");

            SubSonic.Select sdep = new SubSonic.Select();
            sdep.From(InsDeposito.Schema);
            sdep.Where(InsDeposito.Columns.IdEfector).IsEqualTo(efector);
            sdep.And(InsDeposito.Columns.IdDepositoSuperior).IsNotEqualTo(0);
            sdep.And(InsDeposito.Columns.Baja).IsEqualTo(false);

            DataTable tmd = sdep.ExecuteDataSet().Tables[0];
            if (tmd.Rows.Count > 0)
            {
                gv.DataSource = tmd;
                gv.DataBind();
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        buscarDatos();
    }

    //protected void gvDepositos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    buscarDatos();
    //}
}
