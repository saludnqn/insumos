using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using DalInsumos;
using Salud.Security.SSO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;


    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string strIdHospital = SSOHelper.Configuration["idHospital"] as string;

                if (strIdHospital != "0")
                    lnkStyleSheet.Href = "styleHospital.css";
                else
                    lnkStyleSheet.Href = "style.css";
            }
            string strsips = SSOHelper.Configuration["Publicacion_Sips"] as string;
            string strsso = SSOHelper.Configuration["Publicacion_SSO"] as string;
               


            SysEfector efector = null;
            efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            lblUsr.Text = string.Format(" {0}", SSOHelper.CurrentIdentity.Surname + " " + SSOHelper.CurrentIdentity.FirstName);
            lblEfector.Text = string.Format("{0}", efector.Nombre);
            ImgHomeSystem.PostBackUrl = "~/default.aspx";

            //ImgChangePass.PostBackUrl = "/SSO/Options.aspx";
            ImgChangePass.PostBackUrl = "/"+strsso+"/Options.aspx";

            string url = HttpContext.Current.Request.QueryString["url"];
            if (string.IsNullOrEmpty(url))
                url = SSOHelper.Configuration["StartPage"] as string;

            //ImgExit.PostBackUrl = "/SSO/Logout.aspx?relogin=1&url=" + url + "/sips";
            ImgExit.PostBackUrl = "/" + strsso + "/Logout.aspx?relogin=1&url=" + url; // +"/sips";

            ////Armo el menú de la Aplicación seleccionada para el efector seleccionado
            List<SSOMenuItem> menu = SSOHelper.GetApplicationMenuByEfector();
            lvMenuSSO.DataSource = menu[0].items;
            lvMenuSSO.DataBind();

        }

        protected void lvMenuSSO_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListView lv = (ListView)e.Item.FindControl("lstViewSubMenu");
            if (lv != null)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                if (dataItem != null)
                {
                    SSOMenuItem node = (SSOMenuItem)dataItem.DataItem;
                    List<SSOMenuItem> dt = node.items;
                    if (dt.Count > 0)
                    {
                        lv.DataSource = dt;
                        lv.DataBind();
                        HyperLink hl = (HyperLink)lv.Parent.FindControl("hlMenu");
                        if (hl != null)
                            hl.Text = node.text;
                    }
                    else
                    {
                        lv.Visible = false;
                    }
                }
            }
        }
        }



        protected void hkbSesion_Click(object sender, EventArgs e)
        {
            string strsso = SSOHelper.Configuration["Publicacion_SSO"] as string;
            Response.Redirect("~/"+strsso+"/Logout.aspx");
            //Response.Redirect("~/SSO/Logout.aspx");
        }
    }

