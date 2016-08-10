<%@ WebHandler Language="C#" Class="Insumos.Services.Cie10" %>

using System;
using System.Web;
using System.Collections.Generic;
using fastJSON;
using DalInsumos;

namespace Insumos.Services
{

    [Serializable]
    public class cie10helper
    {
        public int id { get; set; }
        public string causa { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string capitulo { get; set; }
    }

    public class Cie10 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string consulta = String.IsNullOrEmpty(context.Request.QueryString["term"]) ? "" : context.Request.QueryString["term"];
            string tipoBusqueda = context.Request["tipoBusqueda"].ToString();
            string stringFormat = "{0}%";
            if (tipoBusqueda == "1")//que comience con
                stringFormat = "{0}%";
            else // que contenga
                stringFormat = "%{0}%";


            SysCIE10Collection oCie10s = new SubSonic.Select()
            .From(Schemas.SysCIE10)
            //.Where(SysCIE10.Columns.Sinonimo).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            .Where(SysCIE10.Columns.Codigo).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            .Or(SysCIE10.Columns.Nombre).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            .Or(SysCIE10.Columns.DescripCap).Like(String.Format(stringFormat, consulta.Replace('*', '%')))            
            .OrderAsc(SysCIE10.Columns.Nombre)
            .ExecuteAsCollection<SysCIE10Collection>();

            List<cie10helper> codigos = new List<cie10helper>();

            foreach (SysCIE10 oCie10 in oCie10s)
            {
                cie10helper cie = new cie10helper();
                cie.id = oCie10.Id;
                cie.nombre = oCie10.Sinonimo;
                cie.causa = oCie10.Causa;
                cie.codigo = oCie10.Codigo + " " + oCie10.Nombre;
                cie.capitulo = oCie10.DescripCap;

                codigos.Add(cie);
            }
            if (codigos.Count == 0)
            {
                codigos.Add(new cie10helper() { id = -666, nombre = "No hay resultados", codigo = "", capitulo = "" });
            }
            context.Response.Clear();
            context.Response.Write(JSON.Instance.ToJSON(codigos));
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