using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DalInsumos;

public partial class UserControls_InsumoxRubroxEfector : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int getInsumo()
    {
        int idI;
        if (Int32.TryParse(idIns.Value, out idI))
        {
            return idI;
        }
        else
        {
            return -1;
        }
    }

    public void setIns(int id)
    {
        InsInsumo oIns = new InsInsumo(id);
        if (!oIns.IsNew)
        {
            idIns.Value = oIns.ToString();
            lblCodigo.Text = oIns.Codigo.ToString();
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
            txtAutoI.TabIndex = (short)(value);
        }
    }

    private int _IdRubro;
    public int IdRubro
    {
        get
        {
            return _IdRubro;
        }
        set
        {
            _IdRubro = value;
            hfIdRubro.Value = value.ToString();
        }
    }

    private int _IdEfector;
    public int IdEfector
    {
        get
        {
            return _IdEfector;
        }
        set
        {
            _IdEfector = value;
            hfIdEfector.Value = value.ToString();
        }
    }
}
