using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;

public partial class Depositos_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            CargarCombos();
            if (id > 0)
            {
                CargarDeposito(id);
            }
        }
        else Response.Redirect("~/FinSesion.htm", false);
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

        ServiciosEfector();

        SubSonic.Select dep = new SubSonic.Select();
        dep.From(InsDeposito.Schema);
        ddlDeposito.DataSource = dep.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("NINGUNO", "0"));

        SubSonic.Select tdep = new SubSonic.Select();
        tdep.From(InsTipoDeposito.Schema);
        ddlTipoDep.DataSource = tdep.ExecuteTypedList<InsTipoDeposito>();
        ddlTipoDep.DataBind();
    }

    private void ServiciosEfector()
    {
        int efector = Convert.ToInt32(ddlEfector.SelectedValue);
        DataTable dt = SPs.SysGetServicioByEfector(efector).GetDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            ddlServicio.DataSource = dt;  //modificar el idEfector
            ddlServicio.DataBind();
        }
        ddlServicio.Items.Insert(0, new ListItem("NINGUNO", "0"));
    }

    private void CargarDeposito(int id)
    {
        InsDeposito dep = new InsDeposito(id);
        if (!dep.IsNew)
        {
            ddlEfector.SelectedValue = dep.IdEfector.ToString();
            ddlServicio.SelectedValue = dep.IdServicio.ToString();
            //txtCodigo.Text = dep.Codigo.ToString();
            ddlDeposito.SelectedValue = dep.IdDepositoSuperior.ToString();
            ddlTipoDep.SelectedValue = dep.IdTipoDeposito.ToString();
            txtDeposito.Text = dep.Nombre;
            txtDescripcion.Text = dep.Descripcion;
            txtObservaciones.Text = dep.Observacion;
            if (dep.Baja == true) cbBaja.Checked = true;
            else cbBaja.Checked = false;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        if (!us.IsNew)
        {
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            // Page.Validate("1");
            if (DatosValidos(id)) //&& (Page.IsValid))
            {
                InsDeposito dep = new InsDeposito(id);

                dep.IdEfector = Convert.ToInt32(ddlEfector.SelectedValue);
                dep.IdServicio = Convert.ToInt32(ddlServicio.SelectedValue);
                if (ddlDeposito.SelectedValue == "")
                    dep.IdDepositoSuperior = 0;
                else dep.IdDepositoSuperior = Convert.ToInt32(ddlDeposito.SelectedValue);
                dep.IdTipoDeposito = Convert.ToInt32(ddlTipoDep.SelectedValue);
                //  dep.Codigo = Convert.ToInt32(txtCodigo.Text);
                dep.Nombre = txtDeposito.Text.ToUpper();
                dep.Descripcion = txtDescripcion.Text;
                dep.Observacion = txtObservaciones.Text;
                dep.Fecha = Convert.ToDateTime(DateTime.Now);
                if (cbBaja.Checked == true) dep.Baja = true;
                else dep.Baja = false;
                dep.Save(us.Username);
                Response.Redirect("View.aspx?id=" + dep.IdDeposito.ToString());
            }
        }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private bool DatosValidos(int id)
    {
        //verifico que el registro ya existe
        SubSonic.Select dep = new SubSonic.Select();
        dep.From(InsDeposito.Schema);
        dep.Where(InsDeposito.Columns.IdDeposito).IsNotEqualTo(id);
        DataTable dtd = dep.ExecuteDataSet().Tables[0];
        if (dtd.Rows.Count > 0)
        {
            return true;
        }
        return true;
    }

    protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    {
        ServiciosEfector();

        int efector = Convert.ToInt32(ddlEfector.SelectedValue);
        SubSonic.Select dep = new SubSonic.Select();
        dep.From(InsDeposito.Schema);
        dep.Where(InsDeposito.Columns.IdEfector).IsEqualTo(efector);
        ddlDeposito.DataSource = dep.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
    }
}
