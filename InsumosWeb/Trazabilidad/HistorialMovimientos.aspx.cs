using System;
using DalInsumos;
using System.Data;
using System.IO;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.Web.UI.WebControls;
using Salud.Security.SSO;


public partial class Trazabilidad_HistorialMovimientos : System.Web.UI.Page
{
    public CrystalReportSource oCr = new CrystalReportSource();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        oCr.Report.FileName = "";
        oCr.CacheDuration = 0;
        oCr.EnableCaching = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        txtFechaInicio.Text = "01/01/2013";
        txtFechaFin.Text = DateTime.Now.AddDays(30).ToShortDateString();
        lblMensaje.Text = "";
        //gvInsumos.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = Convert.ToDateTime("01/01/2013");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFechaInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFechaFin.Text, out fin))
            ffin = fin;
        int idInsumo = Insumo.getInsumo();
        //traigo los datos desde el store
        DataTable dtEncabezado = SPs.InsEntregasMedicamentos(idInsumo, idEfector, finicio, ffin).GetDataSet().Tables[0];
        if (dtEncabezado.Rows.Count > 0)
        {
            lblMensaje.Text = "";
        }
        else
        {
            lblMensaje.Text = "No existen Dispensaciones del Medicamento seleccionado";
        }
        rptControles.DataSource = dtEncabezado;
        rptControles.DataBind();
    }

    protected void rptControles_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            //SysUsuario us = new SysUsuario(Session["idUsuario"]);
            int idEfector = SSOHelper.CurrentIdentity.IdEfector;
            GridView gvMedicamentos = (GridView)e.Item.FindControl("gvMedicamentos");
            if (gvMedicamentos != null)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                if (dataItem != null)
                {
                    DataRowView node = (DataRowView)dataItem.DataItem;
                    int idInsumo = Insumo.getInsumo();
                    //int dep = Convert.ToInt32(ddlDeposito.SelectedValue);
                    //DateTime fecha = (txtFecha.Text).TryParseDateTime();
                    int deposito = Convert.ToInt32(node[1]);

                    DataTable dtDetalles = SPs.InsEntregasMedicamentosDetalle(idInsumo, idEfector, deposito).GetDataSet().Tables[0];

                    gvMedicamentos.DataSource = dtDetalles;
                    gvMedicamentos.DataBind();
                }
            }
        }
    }
}
