using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;


public partial class DatosFarmaceuticos_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //id para edicion
        int idInsumo = SubSonic.Sugar.Web.QueryString<int>("idI");
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarDatosFarmacia(id);
        }
        if (idInsumo > 0)
        {
            CargarDatosInsumo(idInsumo);
        }
    }

    private void CargarDatosInsumo(int idInsumo)
    {
        SubSonic.Select s = new SubSonic.Select();
        s.From(InsDatoFarmaceutico.Schema);
        s.Where(InsDatoFarmaceutico.Columns.IdInsumo).IsEqualTo(idInsumo);

        InsDatoFarmaceutico df = s.ExecuteSingle<InsDatoFarmaceutico>();
        if (df == null)
            acMedicamento.setIns(idInsumo);
        else {
            CargarDatosFarmacia(df.IdDatoFarmaceutico);
        }
    }

    private void CargarDatosFarmacia(int id)
    {
        InsDatoFarmaceutico df = new InsDatoFarmaceutico(id);
        if (!df.IsNew)
        {
            lblInsumo.Text = df.InsInsumo.Nombre;
            acMedicamento.setIns(df.IdInsumo);
            if (df.NecesitaReceta == true) ckbReceta.Checked = true;
            else ckbReceta.Checked = false; 
            txtCodigo.Text = df.CodigoOMS;
            ddlComplejidad.SelectedValue = df.NivelComplejidad.ToString();
            txtATerapeutica.Text = df.AccionTerapeutica;
            txtComposicion.Text = df.Composicion;
            txtContraindicaciones.Text = df.Contraindicaciones;
            df.Baja = false;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        // Page.Validate("1");
        if (DatosValidos(id)) //&& (Page.IsValid))
        {
            InsDatoFarmaceutico datf = new InsDatoFarmaceutico(id);

            datf.IdInsumo = Convert.ToInt32(acMedicamento.getMedicamentos());
            if (ckbReceta.Checked == true) datf.NecesitaReceta = true;
            else datf.NecesitaReceta = false;
            datf.CodigoOMS = txtCodigo.Text;
            datf.NivelComplejidad = Convert.ToInt32(ddlComplejidad.SelectedValue);
            datf.Composicion = txtComposicion.Text;
            datf.Contraindicaciones = txtContraindicaciones.Text;
            datf.AccionTerapeutica = txtATerapeutica.Text;
            datf.IdEfector = 1;
            datf.Baja = false;
            datf.Save();
            Response.Redirect("View.aspx?id=" + datf.IdDatoFarmaceutico.ToString());
        }
    }

    private bool DatosValidos(int id)
    {
        SubSonic.Select dat = new SubSonic.Select();
        dat.From(InsDatoFarmaceutico.Schema);
        dat.Where(InsDatoFarmaceutico.Columns.IdDatoFarmaceutico).IsNotEqualTo(id);
        DataTable dtd = dat.ExecuteDataSet().Tables[0];
        if (dtd.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
}
