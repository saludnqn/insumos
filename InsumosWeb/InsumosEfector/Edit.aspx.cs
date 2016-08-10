using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalInsumos;

public partial class InsumosEfector_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
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
    }

    private void BindData(string letra)
    {
        Session["letra"] = letra;

        SubSonic.Select h = new SubSonic.Select();
        h.From(SysEfector.Schema);
        h.Where(SysEfector.Columns.IdZona).IsEqualTo(Convert.ToInt32(ddlZona.SelectedValue));
        //h.And(SysEfector.Columns.Nombre).StartsWith(letra);
        h.OrderAsc("nombre");

        DataTable dt = h.ExecuteDataSet().Tables[0];

        gvEfectores.DataSource = dt;
        gvEfectores.DataBind();
    }

    protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData("A");
        lblMensaje.Text = String.Empty;
    }

    protected void gvEfectores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int insumo = acInsumo1.getInsumo();
            CheckBox chk = (CheckBox)e.Row.FindControl("chkEfector");
            int efector = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "idEfector").ToString());
            int registros = new SubSonic.Select().From<InsRelInsumoEfector>()
                .Where("idEfector").IsEqualTo(efector)
                .And("idInsumo").IsEqualTo(insumo).GetRecordCount();

            chk.Checked = registros > 0;
            chk.Attributes.Add("idEfector", efector.ToString());
        }
    }

    protected void gvEfectores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEfectores.PageIndex = e.NewPageIndex;
        BindData("A");
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            int insumo = acInsumo1.getInsumo();

            lblMensaje.Text = String.Empty;

            foreach (GridViewRow row in gvEfectores.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkEfector");
                    if (chk.Checked)
                    {
                        Label lblIdEfector = (Label)row.FindControl("lblIdEfector");
                        int efector = Convert.ToInt32(lblIdEfector.Text);
                        SPs.InsEliminaInsumosEfector(efector, insumo).Execute();

                        InsRelInsumoEfector ie = new InsRelInsumoEfector();
                        ie.IdInsumo = insumo;
                        ie.IdEfector = Convert.ToInt32(chk.Attributes["idEfector"]);
                        ie.Save(us.Username);
                    }
                }
            }
            Response.Redirect("List.aspx", false);
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }
}
