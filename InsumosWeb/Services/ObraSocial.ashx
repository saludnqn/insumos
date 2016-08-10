<%@ WebHandler Language="C#" Class="ObraSocial" %>

using System;
using System.Web;
using System.Web.Services;
using fastJSON;
using DalInsumos;
using System.Collections.Generic;


[Serializable]
public class oshelper
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string sigla { get; set; }
    public string codigoNacion { get; set; }
}


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class ObraSocial : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        string consulta = String.IsNullOrEmpty(context.Request.QueryString["term"]) ? "" : context.Request.QueryString["term"];

        SysObraSocialCollection oSociales = new SubSonic.Select().Top("10")
            .From(Schemas.SysObraSocial)
            .Where(SysObraSocial.Columns.Nombre)
            .Like(String.Format("%{0}%", consulta.Replace('*', '%')))
            .Or(SysObraSocial.Columns.Sigla).Like(String.Format("%{0}%", consulta.Replace('*', '%')))
            .Or(SysObraSocial.Columns.CodigoNacion).Like(String.Format("%{0}%", consulta.Replace('*', '%')))
            .ExecuteAsCollection<SysObraSocialCollection>();

        List<oshelper> lstOS = new List<oshelper>();

        foreach (SysObraSocial OS in oSociales)
        {
            oshelper osh = new oshelper();
            osh.id = OS.IdObraSocial;
            osh.nombre = OS.Nombre;
            osh.sigla = OS.Sigla;
            osh.codigoNacion = OS.CodigoNacion;
            lstOS.Add(osh);
        }
        if (lstOS.Count == 0)
        {
            lstOS.Add(new oshelper() { id = -666, nombre = "No hay resultados", sigla = "", codigoNacion = "" });
        }
        context.Response.Clear();
        context.Response.Write(JSON.Instance.ToJSON(lstOS));
        context.Response.Flush();
        context.Response.End();
    
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}