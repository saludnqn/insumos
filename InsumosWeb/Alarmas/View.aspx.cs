using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;

public partial class Alarmas_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsAlarma ida = new InsAlarma(id);

        if (!ida.IsNew)
        {
            lblMedicamento.Text = ida.InsInsumo.Nombre;
            if (ida.Baja == false) lblAlarma.Text = "Si";
            else lblAlarma.Text = "No";
            lblMinimo.Text = ida.CantidadMinima.ToString();
            lblDias.Text = ida.DiasVencimiento.ToString();
        }
    }

}
