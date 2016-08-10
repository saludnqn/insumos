using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Drawing;


public partial class UserControls_ObraSocial : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int Rubro { get; set; }

    public int getObraSocial()
    {
        int idO;
        if (Int32.TryParse(idOS.Value, out idO))
        {
            return idO;
        }
        else
        {
            return -1;
        }
    }

    public void setOS(int idOso)
    {
        SysObraSocial oOs = new SysObraSocial(idOso);
        if (!oOs.IsNew)
        {
            idOS.Value = oOs.ToString();
            lblNombre.Text = oOs.Nombre;
            lblSigla.Text = oOs.Sigla;
            lblCodigoNacion.Text = oOs.CodigoNacion;
        }
        else
        {
            lblNombre.Text = "La Obra Social seteada es incorrecta";
        }
    } 
}
