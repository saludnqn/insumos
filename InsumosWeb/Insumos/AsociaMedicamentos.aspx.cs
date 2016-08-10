using System;
using System.Web.UI;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class Insumos_AsociaMedicamentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idInsumo = SubSonic.Sugar.Web.QueryString<int>("idInsumo");
        lblEtiqueta.Text = "";
        if (idInsumo > 0)
        {
            CargarAsociados(idInsumo);
        }
    }

    private void CargarAsociados(int idInsumo)
    {
        if (idInsumo > 0)
        {
            idAsociados.Visible = true;
            InsInsumo oIns = new InsInsumo(idInsumo);
            Insumo1.setIns(idInsumo);
            lblEtiqueta.Text = oIns.Codigo + "-" + oIns.Nombre;

            SubSonic.Select s = new SubSonic.Select("idAsociacion", "idInsumoOrigen", "idInsumoEquivalente", "fechaAsociacion");
            s.From(InsInsumosEquivalente.Schema);
            s.InnerJoin(InsInsumo.Schema);
            s.Where(InsInsumosEquivalente.Columns.IdInsumoOrigen).IsEqualTo(idInsumo);

            gvMedicamentosAsociados.DataSource = s.ExecuteAsCollection<InsInsumosEquivalenteCollection>();
            gvMedicamentosAsociados.DataBind();
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int idA = SubSonic.Sugar.Web.QueryString<int>("idA");
        if ((Page.IsValid) && (DatosValidos()))
        {
            InsInsumosEquivalente asoc = new InsInsumosEquivalente(idA);
            
            asoc.IdInsumoOrigen = Insumo1.getInsumo();
            asoc.IdInsumoEquivalente = InsumoAsocia.getInsumo();
            asoc.FechaAsociacion = DateTime.Now;
            asoc.Activo = true;
            //asoc.InsInsumoToIdInsumoOrigen
            if ((asoc.IdInsumoOrigen != -1) && (asoc.IdInsumoEquivalente != -1))
            {
                asoc.Save();
                //Response.Redirect("AsociaMedicamentos.aspx?idA=" + asoc.IdAsociacion.ToString() + "&idInsumo=" + asoc.IdInsumoOrigen);
                Response.Redirect("AsociaMedicamentos.aspx?idInsumo=" + asoc.IdInsumoOrigen);
                //Response.Redirect("ConsultaAsociados.aspx?idInsumo=" + asoc.IdInsumoOrigen);
            }
            else
            {
                string alertjs = @"<script language='javascript'> alert('Debe seleccionar los medicamentos que va asociar!'); </script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
            }


        }
    }

    private bool DatosValidos()
    {
        SubSonic.Select amed = new SubSonic.Select();
        amed.From(InsInsumosEquivalente.Schema);
        amed.Where(InsInsumosEquivalente.Columns.IdInsumoOrigen).IsEqualTo(Insumo1.getInsumo());
        amed.And(InsInsumosEquivalente.Columns.IdInsumoEquivalente).IsEqualTo(InsumoAsocia.getInsumo());
        DataTable dt = amed.ExecuteDataSet().Tables[0];
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        return true;
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}
