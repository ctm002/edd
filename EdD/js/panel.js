
var dato_msg;
function mostrar_bienvenida() {
    idusuario = $.cookie("IdMaestroUsuario");
    if (dato_msg) { dato_msg.abort(); }
    var param = '{' + '"usuario":' + '"' + idusuario + '"' + '}';
    //alert(param);
    strhtml = "";
    urlmod = "Servicios/edddatosperf.asmx/lee_mensaje";
    dato_msg = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "text",
        success: function (data) {
            var obj = JSON.parse(data);
            strhtml = obj.d;
        },
        error: function (data) {
            alert("Error Datos Evaluacion");
        }
    });
    
    if (strhtml == "") return;
    strhtmltxt = '<div style="overflow-x:hidden; overflow-y:visible; font-family: Arial; font-size: 12px;">' + strhtml;
    strhtmltxt += '</div>';
    $("#dialogobienvenida").html(strhtmltxt);

    $("#dialogobienvenida").dialog({
        position: { my: "center center" },
        resizable: false,
        height: 350,
        width: 600,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        modal: true,
        buttons: {
            "Salir": function () {
                $(this).dialog("close");
            }
        }
    });
}

function detalle_pendiente() {
    lee_estado_obj();
    lee_estado_comp();

    if ($.cookie("estado_obj"))
        estado = $.cookie("estado_obj");
    else estado = 0;
    //alert(estado);
    strhtml="";
    if (estado == 0) {
        color1 = '<div style="color:#064e74;"></p>';
        color2 = '<div style="color:#064e74;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 1) {
        color1 = '<div style="color:#064e74;"></p>';
        color2 = '<div style="color:#064e74;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 2) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:#064e74;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 3 || estado==31) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:#064e74;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 4) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:#064e74;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 5) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:green;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 6 || estado==61) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:green;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 7) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:green;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    else if (estado == 8) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:green;"></p>';
        color3 = '<div style="color:green;"></p>';
    }
    else if (estado == 9) {
        color1 = '<div style="color:green;"></p>';
        color2 = '<div style="color:green;"></p>';
        color3 = '<div style="color:#064e74;"></p>';
    }
    
    strhtml = "<p>"+color1+"Establecimiento de Objetivos</div><p>";
    strhtml += "<p>"+color2+"Evaluación de Mitad de Año</div><p>";
    strhtml += "<p>"+color3+"Evaluación de Fin de Año</div><p>";

    strhtmlcomp = "";
    if ($.cookie("estado_comp"))
        estadocomp = $.cookie("estado_comp");
    else estadocomp = 0;
    //alert(estadocomp);

    if (estadocomp == 0 ) {
            strhtmlcomp = "<p></p>";
    }
    else if (estadocomp == 1 ) {
        strhtmlcomp = "<p></p>";
    } else if (estadocomp == 2 ) {
        strhtmlcomp = "<p></p>";
    }
    else if (estadocomp == 3 || estadocomp==31) {
        strhtmlcomp = "<p></p>";
    }
    else if (estadocomp == 4) {
        strhtmlcomp = "<p></p>";
    } else {
        strhtmlcomp = "<p></p>"
    }

    strhtml = strhtml + strhtmlcomp;

    $("#detpendiente").html(strhtml);
}

var dato_log;
function detalle_revisar() {
 if (dato_log) { dato_log.abort(); }
 usuario = $.cookie("IdMaestroUsuario");
 var param = '{' + '"usuario":' + '"' + usuario + '"}';
 urlmod = "Servicios/edddatosperf.asmx/lee_log";
 //alert(usuario);
 dato_log = $.ajax({
     url: urlmod,
     async: false,
     data: param,
     type: "POST",
     contentType: "application/json; charset=utf-8",
     dataType: "json",
     success: function (data) {
         strhtml = "<table>";
         strhtml += "<tr><td style='width:130px;'>Nombre</td><td style='width:220px;'>Etapa del Proceso</td><td style='width:70px;'>Documento en</td><td style='width:70px;'>Fecha</td></tr>";
         for (var i = 0; i < data.d.length; i++) {
             strhtml += "<tr><td>" + data.d[i].usuario_nombre + "</td>";
             strhtml += "<td>" + data.d[i].log_actividad + "</td>";
             strhtml += "<td>" + data.d[i].log_estado + "</td>";
             strhtml += "<td>" + data.d[i].log_fecha.substr(0,10) + "</td></tr>";             
         }
         strhtml += "</table>";
         $("#detrevisar").html(strhtml);
     },
     error: function (data) {
         alert("Error Lee Datos Log");
     }
 });
}

function detalle_realizado() {
    lee_estado_obj();
    lee_estado_comp();
    if ($.cookie("estado_obj"))
        estado = $.cookie("estado_obj");
    else estado = 0;
    strhtml = "";
    if (estado == 0) {
        strhtml = "";
    }
    else if (estado == 1) {
        strhtml = "<p>Objetivos Inicial enviado a Jefatura</p>";
    }
    else if (estado == 2) {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
    }
    else if (estado == 3) {
        strhtml = "<p>Objetivos Inicial Rechazado</p>";
    }
    else if (estado == 4) {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
        strhtml += "<p>Objetivos Intermedio enviado a Jefatura</p>";
    }
    else if (estado == 5) {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
        strhtml += "<p>Objetivos Intermedio Aprobado</p>";
    }
    else if (estado == 6) {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
        strhtml += "<p>Objetivos Intermedio Rechazado</p>";
    }
    else if (estado == 7) {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
        strhtml += "<p>Objetivos Intermedio Aprobado</p>";
        strhtml += "<p>Objetivos Final enviado a Jefatura</p>";
    }
    else if (estado == 8) {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
        strhtml += "<p>Objetivos Intermedio Aprobado</p>";
        strhtml += "<p>Objetivos Final Aprobado</p>";
    }
    else if (estado == 9) {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
        strhtml += "<p>Objetivos Intermedio Aprobado</p>";
        strhtml += "<p>Objetivos Final Rechazado</p>";
    }
    else {
        strhtml = "<p>Objetivos Inicial Aprobado</p>";
        strhtml += "<p>Objetivos Intermedio Aprobado</p>";
        strhtml += "<p>Objetivos Final Aprobado</p>";
    }

    if ($.cookie("estado_comp"))
        estadocomp = $.cookie("estado_comp");
    else estadocomp = 0;
    strhtmlcomp = "";
    if (estadocomp == 0) {
        strhtmlcomp = "<p></p>";
    }
    else if (estadocomp == 1) {
        strhtmlcomp = "<p>Competencias Inicial enviado a Jefatura</p>";
    }
    else if (estadocomp == 2 ) {
        strhtmlcomp = "<p>Competencias Inicial Aprobado</p>";
    }
    else if (estadocomp == 3) {
        strhtmlcomp = "<p>Competencias Inicial Rechazado</p>";
    }
    else if ( estadocomp == 31) {
        strhtmlcomp = "<p>Competencias Inicial a Revisión</p>";
    }
    else if (estadocomp == 4) {
        strhtmlcomp = "<p>Competencias Inicial Aprobado</p>";
        strhtmlcomp += "<p>Competencias Final enviado a Jefatura</p>";
    }
    else if (estadocomp == 5) {
        strhtmlcomp = "<p>Competencias Inicial Aprobado</p>";
        strhtmlcomp += "<p>Competencias Final Aprobado</p>";
    }
    else if ( estadocomp == 7 ) {
        strhtmlcomp = "<p>Competencias Inicial Aprobado</p>";
        strhtmlcomp += "<p>Competencias Final Aprobado</p>";
    }
    else if (estadocomp == 61) {
        strhtmlcomp = "<p>Competencias Inicial Aprobado</p>";
        strhtmlcomp += "<p>Competencias Final a Revisión</p>";
    } else {
        strhtmlcomp = "<p></p>"
    }
    //alert(strhtml); alert(strhtmlcomp);
    strhtml = strhtml + strhtmlcomp;
    $("#detrealizado").html(strhtml);
}

var dato_bvd;
function detalle_bienvenida() {
    if (dato_bvd) { dato_bvd.abort(); }
    strhtml = "";
    urlmod = "Servicios/edddatosperf.asmx/lee_bienvenida";
    dato_bvd = $.ajax({
        url: urlmod,
        async: false,
        data: {},
        type: "POST",
        contentType: "application/json; charset=utf-8",
         dataType: "text",
        success: function (data) {
            var obj = JSON.parse(data);
            strhtml = obj.d;
        },
        error: function (data) {
            alert("Error Datos Evaluacion");
        }
     });
    strhtmlpres ="<br>Bienvenid@ "+$.cookie("Nombre")+"<br><p>"+strhtml+"<p>"; 
    if (strhtml == "") return;
    strhtml = '<div style="overflow-x:hidden; overflow-y:visible; font-family: Arial; font-size: 12px;">' + strhtmlpres;
    strhtml += '</div>';
    $("#detbienvenida").html(strhtml);
}

var dato_comp;
function lee_estado_comp() {
    if (dato_comp) { dato_comp.abort(); }
    usuario = $.cookie("IdMaestroUsuario");
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    //alert(param);
    urlmod = "Servicios/edddatosperf.asmx/lee_estado_comp";
    dato_comp = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.cookie("estado_comp", data.d);
            //alert($.cookie("estado_obj"));
        },
        error: function (data) {
            alert("Error Datos Estado");
        }
    });
}

// REVISAR ELIMINAR

var dato_objr;
function revisa_obj(id) {
    if (dato_objr) { dato_objr.abort(); }
    strhtml = "";
    usuario = id;
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    urlmod = "Servicios/edddatosperf.asmx/lee_revisa_obj";
    dato_objr = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(data.d[0].rev_ad);
            for (var i = 0; i < data.d.length; i++) {
                strestado = "";
                if (data.d[i].rev_estado == 1) strestado = '<a href="eddobjrev.aspx?id=' + data.d[i].rev_ad + '">Revisar Objetivos Inicial</a>';
                else if (data.d[i].rev_estado == 4) strestado = '<a href="eddobjrev.aspx?id=' + data.d[i].rev_ad + '">Revisar Objetivos Intermedio</a>';
                else if (data.d[i].rev_estado == 7) strestado = '<a href="eddobjrev.aspx?id=' + data.d[i].rev_ad + '">Revisar Objetivos Final</a>';

                //alert(strestado);
                if (strestado != "")
                    strhtml += "<tr><td>" + data.d[i].rev_nombre + "</td><td>" + strestado + "</td><td>" + $.cookie("Nombre") + "</td></tr>";
            }
            //alert(strhtml);
        },
        error: function (data) {
            alert("Error Datos Revisa Objetivos");
        }
    });
    return strhtml;
}

var dato_objc;
function revisa_comp(id) {
    if (dato_objc) { dato_objc.abort(); }
    strhtml = "";
    usuario = id;
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    urlmod = "Servicios/edddatosperf.asmx/lee_revisa_comp";
    dato_objc = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                strestado = "";
                if (data.d[i].rev_estado == 1 || data.d[i].rev_estado == 31) strestado = '<a href="eddcompetenciasrev.aspx?id=' + data.d[i].rev_ad + '">Revisar Competencias Inicial</a>';
                else if (data.d[i].rev_estado == 4 || data.d[i].rev_estado == 61) strestado = '<a href="eddcompetenciasrev.aspx?id=' + data.d[i].rev_ad + '">Revisar Competencias Final</a>';

                if (strestado != "")
                    strhtml += "<tr><td>" + data.d[i].rev_nombre + "</td><td>" + strestado + "</td><td>" + $.cookie("Nombre") + "</td></tr>";
            }
        },
        error: function (data) {
            alert("Error Datos Revisa Competencias");
        }
    });
    return strhtml;
}
