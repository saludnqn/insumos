<%@ WebHandler Language="C#" Class="Insumos.Services.Insumo" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DalInsumos;
using fastJSON;
using ExtensionMethods;

using System.Web.UI;
using System.Web.UI.WebControls;


namespace Insumos.Services
{
    /// <summary>
    /// Summary description for usInsumo
    /// </summary>

    [Serializable]
    public class ihelper
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }        
    }

    public class Insumo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context) {

            string consulta = String.IsNullOrEmpty(context.Request.QueryString["term"]) ? "" : context.Request.QueryString["term"];
           
            int rubro = 600;            
            int tipoBusqueda = int.Parse(context.Request["tipoBusqueda"].ToString());
            if (tipoBusqueda == 2)
            {
                rubro = 0;
            }
            List<ihelper> l = SPs.InsRecuperaMedicamentos(rubro, consulta).ExecuteTypedList<ihelper>();

            if (l.Count == 0)
            {
                l.Add(new ihelper() { id = -6660, nombre = "No hay resultados" });
            }
            
            context.Response.Clear();
            context.Response.Write(JSON.Instance.ToJSON(l));
            context.Response.Flush();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }        
    }
}