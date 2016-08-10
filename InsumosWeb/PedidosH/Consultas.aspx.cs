using System;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class PedidosH_Consultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
             CargarCombos();
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector por defecto del usuario
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("TODOS", "0"));

        SubSonic.Select r = new SubSonic.Select();
        r.From(InsRubro.Schema);
        //r.Where(InsRubro.Columns.Baja).IsEqualTo(0);
        r.Where(InsRubro.Columns.Padre).IsEqualTo(362);
        //r.And(InsRubro.Columns.IdRubroPadre).IsEqualTo(0);
        r.OrderAsc("Nombre");
        ddlRubro.DataSource = r.ExecuteTypedList<InsRubro>();
        ddlRubro.DataBind();
        ddlRubro.Items.Insert(0, new ListItem("TODOS", "0"));
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = DateTime.Now.AddDays(-30);
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);
        int rub = Convert.ToInt32(ddlRubro.SelectedValue);

        DataSet de = SPs.InsGEtPedidosRealizados(finicio,ffin,dep,rub,null,idEfector).GetDataSet();       

        gvPedidos.DataSource = de;
        gvPedidos.DataBind();
    }
}
