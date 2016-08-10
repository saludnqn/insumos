using System;
using DalInsumos;

public partial class ProvisionesH_VerProvisionExterna : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            //provision desde abastecimiento o deposito central
            CargarProvision(id);
        }
    }

    private void CargarProvision(int id)
    {
        InsPedido p = new InsPedido(id);
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblPedido.Text = p.IdPedido.ToString();
        lblFecha.Text = Convert.ToDateTime(p.FechaRecepcion).ToShortDateString();
        if (p.IdDepositoProveedor == 0)
            lblProveedor.Text = "";
        else lblProveedor.Text = p.InsDepositoToIdDepositoProveedor.Nombre;
        lblTComprobante.Text = p.InsTipoComprobante.Nombre;
        lblNroComprobante.Text = p.NumeroComprobante;
        lblResponsable.Text = p.Responsable;
        lblObservaciones.Text = p.Observaciones;
        //detalle de la provision        
        gvInsumos.DataSource = p.InsPedidoDetalleRecords;
        gvInsumos.DataBind();
    }
}
