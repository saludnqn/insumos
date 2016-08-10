using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;
using Salud.Security.SSO;


public partial class Recetas_Consultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombos();
        upRecetas.Visible = false;
        txtFInicio.Text = DateTime.Now.AddDays(-31).ToShortDateString();
        txtFFin.Text = DateTime.Now.ToShortDateString();
    }

    private void CargarCombos()
    {
        SubSonic.Select tt = new SubSonic.Select();
        tt.From(InsTipoTratamiento.Schema);
        ddlTratamiento.DataSource = tt.ExecuteTypedList<InsTipoTratamiento>();
        ddlTratamiento.DataBind();
        ddlTratamiento.Items.Insert(0, new ListItem("Todos ", "0"));

        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoPrescripcion.Schema);
        dllTipoPrescripcion.DataSource = tp.ExecuteTypedList<InsTipoPrescripcion>();
        dllTipoPrescripcion.DataBind();
        dllTipoPrescripcion.Items.Insert(0, new ListItem("Todos ", "0"));
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

        DateTime finicio = DateTime.Now.AddDays(-31); 
        DateTime ffin = DateTime.Now;
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

        DataTable recetas = SPs.InsGetPrescripciones(idEfector, presc, trat, finicio, ffin, doc, 2).GetDataSet().Tables[0];
        //El último parámetro es para traer todas las recetas
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
            //Label tipo = (Label)e.Row.FindControl("lblTPrescripcion");

            if (Convert.ToDateTime(vencimiento.Text) < DateTime.Now.AddDays(1))
                dispensar.Visible = false;
        }
        //}
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx", false);
    }
    protected void btnReceta_Click(object sender, EventArgs e)
    {

    }
}
