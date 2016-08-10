using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;

public partial class Proveedores_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
         SysUsuario us = new SysUsuario(Session["idUsuario"]);
         if (!us.IsNew)
         {
             CargarCombo();
             //idProveedor para edicion
             int id = SubSonic.Sugar.Web.QueryString<int>("id");
             if (id > 0)
             {
                 CargarProveedor(id);
             }
         }
         else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarProveedor(int id)
    {
        //cargo un proveedor existente
        InsProveedor pro = new InsProveedor(id);
        if (!pro.IsNew)
        {
            txtCodigo.Text = pro.Codigo;
            txtNombre.Text = pro.Nombre;
            txtDescripcion.Text = pro.Descripcion;
            txtCuit.Text = pro.Cuit;
            txtDomicilio.Text = pro.Domicilio;
            txtTelefono.Text = pro.Telefono;
            ddlTProveedor.SelectedValue = pro.IdTipoProveedor.ToString();
            txtCorreo.Text = pro.Email;
            txtObservaciones.Text = pro.Observaciones;
        }
    }

    private void CargarCombo()
    {
        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoProveedor.Schema);
        ddlTProveedor.DataSource = tp.ExecuteTypedList<InsTipoProveedor>();
        ddlTProveedor.DataBind();
        ddlTProveedor.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {
          SysUsuario us = new SysUsuario(Session["idUsuario"]);
          if (!us.IsNew)
          {
              int id = SubSonic.Sugar.Web.QueryString<int>("id");
              // Page.Validate("1");
              if (DatosValidos(id)) //&& (Page.IsValid))
              {
                  InsProveedor pr = new InsProveedor(id);
                  pr.IdEfector = us.IdEfector;
                  pr.Codigo = txtCodigo.Text;
                  pr.Nombre = txtNombre.Text;
                  pr.Descripcion = txtDescripcion.Text;
                  pr.Domicilio = txtDomicilio.Text;
                  pr.Cuit = txtCuit.Text;
                  pr.Email = txtCorreo.Text;
                  pr.IdTipoProveedor = Convert.ToInt32(ddlTProveedor.SelectedValue);
                  pr.Telefono = txtTelefono.Text;
                  pr.Observaciones = txtObservaciones.Text;
                  pr.Baja = false;
                  pr.Save(us.Username);
                  Response.Redirect("View.aspx?id=" + pr.IdProveedor.ToString());
              }
          }
          else Response.Redirect("~/FinSesion.htm", false);
    }

    private bool DatosValidos(int id)
    {
        SysUsuario us = new SysUsuario(Session["idUsuario"]);
        //verifico si el registro ya existe
        SubSonic.Select p = new SubSonic.Select();
        p.From(InsProveedor.Schema);
        p.Where(InsProveedor.Columns.IdProveedor).IsNotEqualTo(id);
        p.And(InsProveedor.Columns.IdEfector).IsEqualTo(us.IdEfector);
        DataTable dtd = p.ExecuteDataSet().Tables[0];
        //return dtd;
        if (dtd.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
}
