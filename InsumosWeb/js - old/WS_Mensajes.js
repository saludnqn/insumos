/***********************************************************/
/***********    MENSAJES DE NOVEDADES    *******************/
/***********************************************************/




function leerMensajes() {
    if ($('#divMensajes').is(':visible'))
        $("#divMensajes").hide('fast');
    else
        $("#divMensajes").show('slow');
}

function reportarMensajeLeido(idMensaje) {
    $.ajax({
        type: "POST",
        url: AppPath+'/WS/WsMensajes.asmx/reportarMensajeLeido',
        data: '{idMensaje:' + idMensaje + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#msj_" + idMensaje).parent().parent().remove()
            refreshCounter();
        }
    });
}

function checkForNewMessages(idRol) {
    $.ajax({
        type: "POST",
        url: AppPath+'/WS/WsMensajes.asmx/leerMensajes',
        data: '{idRol: ' + idRol + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#divMensajes").html(msg.d);
            convertTimeAgo();
            refreshCounter();
        }
    });
}

function refreshCounter() {
    var cant = $("#divMensajes table tr").length;
    $("#imagenChat div").html(cant);
    if (cant == 0)
        $("#imagenChat img").attr("src", AppPath+"/images/chat_24_gris.png");
    else
        $("#imagenChat img").attr("src", AppPath+"/images/chat_24_rojo.png");
}

function convertTimeAgo() {
    jQuery.timeago.settings.strings = {
        prefixAgo: "Hace",
        prefixFromNow: "dentro de",
        suffixAgo: "",
        suffixFromNow: "",
        seconds: "menos de un minuto",
        minute: "un minuto",
        minutes: "unos %d minutos",
        hour: "una hora",
        hours: "%d horas",
        day: "un día",
        days: "%d días",
        month: "un mes",
        months: "%d meses",
        year: "un año",
        years: "%d años"
    };
    $("abbr.timeAgo").timeago();
}

/***********************  FIN MENSAJES  ********************/