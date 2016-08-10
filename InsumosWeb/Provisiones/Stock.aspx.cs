using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DalInsumos;


public partial class Provisiones_Stock : System.Web.UI.Page
{
    int total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        txtFInicio.Text = "01/01/2012";
        txtFFin.Text = DateTime.Now.ToShortDateString();
        CargarCombos();
    }

    private void CargarCombos()
    {

        SubSonic.Select e = new SubSonic.Select();
        e.From(SysEfector.Schema);
        e.Where(SysEfector.Columns.Complejidad).IsGreaterThan(Convert.ToInt32("2"));// o el del usuario??
        e.Or(SysEfector.Columns.IdEfectorSuperior).IsEqualTo(227);
        e.OrderAsc("Nombre");
        ddlEfector.DataSource = e.ExecuteTypedList<SysEfector>();
        ddlEfector.DataBind();
        ddlEfector.Items.Insert(0, new ListItem("Seleccionar", "0"));

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(Convert.ToInt32(ddlEfector.SelectedValue));
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("Seleccionar", "0"));

      /*  SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("Todos", "0")); */       
    }

    protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    {
        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(Convert.ToInt32(ddlEfector.SelectedValue));
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        //cargo los proveedores del efector
        SubSonic.Select p = new SubSonic.Select();
        p.From(InsProveedor.Schema);
        p.Where(InsProveedor.Columns.Baja).IsEqualTo(0);
        // p.And(InsProveedor.Columns.IdProveedor).IsNotEqualTo(0);
        p.And(InsProveedor.Columns.IdEfector).IsEqualTo(Convert.ToInt32(ddlEfector.SelectedValue));
        ddlProveedor.DataSource = p.ExecuteTypedList<InsProveedor>();
        ddlProveedor.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        buscarDatos();
    }

    private void buscarDatos()
    {
        int efector;
        DateTime? finicio = null;
        DateTime? ffin = null;
        DateTime inicio;
        DateTime fin;
        int deposito;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        efector = Convert.ToInt32(ddlEfector.SelectedValue);
        deposito = Convert.ToInt32(ddlDeposito.SelectedValue);
       // int rubro = Convert.ToInt32(ddlRubro.SelectedValue);
        int proveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
        DataTable ds = SPs.InsGetStock(efector, deposito, finicio, ffin, proveedor).GetDataSet().Tables[0];
        if (ds.Rows.Count > 0)
        {
            upStock.Visible = true;
            gvStock.DataSource = ds;
            gvStock.DataBind();
        }
        else {
            upStock.Visible = false;
            lblTotal.Text = "";
            gvStock.DataBind();
        }        
    }

    protected void gvStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //debo calcular la suma por pedido
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "precioTotal"));
            //calculo el stock actual
            Label lblRecibido = (Label)e.Row.FindControl("lblRecibido");
            Label lblEnviado = (Label)e.Row.FindControl("lblEnviado");
            int stock = Convert.ToInt32(lblRecibido.Text) - Convert.ToInt32(lblEnviado.Text);
            Label lblStock = (Label)e.Row.FindControl("lblStock");
            lblStock.Text = stock.ToString();
            //calculo el precio del stock
            Label lblPUnitario = (Label)e.Row.FindControl("lblPUnitario");
            decimal total2 = Convert.ToDecimal(lblPUnitario.Text) * Convert.ToDecimal(lblStock.Text);
            Label lblPTotal = (Label)e.Row.FindControl("lblPTotal");
            lblPTotal.Text = total2.ToString();
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[12].Text = "$ " + total.ToString();
        }
    }

    protected void gvStock_DataBound(object sender, EventArgs e)
    {
        lblTotal.Text = "Monto Total: $" + total.ToString();
        total = 0;
    }

    protected void gvStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStock.PageIndex = e.NewPageIndex;
        buscarDatos();
    }
}
