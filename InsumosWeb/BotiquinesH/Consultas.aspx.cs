using System;
using System.Data;
using System.Web.UI.WebControls;
using DalInsumos;
using ExtensionMethods;
using Salud.Security.SSO;

public partial class BotiquinesH_Consultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombo();
        string username = SSOHelper.CurrentIdentity.Fullname;
        txtFecha.Text = DateTime.Now.ToShortDateString();
        lblResponsable.Text = username;
    }

    private void CargarCombo()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //deposito del usuario
        d.And(InsDeposito.Columns.IdTipoDeposito).IsEqualTo(2); //tipo deposito
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }

    protected void ddlDeposito_SelectedIndexChanged(object sender, EventArgs e)
    {
        //busco lo dispensado en el deposito o area
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);
        DateTime fecha = (txtFecha.Text).TryParseDateTime();

        DataTable dtEncabezado = SPs.InsGetBotiquinServicios(fecha, idEfector, dep).GetDataSet().Tables[0];
        //string Servicio = dtEncabezado.Rows[0][2].ToString();
        //con repeter
        rptControles.DataSource = dtEncabezado;
        rptControles.DataBind();
    }

    protected void rptControles_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            int idEfector = SSOHelper.CurrentIdentity.IdEfector;

            GridView gvMedicamentos = (GridView)e.Item.FindControl("gvMedicamentos");
            if (gvMedicamentos != null)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                if (dataItem != null)
                {
                    DataRowView node = (DataRowView)dataItem.DataItem;
                    int dep = Convert.ToInt32(ddlDeposito.SelectedValue);
                    DateTime fecha = (txtFecha.Text).TryParseDateTime();
                    int idSrv = Convert.ToInt32(node[4]);

                    DataTable dtDetalles = SPs.InsGetBotiquinServiciosDetalle(fecha, idEfector, dep, idSrv).GetDataSet().Tables[0];

                    gvMedicamentos.DataSource = dtDetalles;
                    gvMedicamentos.DataBind();
                }
            }
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dispensar.aspx", false);
    }
}
