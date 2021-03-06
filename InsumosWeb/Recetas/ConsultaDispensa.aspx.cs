﻿using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;
using Salud.Security.SSO;


public partial class Recetas_ConsultaDispensa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombos();
        upRecetas.Visible = false;
        txtFInicio.Text = DateTime.Now.AddDays(-2).ToShortDateString();
        txtFFin.Text = DateTime.Now.ToShortDateString();
    }

    private void CargarCombos()
    {
        SubSonic.Select tt = new SubSonic.Select();
        tt.From(InsTipoTratamiento.Schema);
        ddlTratamiento.DataSource = tt.ExecuteTypedList<InsTipoTratamiento>();
        ddlTratamiento.DataBind();
        ddlTratamiento.Items.Insert(0, new ListItem("Seleccionar ", "0"));

        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoPrescripcion.Schema);
        dllTipoPrescripcion.DataSource = tp.ExecuteTypedList<InsTipoPrescripcion>();
        dllTipoPrescripcion.DataBind();
        dllTipoPrescripcion.Items.Insert(0, new ListItem("Seleccionar ", "0"));
    }

    protected void ddlTratamiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuscarDatos();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        BuscarDatos();
    }

    private void BuscarDatos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        int trat = Convert.ToInt32(ddlTratamiento.SelectedValue);
        int presc = Convert.ToInt32(dllTipoPrescripcion.SelectedValue);
        int doc = 0;
        if (txtDoc.Text.Length > 0)
            doc = int.Parse(txtDoc.Text);

        DataTable recetas = SPs.InsGetPrescripciones(idEfector, presc, trat, finicio, ffin, doc, 0).GetDataSet().Tables[0];
        //El último parámetro es para traer solo las recetas que no fueron dispensadas (recetaVencida=false)
        gvRecetas.DataSource = recetas;
        upRecetas.Visible = true;
        gvRecetas.DataBind();
              
    }

    protected void gvRecetas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRecetas.PageIndex = e.NewPageIndex;
        BuscarDatos();
    }

    protected void gvRecetas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {                
            ////ImageButton ib = (ImageButton)e.Row.FindControl("ibBorrar");
            //ib.Visible = false;  

            //agrego esto
            int efector = SSOHelper.CurrentIdentity.IdEfector;
            
            //bindeo la segunda grilla
            Label lblIdPrescripcion = (Label)e.Row.FindControl("lblIdPrescripcion");
            hfIdPrescripcion.Value = lblIdPrescripcion.Text;

            GridView gv = (GridView)e.Row.FindControl("gvDispensacionReceta");
            
            DataTable dr = DalInsumos.SPs.InsGetDispensacionReceta(efector, Convert.ToInt32(hfIdPrescripcion.Value)).GetDataSet().Tables[0];
            gv.DataSource = dr;
            gv.DataBind();
            //bool dispenso;

            //if (dr.Rows.Count > 0)
            //    dispenso = true;
            //else
            //    dispenso = false;
            HyperLink dispensar = (HyperLink)e.Row.FindControl("HyperLinkDispensar");
            Label vencimiento = (Label)e.Row.FindControl("vencimientoReceta");
            Label vencida = (Label)e.Row.FindControl("recetaVencida");
        
            
            if (Convert.ToDateTime(vencimiento.Text) < DateTime.Now.AddDays(0))
                dispensar.Visible = false;
            if (vencida.Text == "Vencida")
                dispensar.Visible = false;
        }
        //}
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}
