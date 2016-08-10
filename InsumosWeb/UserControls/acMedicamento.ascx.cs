using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;

public partial class UserControls_Medicamento : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int getMedicamentos()
    {
        //return idInsumos.Value;
        int idInsumo;
        if (Int32.TryParse(idInsumos.Value, out idInsumo))
        {
            return idInsumo;
        }
        else
        {
            return -1;
        }
    }

    public void setIns(int id)
    {
        InsInsumo oIns = new InsInsumo(id);
        if (oIns.Codigo > 0)
        {
            idInsumos.Value = oIns.Codigo.ToString();
            lblNombre.Text = oIns.Nombre;
            lblDescripcion.Text = oIns.Descripcion;
        }
        else
        {
            lblNombre.Text = "El Insumo seteado es incorrecto";
        }
    }

    private short _tabIndex;
    public short TabIndex
    {
        get
        {
            return _tabIndex;
        }
        set
        {
            _tabIndex = value;
            txtAutomed.TabIndex = (short)(value);
        }
    }
}
