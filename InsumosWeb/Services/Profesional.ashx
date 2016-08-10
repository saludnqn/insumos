<%@ WebHandler Language="C#" Class="Insumos.Services.Profesional" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using fastJSON;
using DalInsumos;
using System.Collections.Generic;

using System.Linq;

using System.Web.UI;
using System.Web.UI.WebControls;


namespace Insumos.Services
{

    [Serializable]
    public class phelper
    {
        public int id { get; set; }
        public string nombreCompleto { get; set; }
    }

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class Profesional : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string consulta = String.IsNullOrEmpty(context.Request.QueryString["term"]) ? "" : context.Request.QueryString["term"];

            SysProfesionalCollection prof = new SubSonic.Select().Top("10")
                .From(Schemas.SysProfesional)
                .Where(SysProfesional.Columns.NombreCompleto)
                .Like(String.Format("%{0}%", consulta.Replace('*', '%')))
                .Or(SysProfesional.Columns.NombreCompleto).Like(String.Format("%{0}%", consulta.Replace('*', '%')))
                .Or(SysProfesional.Columns.ApellidoyNombre).Like(String.Format("%{0}%", consulta.Replace('*', '%')))
                .ExecuteAsCollection<SysProfesionalCollection>();

            List<phelper> lstOS = new List<phelper>();

            foreach (SysProfesional P in prof)
            {
                phelper ph = new phelper();
                ph.id = P.IdProfesional;
                ph.nombreCompleto = P.NombreCompleto;
                lstOS.Add(ph);
            }
            if (lstOS.Count == 0)
            {
                lstOS.Add(new phelper() { id = -666, nombreCompleto = "No hay resultados"});
            }
            context.Response.Clear();
            context.Response.Write(JSON.Instance.ToJSON(lstOS));
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