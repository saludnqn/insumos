using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Drawing;

public partial class UserControls_Rubro : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int getRubro()
    {
        int idRubro;
        if (Int32.TryParse(idR.Value, out idRubro))
        {
            return idRubro;
        }
        else
        {
            return -1;
        }
    }
   
    public void setRubro(int idRubro)
    {
        InsRubro oR = new InsRubro(idRubro);
        if (!oR.IsNew)
        {
            idR.Value = oR.Codigo.ToString();
            lblNombre.Text = oR.Nombre;
        }
        else
        {
            lblNombre.Text = "El Rubro seteado es incorrecto";
        }
    }
}
