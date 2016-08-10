using System;
using System.Web.UI;
using DalInsumos;
using ExtensionMethods;
using System.Data;
using Salud.Security.SSO;


public partial class Insumos_EditaDosis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        lblMensaje.Text = "";
        txtNroDosis.Text = "";
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarDosis(id);
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (Page.IsValid)
        {
            int idInsumo = Medicamento.getInsumo();
            //int idInsumo = hfidInsumo.Value.TryParseInt();

            InsDosi ins = new InsDosi(id);

            ins.Cantidad = txtNroDosis.Text.TryParseInt();

            ins.IdEfector = idEfector;
            ins.IdInsumo = idInsumo;
            ins.Save(username);
            Response.Redirect("ConsultaDosis.aspx?id=" + ins.IdDosis.ToString());
        }
        else txtNroDosis.ReadOnly = false;
    }

    protected void lkDosis_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        txtNroDosis.Text = "";
        int idInsumo = Medicamento.getInsumo();
        hfidInsumo.Value = idInsumo.ToString();

        //traigo los datos de las dosis encontradas para el efector
        SubSonic.Select d = new SubSonic.Select(new string[] { "idDosis, idInsumo, cantidad" });
        d.From(InsDosi.Schema);
        d.Where(InsDosi.IdInsumoColumn).IsEqualTo(idInsumo);
        d.And(InsDosi.IdEfectorColumn).IsEqualTo(idEfector);

        DataTable dt = d.ExecuteDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            int id = Convert.ToInt32(dt.Rows[0][0]);
            CargarDosis(id);
        }
    }

    private void CargarDosis(int id)
    {
        InsDosi m = new InsDosi(id);

        Medicamento.setIns(m.IdInsumo);
        if (m.Cantidad > 0)
        {
            txtNroDosis.Text = m.Cantidad.ToString();
            lblMensaje.Text = "El medicamento seleccionado ya posee nro de dosis";
        }
        else
        {
            txtNroDosis.Text = "";
            lblMensaje.Text = "Puede ingresar la dosis del medicamento seleccionado";
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditaDosis.aspx", false);
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
}