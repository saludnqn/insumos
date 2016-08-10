using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExtensionMethods;
using DalInsumos;
using SubSonic;

public partial class Provisiones_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
          SysUsuario us = new SysUsuario(Session["idUsuario"]);
          if (!us.IsNew)
          {
              CargarCombos();
              txtFInicio.Text = "01/01/2012";
              txtFFin.Text = DateTime.Now.AddDays(1).ToShortDateString();
          }
          else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarCombos()
    {
        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(0);
        //r.And(InsRubro.Columns.Baja).IsEqualTo(0);
        r.OrderAsc("nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }

    private void Buscar()
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);

        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);

        SubSonic.Select p = new Select();
        p.From(InsPedido.Schema);
        p.Where(InsPedido.IdRubroColumn).IsEqualTo(rub);
        p.And(InsPedido.FechaRecepcionColumn).IsBetweenAnd(finicio, fin);
        p.And(InsPedido.IdTipoPedidoColumn).IsEqualTo(6);
        p.And(InsPedido.IdEfectorColumn).IsEqualTo(us.IdEfector);
        p.And(InsPedido.IdEfectorProveedorColumn).IsEqualTo(us.IdEfector);
        p.OrderDesc("FechaRecepcion");

        //DataSet dt = SPs.InsGetConsultaPedidos(finicio, fin, ef, dep, rub, ep, np).GetDataSet().Tables[0];
        gvProvisiones.DataSource = p.ExecuteTypedList<InsPedido>();
        gvProvisiones.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Buscar();
    }

    protected void gvProvisiones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPedido p = (InsPedido)e.Row.DataItem;
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");

            if (lblEstado.Text == "True")
            {
                e.Row.Cells[7].Text = "Activo";
                e.Row.Cells[7].ToolTip = "Provisión ingresada y habilitada.";
            }
            else
            {
                e.Row.Cells[7].Text = "Inactivo";
                e.Row.Cells[7].ToolTip = "Provisión NO Habilitada.";
            }
        }
    }
}



