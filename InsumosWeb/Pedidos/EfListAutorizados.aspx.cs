using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using System.Data;
using SubSonic;

public partial class Pedidos_EfListAutorizados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
         SysUsuario us = new SysUsuario(Session["idUsuario"]);
         if (!us.IsNew)
         {
             int id = SubSonic.Sugar.Web.QueryString<int>("id");
             if (id > 0)
             {
                 CargarPedidos(id);
             }
         }
        else Response.Redirect("~/FinSesion.htm", false);
    }

    private void CargarPedidos(int id)
    {
        //debo traer el pedido para cambiar o no el estado
        InsPedido p = new InsPedido(id);
        lblEfector.Text = p.InsDeposito.SysEfector.Nombre;
        lblDeposito.Text = p.InsDeposito.Nombre;
        lblRubro.Text = p.InsRubro.Nombre;
        //detalle del pedido    
        SubSonic.Select ped = new Select();
        ped.From(Schemas.InsPedido);
        ped.Where(InsPedido.Columns.IdPedido).IsEqualTo(id);

        gvPedidos.DataSource = ped.ExecuteTypedList<InsPedido>();
        gvPedidos.DataBind();
        //gvPedidos.Columns[]
    }

    protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[1].Text)
            {
                case "1":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado1.png";
                        hlE.ToolTip = "Estado Generado";
                    }
                    break;
                case "2":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado2.png";
                        hlE.ToolTip = "Estado Autorizado Parcial";
                    }
                    break;
                case "3":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado3.png";
                        hlE.ToolTip = "Estado Autorizado Total";
                    }
                    break;
                case "4":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado4.png";
                        hlE.ToolTip = "Estado Eliminado";
                    }
                    break;
                case "5":
                    {
                        Image hlE = new Image();
                        hlE = (Image)e.Row.FindControl("imgEstado");
                        hlE.ImageUrl = "../App_Themes/Default/images/estado5.png";
                        hlE.ToolTip = "Estado Finalizado";
                    }
                    break;
            }

            //muestro u oculto las columnas segun autorizacion
            if (e.Row.Cells[5].Text == "True")
            {
                e.Row.Cells[5].Text = "Autorizado y Enviado";
                e.Row.BackColor = System.Drawing.Color.FromName("#bdd9c0");
            }
            else
            {
                e.Row.Cells[5].Text = "No Enviado";
                e.Row.BackColor = System.Drawing.Color.FromName("#eef1d1");
            }
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        //si es posible enviar el parametro del efector
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPedido p = new InsPedido(id);
        int ef = Convert.ToInt32(p.IdEfector);
        Response.Redirect("Edit1.aspx?idE=" + ef);
    }
}
