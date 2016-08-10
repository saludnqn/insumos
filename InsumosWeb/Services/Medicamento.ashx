<%@ WebHandler Language="C#" Class="Insumos.Services.Medicamento" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DalInsumos;
using fastJSON;
using ExtensionMethods;

namespace Insumos.Services
{
    /// <summary>
    /// Summary description for usInsumo
    /// </summary>

    [Serializable]
    public class mhelper
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }

    public class Medicamento : IHttpHandler
    {
        public void ProcessRequest(HttpContext context) {

            int efector = 1; //efector del usuario
            int dep = 5; //deposito farmacia
            string consulta = String.IsNullOrEmpty(context.Request.QueryString["term"]) ? "" : context.Request.QueryString["term"];

            //solo los insumo con stock
            SubSonic.Select s = new SubSonic.Select("Codigo","Nombre","Descripcion").Top("10");
            s.From(Schemas.InsInsumo);
            s.InnerJoin(Schemas.InsPedido);
            s.InnerJoin(Schemas.InsPedidoDetalle);
            s.Where(InsPedido.IdEfectorColumn).IsEqualTo(efector);
            s.And(InsPedido.IdDepositoColumn).IsEqualTo(dep);
            s.And(InsPedidoDetalle.StockColumn).IsGreaterThan(0);
            s.And(InsInsumo.Columns.Nombre).Like(string.Format("%{0}%", consulta));
            s.Or(InsInsumo.Columns.Descripcion).Like(string.Format("%{0}%", consulta));
            s.OrderAsc("Nombre");
           
            List<InsInsumo> resultados = s.ExecuteTypedList<InsInsumo>();
            List<mhelper> l = new List<mhelper>();

            foreach (InsInsumo item in resultados)
            {
                mhelper h = new mhelper();
                h.id = item.Codigo;
                h.nombre = item.Nombre;
                h.descripcion = item.Descripcion;
                l.Add(h);
            }

            if (l.Count == 0)
            {
                l.Add(new mhelper() { id = -6660, nombre = "No hay resultados" });
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