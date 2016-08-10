using System;
using DalInsumos;

public partial class Depositos_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //traigo los datos del Nuevo Deposito
            int id = Convert.ToInt32(Request.QueryString["id"]);
            InsDeposito dep = new InsDeposito(id);

            if (!dep.IsNew)
            {
                lblEfector.Text = dep.SysEfector.Nombre;
                if (dep.IdServicio == 0) lblServicio.Text = "-";
                else lblServicio.Text = dep.SysServicio.Nombre;
                if (dep.IdDepositoSuperior == 0) lblDepSuperior.Text = "-";
                else lblDepSuperior.Text = dep.ParentInsDeposito.Nombre; //*
                lblTipoDep.Text = dep.InsTipoDeposito.Nombre;
                lblDeposito.Text = dep.Nombre;
                lblDescripcion.Text = dep.Descripcion;
                if (dep.Observacion == "") lblObservaciones.Text = "-";
                else lblObservaciones.Text = dep.Observacion;
                if (dep.Baja == true) lblActivo.Text = "Depósito Dado de Baja - Sin listar";
                else lblActivo.Text = "Depósito Activo";
            }
        }
        else Response.Redirect("FinSesion.htm", false);   
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx", false);
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id == 0) Response.Redirect("Edit.aspx");
        else
        {
            Response.Redirect("Edit.aspx?id=" + id.ToString());
        }
    }

}
