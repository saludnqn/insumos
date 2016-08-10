using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class Recetas_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idD = SubSonic.Sugar.Web.QueryString<int>("idD");
        if (idD > 0)
        {
            CargarHistorial(idD);
        }
    }

    private void CargarHistorial(int idD)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DataTable ds = SPs.InsGetHistorialRecetas(idEfector, idD).GetDataSet().Tables[0];
        gvRecetas.DataSource = ds;
        gvRecetas.DataBind();
    }

    protected void gvRecetas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSolicitado = (Label)e.Row.FindControl("lblSolicitado");
            int sol = Convert.ToInt32(lblSolicitado.Text);

            Label lblEntregado = (Label)e.Row.FindControl("lblEntregado");
            int ent = Convert.ToInt32(lblEntregado.Text);

            int deuda = sol - ent;
            Label lblDeuda = (Label)e.Row.FindControl("lblDeuda");
            lblDeuda.Text = deuda.ToString();
        }
    }
}
