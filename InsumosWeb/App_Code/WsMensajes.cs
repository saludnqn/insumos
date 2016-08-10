using DalInsumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


//namespace Salud.Applications.Guardia
//{
/// <summary>
/// Summary description for WsMensajes
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WsMensajes : System.Web.Services.WebService
{
    [WebMethod]
    public string leerMensajes(int idRol)
    {
        string retorno = "<div class='tituloNovedades'>Novedades.</div>";
        retorno += "<table>";


        //solo traigo los mensajes destinados a las vistas, falta hacer lo de los usuarios
        SubSonic.Select p = new SubSonic.Select().Top("10");
        p.From(InsMensaje.Schema);
        p.Where(InsMensaje.Columns.IdTipoDestino).IsEqualTo(idRol);
        //filtrar por el id del rol obtenido de sso_storedvariables
        //p.And(SysPaciente.Columns.Nombre).Like(String.Format("%{0}%", txtNombre.Text));
        //p.And(SysPaciente.Columns.Activo).IsEqualTo(true);
        //p.OrderAsc("Apellido");



        var mensajes = p.ExecuteTypedList<InsMensaje>();

        retorno += mensajes.Count() == 0 ? "No hay mensajes nuevos." : "";

        foreach (var msj in mensajes.OrderByDescending(f => f.Fecha))
        {
            retorno += "<tr><td>";
            string tiempo = "<abbr class='timeAgo' title='" + msj.Fecha.ToString("yyyy-MM-ddTHH:mm:ss") + "'>" + msj.Fecha.ToString() + "</abbr>";
            /*switch (msj.id_tipo)
            {
                case (int)Constantes.TiposMensajes.Arancelar:
                    Guardia_Registro reg = (from d in dc.Guardia_Registros.Where(w => w.id == Convert.ToInt32(msj.data)) select d).Single();
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El paciente <em>" + reg.Sys_Paciente.apellido.Trim() + ", " + reg.Sys_Paciente.nombre.Trim() + "</em> puede ser arancelado.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick='mostrarArancelamiento(" + msj.data + "); reportarMensajeLeido(" + msj.id + ");'>Arancelar</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
                case (int)Constantes.TiposMensajes.Internacion:
                    Guardia_Registro reg2 = (from d in dc.Guardia_Registros.Where(w => w.id == Convert.ToInt32(msj.data)) select d).Single();
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El médico " + Salud.Applications.Guardia.Common.getSsoFullName(msj.id_userSend.Value) + " indicó <b>INTERNACION</b> al paciente <em>" + reg2.Sys_Paciente.apellido.Trim() + ", " + reg2.Sys_Paciente.nombre.Trim() + "</em>.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick=\"mostrarOperacion(" + msj.data + ", \'registroEgresar.aspx?id=" + msj.data + "&EgresoSugerido=" + (int)Constantes.TiposMensajes.Internacion + "\'); reportarMensajeLeido(" + msj.id + ");\">Egresar</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
                case (int)Constantes.TiposMensajes.Derivacion:
                    Guardia_Registro reg3 = (from d in dc.Guardia_Registros.Where(w => w.id == Convert.ToInt32(msj.data)) select d).Single();
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El médico " + Salud.Applications.Guardia.Common.getSsoFullName(msj.id_userSend.Value) + " indicó <b>DERIVACION</b> al paciente <em>" + reg3.Sys_Paciente.apellido.Trim() + ", " + reg3.Sys_Paciente.nombre.Trim() + "</em>.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick=\"mostrarOperacion(" + msj.data + ", \'registroEgresar.aspx?id=" + msj.data + "&EgresoSugerido=" + (int)Constantes.TiposMensajes.Derivacion + "\'); reportarMensajeLeido(" + msj.id + ");\">Egresar</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
                case (int)Constantes.TiposMensajes.Traslado:
                    Guardia_Registro reg4 = (from d in dc.Guardia_Registros.Where(w => w.id == Convert.ToInt32(msj.data)) select d).Single();
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El médico " + Salud.Applications.Guardia.Common.getSsoFullName(msj.id_userSend.Value) + " indicó <b>TRASLADO</b> al paciente <em>" + reg4.Sys_Paciente.apellido.Trim() + ", " + reg4.Sys_Paciente.nombre.Trim() + "</em>.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick=\"mostrarOperacion(" + msj.data + ", \'registroEgresar.aspx?id=" + msj.data + "&EgresoSugerido=" + (int)Constantes.TiposMensajes.Traslado + "\'); reportarMensajeLeido(" + msj.id + ");\">Egresar</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
                case (int)Constantes.TiposMensajes.Defuncion:
                    Guardia_Registro reg5 = (from d in dc.Guardia_Registros.Where(w => w.id == Convert.ToInt32(msj.data)) select d).Single();
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El médico " + Salud.Applications.Guardia.Common.getSsoFullName(msj.id_userSend.Value) + " indicó <b>DEFUNCION</b> al paciente <em>" + reg5.Sys_Paciente.apellido.Trim() + ", " + reg5.Sys_Paciente.nombre.Trim() + "</em>.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick=\"mostrarOperacion(" + msj.data + ", \'registroEgresar.aspx?id=" + msj.data + "&EgresoSugerido=" + (int)Constantes.TiposMensajes.Defuncion + "\'); reportarMensajeLeido(" + msj.id + ");\">Egresar</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
                case (int)Constantes.TiposMensajes.RetiroVoluntarioPreAtencios:
                    Guardia_Registro reg6 = (from d in dc.Guardia_Registros.Where(w => w.id == Convert.ToInt32(msj.data)) select d).Single();
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El médico " + Salud.Applications.Guardia.Common.getSsoFullName(msj.id_userSend.Value) + " indicó <b>RETIRO VOLUNTARIO PRE-ATENCION</b> al paciente <em>" + reg6.Sys_Paciente.apellido.Trim() + ", " + reg6.Sys_Paciente.nombre.Trim() + "</em>.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick=\"mostrarOperacion(" + msj.data + ", \'registroEgresar.aspx?id=" + msj.data + "&EgresoSugerido=" + (int)Constantes.TiposMensajes.RetiroVoluntarioPreAtencios + "\'); reportarMensajeLeido(" + msj.id + ");\">Egresar</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
                case (int)Constantes.TiposMensajes.RetiroVoluntarioPostAtencion:
                    Guardia_Registro reg7 = (from d in dc.Guardia_Registros.Where(w => w.id == Convert.ToInt32(msj.data)) select d).Single();
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El médico " + Salud.Applications.Guardia.Common.getSsoFullName(msj.id_userSend.Value) + " indicó <b>RETIRO VOLUNTARIO POST-ATENCION</b> al paciente <em>" + reg7.Sys_Paciente.apellido.Trim() + ", " + reg7.Sys_Paciente.nombre.Trim() + "</em>.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick=\"mostrarOperacion(" + msj.data + ", \'registroEgresar.aspx?id=" + msj.data + "&EgresoSugerido=" + (int)Constantes.TiposMensajes.RetiroVoluntarioPostAtencion + "\'); reportarMensajeLeido(" + msj.id + ");\">Egresar</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
                case (int)Constantes.TiposMensajes.RecordatorioImprPlanMed:
                    retorno += "<div class='mensaje_mensaje' id='msj_" + msj.id + "'>El médico " + Salud.Applications.Guardia.Common.getSsoFullName(msj.id_userReceive.Value) + " se encuentra próximo a finalizar su turno. Recuerde imprimir su planilla de atenciones en guardia.</div>";
                    retorno += "<div class='mensaje_operaciones'>" + tiempo + "<a href='#' onClick=\"popupOpen(\'toolTipImprimirPlanillaMedicos.aspx?id_RecordatorioImprPlanMed=" + msj.data + "'); reportarMensajeLeido(" + msj.id + ");\">Imprimir</a><a href='#' onClick='reportarMensajeLeido(" + msj.id + ")'>Ocultar</a></div>";
                    break;
            }*/
            retorno += "</td></tr>";
        }

        retorno += "</table>";

        return retorno;
    }

    [WebMethod]
    public bool reportarMensajeLeido(int idMensaje)
    {
        bool retorno = false;
        /*using (HospitalDataContext dc = new HospitalDataContext())
        {
            if (dc.Guardia_Mensajes.Where(w => w.id == idMensaje).Count() == 1)
            {
                Guardia_Mensaje msj = dc.Guardia_Mensajes.First(w => w.id == idMensaje);
                msj.readed = true;
                msj.fechaReaded = DateTime.Now;
                msj.id_userReaded = Security.SSO.SSOHelper.CurrentIdentity.Id;
                dc.SubmitChanges();
                retorno = true;
            }
        }*/
        return retorno;
    }
}
//}
