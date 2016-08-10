using System;
using DalInsumos;
using System.Data;
using System.Web.UI.WebControls;
using Highchart.Core;
using Highchart.Core.Data.Chart;
using System.Collections.ObjectModel;
using ExtensionMethods;
using Salud.Security.SSO;


public partial class PedidosH_Consultas_Default : System.Web.UI.Page
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        CargarCombo();
        hcMedicamentos.Controls.Clear();
    }

    private void CargarCombo()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.IdEfectorColumn).IsEqualTo(idEfector);
        d.And(InsDeposito.BajaColumn).IsEqualTo(0);
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();
        ddlDeposito.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        LeerDatos();
    }

    private void LeerDatos()
    {
        hcMedicamentos.Controls.Clear();
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        DateTime finicio = Convert.ToDateTime("01/01/2012");
        DateTime ffin = DateTime.Now.AddDays(1);
        DateTime inicio;
        DateTime fin;
        if (DateTime.TryParse(txtFInicio.Text, out inicio))
            finicio = inicio;
        if (DateTime.TryParse(txtFFin.Text, out fin))
            ffin = fin;
        //int efector = idEfector;
        int dep = Convert.ToInt32(ddlDeposito.SelectedValue);

        //consulta de datos de los 10 insumos mas pedidos. Top 10
        DataTable dt = SPs.InsTopPedidos(idEfector, dep, finicio, ffin).GetDataSet().Tables[0];

        //configuracoes de titulos
        hcMedicamentos.Title = new Title("Insumos mas pedidos en el Depósito");
        hcMedicamentos.SubTitle = new SubTitle("");

        //definicoes de eixos
        hcMedicamentos.YAxis.Add(new YAxisItem { title = new Title("Unidades") });
        hcMedicamentos.XAxis.Add(new XAxisItem { categories = getCategorias(dt) });

        //configuracoes de renderizacoes
        hcMedicamentos.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#dedede", borderRadius = 4 };

        //bind do controle
        hcMedicamentos.DataSource = getSeries(dt);
        hcMedicamentos.DataBind();

        //bindeo la grilla con los datos
        gvEntregas.DataSource = dt;
        gvEntregas.DataBind();
    }

    private string[] getCategorias(DataTable dt)
    {
        string[] categorias = new string[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            categorias[i] = dt.Rows[i][1].ToString();
        }
        return categorias;
    }

    private Collection<Serie> getSeries(DataTable dt)
    {
        var series = new Collection<Serie>();

        for (int i = 1; i < dt.Columns.Count; i++)
        {
            series.Add(new Serie { name = dt.Columns[i].Caption, data = GetValoresColumna(dt, i) });
        }
        return series;
    }

    private object[] GetValoresColumna(DataTable dt, int columna)
    {
        object[] valores = new object[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            valores[i] = dt.Rows[i][columna].ToString().TryParseInt();
        }
        return valores;
    }
}
