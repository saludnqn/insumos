using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using Salud.Security.SSO;


public partial class Alarmas_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idInsumo = SubSonic.Sugar.Web.QueryString<int>("idI");
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarDatosAlarma(id);
        }
        if (idInsumo > 0)
        {
            CargarDatosInsumo(idInsumo);
        }
    }

    private void CargarDatosInsumo(int idInsumo)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select s = new SubSonic.Select();
        s.From(InsAlarma.Schema);
        s.Where(InsAlarma.Columns.IdInsumo).IsEqualTo(idInsumo);
        s.And(InsAlarma.IdEfectorColumn).IsEqualTo(idEfector);

        InsAlarma a = s.ExecuteSingle<InsAlarma>();
        if (a == null)
        {
            acMedicamento.setIns(idInsumo);
        }
        else
        {
            CargarDatosAlarma(a.IdAlarma);
        }
    }

    private void CargarDatosAlarma(int id)
    {
        InsAlarma a = new InsAlarma(id);
        if (!a.IsNew)
        {
            acMedicamento.setIns(a.IdInsumo);
            lblInsumo.Text = a.InsInsumo.Nombre;
            if (a.Baja == true) ckbAlarma.Checked = true;
            else ckbAlarma.Checked = false; //uso el campo baja para traer o no el dato de las alarmas
            txtCantidadMinima.Text = a.CantidadMinima.ToString();
            txtDiasVto.Text = a.DiasVencimiento.ToString();
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        // Page.Validate("1");
        if (DatosValidos(id)) //&& (Page.IsValid))
        {
            InsAlarma a = new InsAlarma(id);
            a.IdInsumo = Convert.ToInt32(acMedicamento.getMedicamentos());
            // uso el dato de la baja para activar o no la alarma
            if (ckbAlarma.Checked) a.Baja = false;
            else a.Baja = true;
            a.IdEfector = idEfector; // efector de prueba
            a.IdInsumo = Convert.ToInt32(acMedicamento.getMedicamentos());
            a.CantidadMinima = Convert.ToInt32(txtCantidadMinima.Text);
            a.DiasVencimiento = Convert.ToInt32(txtDiasVto.Text);
            a.Save();
            Response.Redirect("View.aspx?id=" + a.IdAlarma.ToString());
        }
    }

    private bool DatosValidos(int id)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int idInsumo = Convert.ToInt32(acMedicamento.getMedicamentos());

        SubSonic.Select dat = new SubSonic.Select();
        dat.From(InsAlarma.Schema);
        dat.Where(InsAlarma.Columns.IdInsumo).IsEqualTo(idInsumo);
        dat.And(InsAlarma.Columns.IdEfector).IsEqualTo(idEfector);
        DataTable dtd = dat.ExecuteDataSet().Tables[0];
        if (dtd.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

}
