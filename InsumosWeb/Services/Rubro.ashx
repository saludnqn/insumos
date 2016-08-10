<%@ WebHandler Language="C#" Class="Insumos.Services.Rubro" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using fastJSON;


namespace Insumos.Services
{
    [Serializable()]
    public class rhelper
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class Rubro : IHttpHandler
    {
          public void ProcessRequest (HttpContext context) {
          string consulta = String.IsNullOrEmpty(context.Request.QueryString["term"]) ? "" : context.Request.QueryString["term"];

            SubSonic.Select s = new SubSonic.Select();
            s.From(Schemas.InsRubro);
            s.Where(InsRubro.Columns.Nombre).Like(string.Format("%{0}%", consulta));
            //s.And(InsRubro.Columns.Baja).IsEqualTo(0);
           
            List<InsRubro> resultados = s.ExecuteTypedList<InsRubro>();
            List<rhelper> l = new List<rhelper>();

            foreach (InsRubro item in resultados)
            {
                rhelper h = new rhelper();
                h.id = item.Codigo;
                h.nombre = item.Nombre;
                l.Add(h);
            }

            if (l.Count == 0)
            {
                l.Add(new rhelper() { id = -666, nombre = "No hay resultados" });
            }
            
            context.Response.Clear();
            context.Response.Write(JSON.Instance.ToJSON(l));
            context.Response.Flush();
            context.Response.End();
    }
    
    public bool IsReusable {
            get
            {
                return false;
            }
        }
    }   
}