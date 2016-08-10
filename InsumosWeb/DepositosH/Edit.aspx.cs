using System;
using System.Data;
using System.Web.UI.WebControls;
using DalInsumos;
using Salud.Security.SSO;


public partial class DepositosH_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        CargarCombos();
        if (id > 0)
        {
            CargarDeposito(id);
        }
        alerta.Visible = false;
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        ServiciosEfector();

        SubSonic.Select dep = new SubSonic.Select();
        dep.From(InsDeposito.Schema);
        dep.Where(InsDeposito.IdEfectorColumn).IsEqualTo(idEfector);
        //dep.And(InsDeposito.IdDepositoSuperiorColumn).IsEqualTo(0);
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
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DataTable dt = SPs.SysGetServicioByEfector(idEfector).GetDataSet().Tables[0];
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
            ddlServicio.SelectedValue = dep.IdServicio.ToString();            
            ddlDeposito.SelectedValue = dep.IdDepositoSuperior.ToString();
            ddlTipoDep.SelectedValue = dep.IdTipoDeposito.ToString();
            txtDeposito.Text = dep.Nombre;
            txtDescripcion.Text = dep.Descripcion;
            txtObservaciones.Text = dep.Observacion;
            if (dep.Baja == true) cbBaja.Checked = true;
            else cbBaja.Checked = false;
            if (dep.Selected == true) cbDispensacion.Checked = true;
            else cbDispensacion.Checked = false;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        // Page.Validate("1");
        if (DatosValidos(id)) //&& (Page.IsValid))
        {
            
            InsDeposito dep = new InsDeposito(id);

            dep.IdEfector = idEfector;
            dep.IdServicio = Convert.ToInt32(ddlServicio.SelectedValue);
            if (ddlDeposito.SelectedValue == "")
                dep.IdDepositoSuperior = 0;
            else
                dep.IdDepositoSuperior = Convert.ToInt32(ddlDeposito.SelectedValue);
            
            dep.IdTipoDeposito = Convert.ToInt32(ddlTipoDep.SelectedValue);
            dep.Nombre = txtDeposito.Text.ToUpper();
            dep.Descripcion = txtDescripcion.Text;
            dep.Observacion = txtObservaciones.Text;
            dep.Fecha = Convert.ToDateTime(DateTime.Now);
            if (cbBaja.Checked == true) dep.Baja = true;
            else dep.Baja = false;

            if (cbDispensacion.Checked == true) dep.Selected = true;
            else dep.Selected = false;
            dep.Save(username);
            alerta.Visible = true;
            Response.Redirect("View.aspx?id=" + dep.IdDeposito.ToString());
        }
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

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        
    }

    //protected void ddlEfector_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ServiciosEfector();

    //    int efector = Convert.ToInt32(ddlEfector.SelectedValue);
    //    SubSonic.Select dep = new SubSonic.Select();
    //    dep.From(InsDeposito.Schema);
    //    dep.Where(InsDeposito.Columns.IdEfector).IsEqualTo(efector);
    //    ddlDeposito.DataSource = dep.ExecuteTypedList<InsDeposito>();
    //    ddlDeposito.DataBind();
    //}
}
