using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using DalInsumos;
using System.Web.UI.WebControls;

public partial class InsumosEfector_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            lblComplejidad.Text = "";
            CargarCombos();
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarCombos()
    {
        SubSonic.Select zo = new SubSonic.Select();
        zo.From(SysZona.Schema);
        zo.OrderAsc("nombre");
        ddlZona.DataSource = zo.ExecuteTypedList<SysZona>();
        ddlZona.DataBind();
        ddlZona.Items.Insert(0, new ListItem("SELECCIONAR", "0"));

/*        SubSonic.Select ef = new SubSonic.Select();
        ef.From(SysEfector.Schema);
        ef.Where(SysEfector.Columns.Complejidad).IsGreaterThan(2);
        ef.OrderAsc("nombre");
        ddlEfector.DataSource = ef.ExecuteTypedList<SysEfector>();
        ddlEfector.DataBind();
        ddlEfector.Items.Insert(0, new ListItem("SELECCIONAR", "0"));*/
    }

    private void BindData(string letra)
    {
        Session["letra"] = letra;

        SubSonic.Select h = new SubSonic.Select();
        h.From(InsInsumo.Schema);
        h.Where(InsInsumo.Columns.Nombre).StartsWith(letra);
        //h.And(InsInsumo .Columns.Baja).IsEqualTo(false);

        DataTable dt = h.ExecuteDataSet().Tables[0];

        gvInsumos.DataSource = dt;
        gvInsumos.DataBind();
    }

    protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    {
        int efector = Convert.ToInt32(ddlEfector.SelectedValue);
        SysEfector ef = new SysEfector(efector);
        lblComplejidad.Text = "Nivel de Complejidad: " + ef.Complejidad;
        BindData("A");
        lblMensaje.Text = String.Empty;
    }


    protected void gvInsumos_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TableCell cell = e.Row.Cells[0];
            cell.ColumnSpan = 5;

            for (int i = 65; i <= (65 + 25); i++)
            {
                LinkButton lb = new LinkButton();

                lb.Text = Char.ConvertFromUtf32(i) + " ";
                lb.CommandArgument = Char.ConvertFromUtf32(i);
                lb.CommandName = "AlphaPaging";

                cell.Controls.Add(lb);
            }
        }
    }

    protected void gvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("AlphaPaging"))
        {
            BindData(e.CommandArgument.ToString());
        }
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int efector = Convert.ToInt32(ddlEfector.SelectedValue);
            CheckBox chk = (CheckBox)e.Row.FindControl("chkInsumos");
            int idInsumo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "idInsumo").ToString());
            int registros = new SubSonic.Select().From<InsRelInsumoEfector>()
                .Where("idInsumo").IsEqualTo(idInsumo)
                .And("idEfector").IsEqualTo(efector).GetRecordCount();

            chk.Checked = registros > 0;
            chk.Attributes.Add("idInsumo", idInsumo.ToString());
        }
    }

    protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInsumos.PageIndex = e.NewPageIndex;
        BindData("A");
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            int efector = Convert.ToInt32(ddlEfector.SelectedValue);
            SPs.InsBorrarInsumosEfector(efector, Session["letra"].ToString()).Execute();
            lblMensaje.Text = String.Empty;
            foreach (GridViewRow row in gvInsumos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkInsumos");
                    Label lblIdInsumo = (Label)row.FindControl("lblIdInsumo");

                    if (chk.Checked)
                    {
                        InsRelInsumoEfector ie = new InsRelInsumoEfector();
                        ie.IdEfector = efector;
                        ie.IdInsumo = Convert.ToInt32(chk.Attributes["idInsumo"]);
                        ie.Save(us.Username);
                    }
                }
            }
            Response.Redirect("List.aspx?idEfector=" + efector.ToString());
        }
        else Response.Redirect("~/FinSesion.htm", false);
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
