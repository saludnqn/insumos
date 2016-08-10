using System;
using System.Web.UI;
using DalInsumos;
using SubSonic;
using System.Collections.Generic;
using Salud.Security.SSO;


public partial class Insumos_ConsultaDosis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //traigo los datos de la dosis de Insumo o medicamento
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (id > 0)
                CargarDosis(id);
            else
                gvMedicamentos.DataBind();
        }
    }

    private void CargarDosis(int id)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        InsDosi d = new InsDosi(id);

        lblMedicamento.Text = d.InsInsumo.Codigo + " - " + d.InsInsumo.Nombre;
        int idInsumo = d.IdInsumo;

        SubSonic.Select i = new Select();
        i.From(InsDosi.Schema);
        i.Where(InsDosi.IdInsumoColumn).IsEqualTo(idInsumo);
        i.And(InsDosi.IdEfectorColumn).IsEqualTo(idEfector);
        i.OrderDesc("CreatedOn");

        List<InsDosi> li = i.ExecuteTypedList<InsDosi>();

        gvMedicamentos.DataSource = li;
        gvMedicamentos.DataBind();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditaDosis.aspx", false);
    }
}
