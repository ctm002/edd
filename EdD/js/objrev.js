﻿var numobjetivo = 1;
var numpasos = 0;
var fecin;
var fecprimeval;
var fecinter;
var fecter;

$(function () {

    $("#fechapa1").datepicker();
    $("#fechapa2").datepicker();
    $("#fechapa3").datepicker();
    $("#fechapa4").datepicker();
    $("#fechapa5").datepicker();
    $("#fechapa6").datepicker();
    $("#fechapa7").datepicker();
    $("#fechapa11").datepicker();
    $("#fechapa12").datepicker();
    $("#fechapa13").datepicker();
    $("#fechapa14").datepicker();
    $("#fechapa15").datepicker();
    $("#fechapa16").datepicker();
    $("#fechapa17").datepicker();
    $("#fecha31").datepicker();
    $("#fecha32").datepicker();
    $("#fecha41").datepicker();
    $("#fecha42").datepicker();
    $("#fecha51").datepicker();
    $("#fecha52").datepicker();

    $("#linea1").hide();
    $("#linea2").hide();
    $("#linea3").hide();
    $("#linea4").hide();
    $("#linea5").hide();
    $("#linea6").hide();
    $("#linea7").hide();

    numpasos = 0;

    $("#tabla1a3").hide();
    $("#tabla4a4").hide();
    $("#tabla5a5").hide();
    $("#guardarobjetivo").attr('disabled', true).css("background-color","#D8D8D8");
});

function agregapaso() {
    if (numpasos < 7) {
        numpasos++;
        $("#linea" + numpasos).show();
    }

}

var dato_eval;
function lee_eval() {
    if (dato_eval) { dato_eval.abort(); }
    urlmod = "Servicios/edddatosperf.asmx/lee_eval";
    dato_eval = $.ajax({
        url: urlmod,
        async: false,
        data: {},
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var obj = JSON.parse(data.d[0]);
            $.cookie("fecha_inicio", data.d[0].eval_fecha_inicio);
            $.cookie("fecha_primera_evaluacion", data.d[0].eval_fecha_primera_evaluacion);
            $.cookie("fecha_intermedio", data.d[0].eval_fecha_intermedio);
            $.cookie("fecha_termino", data.d[0].eval_fecha_termino);
        },
        error: function (data) {
            alert("Error Datos Evaluacion");
        }
    });
}

var dato_obj;
function lee_estado_obj() {
    if (dato_obj) { dato_obj.abort(); }
    usuario = $.cookie("IdUsuarioRevisa");
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    urlmod = "Servicios/edddatosperf.asmx/lee_estado_obj";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.cookie("estado_obj", data.d);
            //alert($.cookie("estado_obj"));
        },
        error: function (data) {
            alert("Error Datos Estado");
        }
    });
}

function control_tablas() {
    //alert($.cookie("fecha_inicio") + '-' + $.cookie("fecha_primera_evaluacion") + '-' + $.cookie("fecha_intermedio") + '-' + $.cookie("fecha_termino"));

    fecin = $.cookie("fecha_inicio");
    fecprimeval = $.cookie("fecha_primera_evaluacion");
    fecinter = $.cookie("fecha_intermedio");
    fecter = $.cookie("fecha_termino");
    var estado_obj = $.cookie("estado_obj");
    //alert(diashoy(fecprimeval)); alert(diashoy(fecinter));
    if (diashoy(fecprimeval) < 0) {
        //$("#tabla1").attr('disabled', true).css("background-color", "#D8D8D8");
        //$("#tabla2").attr('disabled', true).css("background-color","#D8D8D8");
        $("#tabla3").removeAttr('disabled');
        $("#categoria").attr('disabled', true).css("background-color","#D8D8D8");
        $("#categoria3").attr('disabled', true).css("background-color","#D8D8D8");
        $("#fecha31").attr('disabled', true).css("background-color","#D8D8D8");
        $("#fecha32").attr('disabled', true).css("background-color","#D8D8D8");
        $("#terminado3").attr('disabled', true).css("background-color","#D8D8D8");
        $("#pasos31").attr('disabled', true).css("background-color","#D8D8D8");
        $("#pasos32").removeAttr('disabled');

        //$("#tabla4a4").attr('disabled', true).css("background-color","#D8D8D8");
        //$("#tabla5a5").attr('disabled', true).css("background-color","#D8D8D8");

        if (estado_obj == 1) {
            $("#objetivo").attr('disabled', true).css("background-color","#D8D8D8");
            $("#logros").attr('disabled', true).css("background-color","#D8D8D8");
            $("#medicion").attr('disabled', true).css("background-color","#D8D8D8");
            $("#agregapaso").attr('disabled', true).css("background-color","#D8D8D8");
            for (ll = 1; ll <= 7; ll++) {
                $("#pasos" + ll).attr('disabled', true).css("background-color","#D8D8D8");
                $("#fechapa" + ll).attr('disabled', true).css("background-color","#D8D8D8");
                $("#fechapa1" + ll).attr('disabled', true).css("background-color","#D8D8D8");
            }
            $("#categoria4").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha41").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha42").attr('disabled', true).css("background-color","#D8D8D8");
            $("#terminado4").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos41").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos42").attr('disabled', true).css("background-color","#D8D8D8");
            $("#categoria5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha51").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha52").attr('disabled', true).css("background-color","#D8D8D8");
            $("#terminado5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#notafinal5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos51").attr('disabled', true).css("background-color","#D8D8D8");
            $("#notafinaljefatura5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos52").attr('disabled', true).css("background-color","#D8D8D8");
            $("#guardarobjetivo").show();
        }
        else if (estado_obj == 4){
            $("#guardarobjetivo").show();
        }
        else if (estado_obj == 7) {
            $("#guardarobjetivo").show();
        }
        $("#tabla4a4").css('visibility', 'hidden');
        $("#tabla5a5").css('visibility', 'hidden');
    }
    else
        if (diashoy(fecprimeval) >= 0 && diashoy(fecinter) < 0) {
            //$("#tabla1").attr('disabled', true).css("background-color","#D8D8D8");
            //$("#tabla2").attr('disabled', true).css("background-color","#D8D8D8");
            //$("#tabla3").attr('disabled', true).css("background-color","#D8D8D8");
            $("#categoria").attr('disabled', true).css("background-color","#D8D8D8");
            $("#objetivo").attr('disabled', true).css("background-color","#D8D8D8");
            $("#logros").attr('disabled', true).css("background-color","#D8D8D8");
            $("#medicion").attr('disabled', true).css("background-color","#D8D8D8");
            $("#agregapaso").attr('disabled', true).css("background-color","#D8D8D8");
            for (ll = 1; ll <= 7; ll++) {
                $("#pasos" + ll).attr('disabled', true).css("background-color","#D8D8D8");
                $("#fechapa" + ll).attr('disabled', true).css("background-color","#D8D8D8");
                $("#fechapa1" + ll).attr('disabled', true).css("background-color","#D8D8D8");
            }
            $("#tabla3").attr('disabled', true).css("background-color","#D8D8D8");
            $("#categoria3").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha31").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha32").attr('disabled', true).css("background-color","#D8D8D8");
            $("#terminado3").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos31").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos32").attr('disabled', true).css("background-color","#D8D8D8");
            $("#categoria4").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha41").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha42").attr('disabled', true).css("background-color","#D8D8D8");
            $("#terminado4").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos41").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos42").removeAttr('disabled');
            $("#tabla5a5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#categoria5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha51").attr('disabled', true).css("background-color","#D8D8D8");
            $("#fecha52").attr('disabled', true).css("background-color","#D8D8D8");
            $("#terminado5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#notafinal5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos51").attr('disabled', true).css("background-color","#D8D8D8");
            $("#notafinaljefatura5").attr('disabled', true).css("background-color","#D8D8D8");
            $("#pasos52").attr('disabled', true).css("background-color","#D8D8D8");
            if (estado_obj == 4){
                $("#guardarobjetivo").show();
            }           
            $("#tabla5a5").css('visibility', 'hidden');
        }
        else
            if (diashoy(fecinter) >= 0 && diashoy(fecter) < 0) {
                //$("#tabla1").attr('disabled', true).css("background-color","#D8D8D8");
                //$("#tabla2").attr('disabled', true).css("background-color","#D8D8D8");
                //$("#tabla3").attr('disabled', true).css("background-color","#D8D8D8");
                //$("#tabla4a4").attr('disabled', true).css("background-color","#D8D8D8");
                $("#categoria").attr('disabled', true).css("background-color","#D8D8D8");
                $("#objetivo").attr('disabled', true).css("background-color","#D8D8D8");
                $("#logros").attr('disabled', true).css("background-color","#D8D8D8");
                $("#medicion").attr('disabled', true).css("background-color","#D8D8D8");
                $("#agregapaso").attr('disabled', true).css("background-color","#D8D8D8");
                for (ll = 1; ll <= 7; ll++) {
                    $("#pasos" + ll).attr('disabled', true).css("background-color","#D8D8D8");
                    $("#fechapa" + ll).attr('disabled', true).css("background-color","#D8D8D8");
                    $("#fechapa1" + ll).attr('disabled', true).css("background-color","#D8D8D8");
                }
                $("#categoria3").attr('disabled', true).css("background-color","#D8D8D8");
                $("#fecha31").attr('disabled', true).css("background-color","#D8D8D8");
                $("#fecha32").attr('disabled', true).css("background-color","#D8D8D8");
                $("#terminado3").attr('disabled', true).css("background-color","#D8D8D8");
                $("#pasos31").attr('disabled', true).css("background-color","#D8D8D8");
                $("#pasos32").attr('disabled', true).css("background-color","#D8D8D8");
                $("#categoria4").attr('disabled', true).css("background-color","#D8D8D8");
                $("#fecha41").attr('disabled', true).css("background-color","#D8D8D8");
                $("#fecha42").attr('disabled', true).css("background-color","#D8D8D8");
                $("#terminado4").attr('disabled', true).css("background-color","#D8D8D8");
                $("#pasos41").attr('disabled', true).css("background-color","#D8D8D8");
                $("#pasos42").attr('disabled', true).css("background-color","#D8D8D8");
                $("#tabla5").removeAttr('disabled');
                $("#categoria5").attr('disabled', true).css("background-color","#D8D8D8");
                $("#fecha51").attr('disabled', true).css("background-color","#D8D8D8");
                $("#fecha52").attr('disabled', true).css("background-color","#D8D8D8");
                $("#terminado5").attr('disabled', true).css("background-color","#D8D8D8");
                $("#notafinal5").attr('disabled', true).css("background-color","#D8D8D8");
                $("#pasos51").attr('disabled', true).css("background-color","#D8D8D8");
                $("#notafinaljefatura5").removeAttr('disabled');
                $("#pasos52").removeAttr('disabled');
                if (estado_obj == 7) {
                    $("#guardarobjetivo").show();
                }
            }
}

function diashoy(fecha) {
    var hoy = new Date();
    var ddf = hoy.getDate();
    var mmf = hoy.getMonth() + 1; //hoy es 0!
    var yyf = hoy.getFullYear();

    var ddi = fecha.substr(0, 2);
    var mmi = fecha.substr(3, 2);
    var yyi = fecha.substr(6, 4);

    var fFecha1 = Date.UTC(yyi, mmi - 1, ddi);
    var fFecha2 = Date.UTC(yyf, mmf - 1, ddf);
    var dif = fFecha2 - fFecha1;
    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
    //alert(ddf+'/'+mmf+'/'+yyf + ' - ' + fecha + ' = ' + dias);
    return dias;
}

function limpiar_campos() {
    $("#categoria").val("");
    $("#objetivo").val("");
    $("#logros").val("");
    $("#medicion").val("");

    $("#pasos1").val(""); $("#pasos2").val(""); $("#pasos3").val("");
    $("#pasos4").val(""); $("#pasos5").val(""); $("#pasos6").val("");
    $("#pasos7").val("");

    $("#fechapa1").val(""); $("#fechapa2").val(""); $("#fechapa3").val("");
    $("#fechapa4").val(""); $("#fechapa5").val(""); $("#fechapa6").val("");
    $("#fechapa7").val("");

    $("#fechapa11").val(""); $("#fechapa12").val(""); $("#fechapa13").val("");
    $("#fechapa14").val(""); $("#fechapa15").val(""); $("#fechapa16").val("");
    $("#fechapa17").val("");

    $("#categoria3").val("");
    $("#fecha31").val("");
    $("#fecha32").val("");
    $("#terminado3").val("");
    $("#pasos31").val("");
    $("#pasos32").val("");

    $("#categoria4").val("");
    $("#fecha41").val("");
    $("#fecha42").val("");
    $("#terminado4").val("");
    $("#pasos41").val("");
    $("#pasos42").val("");

    $("#categoria5").val("");
    $("#fecha51").val("");
    $("#fecha52").val("");
    $("#notafinal5").val("");
    $("#pasos51").val("");
    $("#pasos52").val("");
    $("#notafinaljefatura5").val("");
}

var dato_obj;
function lee_obj(nobj) {
    $("#instrucciones0").css('visibility', 'hidden');
    $("#instrucciones").css('visibility', 'hidden');
    limpiar_campos();
    $("#contenedor").css('visibility', 'visible');
    for (i = 1; i <= 7; i++) {
        $("#obj" + i).removeAttr('disabled');
        $("#obj" + i).css("background-color", "#063E74");
    }
    //for (i = 1; i <= 7; i++) {
    //    if (i != nobj) {
    //        $("#obj" + i).attr("disabled", true);
    //        $("#obj" + i).css("background-color", "#D7E9F4");
    //    }
    //}
    $("#obj" + nobj).css("background-color", "grey"); $("#obj" + nobj).attr("disabled", true);
    $("#guardarobjetivo").css("background-color", "red"); $("#guardarobjetivo").removeAttr('disabled');
    $("#aceptarjefe").css("background-color", "grey"); $("#aceptarjefe").attr("disabled", true);
    $("#rechazarjefe").css("background-color", "grey"); $("#rechazarjefe").attr("disabled", true);

    numobjetivo = nobj;
    if (dato_obj) { dato_obj.abort(); }
    usuario = $.cookie("IdUsuarioRevisa");
    var param = '{' + '"usuario":' + '"' + usuario + '",' + '"evalid":' + '"' + $.cookie("evalId") + '",' + '"numobj":"' + nobj + '"}';
    //alert(param);
    urlmod = "Servicios/edddatosperf.asmx/lee_obj";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d.length != 0) {
                var tab1 = JSON.parse(data.d[0].obj_tabla1);
                var tab2 = JSON.parse(data.d[0].obj_tabla2);
                var tab3 = JSON.parse(data.d[0].obj_tabla3);
                var tab4 = JSON.parse(data.d[0].obj_tabla4);
                var tab5 = JSON.parse(data.d[0].obj_tabla5);
                $("#categoria").val(tab1.categoria);
                $("#objetivo").val(tab1.objetivo);
                $("#logros").val(tab1.logros);

                $("#medicion").val(tab2.medicion);
                $("#pasos1").val(tab2.pasos1);
                $("#pasos2").val(tab2.pasos2);
                $("#pasos3").val(tab2.pasos3);
                $("#pasos4").val(tab2.pasos4);
                $("#pasos5").val(tab2.pasos5);
                $("#pasos6").val(tab2.pasos6);
                $("#pasos7").val(tab2.pasos7);
                $("#fechapa1").val(tab2.fechapa1);
                $("#fechapa2").val(tab2.fechapa2);
                $("#fechapa3").val(tab2.fechapa3);
                $("#fechapa4").val(tab2.fechapa4);
                $("#fechapa5").val(tab2.fechapa5);
                $("#fechapa6").val(tab2.fechapa6);
                $("#fechapa7").val(tab2.fechapa7);
                $("#fechapa11").val(tab2.fechapa11);
                $("#fechapa12").val(tab2.fechapa12);
                $("#fechapa13").val(tab2.fechapa13);
                $("#fechapa14").val(tab2.fechapa14);
                $("#fechapa15").val(tab2.fechapa15);
                $("#fechapa16").val(tab2.fechapa16);
                $("#fechapa17").val(tab2.fechapa17);

                for (i = 1; i <= 7; i++)
                    if ($("#pasos" + i).val().trim() != "") $("#linea" + i).show();
                    else break;

                $("#categoria3").val(tab3.categoria3);
                $("#fecha31").val(tab3.fecha31);
                $("#fecha32").val(tab3.fecha32);
                $("#terminado3").val(tab3.terminado3);
                $("#pasos31").val(tab3.pasos31);
                $("#pasos32").val(tab3.pasos32);

                $("#categoria4").val(tab4.categoria4);
                $("#fecha41").val(tab4.fecha41);
                $("#fecha42").val(tab4.fecha42);
                $("#terminado4").val(tab4.terminado4);
                $("#pasos41").val(tab4.pasos41);
                $("#pasos42").val(tab4.pasos42);

                $("#categoria5").val(tab5.categoria5);
                $("#fecha51").val(tab5.fecha51);
                $("#fecha52").val(tab5.fecha52);
                $("#terminado5").val(tab5.terminado5);
                $("#pasos51").val(tab5.pasos51);
                $("#notafinal5").val(tab5.notafinal5);
                $("#notafinaljefatura5").val(tab5.notafinaljefatura5);
                $("#pasos52").val(tab5.pasos52);
            }
            else {
                $("#guardarobjetivo").css("background-color", "#063E74");
                $("#guardarobjetivo").attr("disabled", true);
                return;
            }
            $("#tabla1a3").show();
            $("#tabla4a4").show();
            $("#tabla5a5").show();
        },
        error: function (data) {
            alert("error lee_obj");
        }
    });

}

function guarda_obj() {
    strhtml = "<p>Confirmar Guardar Objetivos.</p>";
    $("#dialogoguardar").html(strhtml);
    $("#dialogoguardar").dialog({
        position: { my: "center center" },
        resizable: false,
        height: 200,
        width: 200,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        modal: true,
        buttons: {
            "Si": function () { guarda_objetivos(); $(this).dialog("close"); },
            "No": function () { $(this).dialog("close"); }
        }
    });
}
var dato_obj;
function guarda_objetivos() {
    strhtml = "";
    if ($("#objetivo").val() == "") {
        strhtml += "<p>- Completar Objetivo</p>";
    }
    if ($("#logros").val() == "") {
        strhtml += "<p>- Completar Que se ha logrado?</p>";
    }
    if ($("#medicion").val() == "") {
        strhtml += "<p>- Completar Medici&oacute;n</p>";
    }
    if ($("#pasos31").val() == "" && diashoy(fecprimeval) < 0) {
        strhtml += "<p>- Completar Comentarios Empleado Inicial</p>";
    }
    if ($("#pasos41").val() == "" && (diashoy(fecprimeval) >= 0 && diashoy(fecinter) < 0)) {
        strhtml += "<p>- Completar Comentarios Empleado Mitad Año</p>";
    }
    if ($("#pasos51").val() == "" && (diashoy(fecinter) >= 0 && diashoy(fecter) < 0)) {
        strhtml += "<p>- Completar Comentarios Empleado Final</p>";
    }

    if ($("#fecha31").val() == "" && diashoy(fecprimeval) < 0) {
        strhtml += "<p>- Completar Fecha Comienzo Inicial</p>";
    }
    if ($("#fecha41").val() == "" && (diashoy(fecprimeval) >= 0 && diashoy(fecinter) < 0)) {
        strhtml += "<p>- Completar Fecha Comienzo Mitad Año</p>";
    }
    if ($("#fecha51").val() == "" && (diashoy(fecinter) >= 0 && diashoy(fecter) < 0)) {
        strhtml += "<p>- Completar Fecha Comienzo Final</p>";
    }

    if ($("#fecha32").val() == "" && diashoy(fecprimeval) < 0) {
        strhtml += "<p>- Completar Fecha Término Inicial</p>";
    }
    if ($("#fecha42").val() == "" && (diashoy(fecprimeval) >= 0 && diashoy(fecinter) < 0)) {
        strhtml += "<p>- Completar Fecha Término Mitad Año</p>";
    }
    if ($("#fecha52").val() == "" && (diashoy(fecinter) >= 0 && diashoy(fecter) < 0)) {
        strhtml += "<p>- Completar Fecha Término Final</p>";
    }
    if ($("#terminado5").val() == "" && (diashoy(fecinter) >= 0 && diashoy(fecter) < 0)) {
        strhtml += "<p>- Completar Terminado</p>";
    }

    if (strhtml != "") {
        $("#objetivo").focus();
        $("#dialogovalidaobj").html(strhtml);
        $("#dialogovalidaobj").dialog({
            position: { my: "center center" },
            resizable: false,
            height: 300,
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
        return;
    }

    $("#contenedor").css('visibility', 'hidden');

    for (i = 1; i <= 7; i++) {
        $("#obj" + i).removeAttr('disabled');
        $("#obj" + i).css("background-color", "#063E74");
    }
    $("#guardarobjetivo").css("background-color", "#063E74");

    if (dato_obj) { dato_obj.abort(); }

    var tabla1 = '{ "categoria": "' + $("#categoria").val() + '" '
    + ', "objetivo": "' + $("#objetivo").val().trim() + '" '
    + ', "logros": "' + $("#logros").val().trim() + '" }';

    var tabla2 = '{ "medicion": "' + $("#medicion").val() + '" '
    + ', "pasos1": "' + $("#pasos1").val().trim() + '" '
    + ', "pasos2": "' + $("#pasos2").val().trim() + '" '
    + ', "pasos3": "' + $("#pasos3").val().trim() + '" '
    + ', "pasos4": "' + $("#pasos4").val().trim() + '" '
    + ', "pasos5": "' + $("#pasos5").val().trim() + '" '
    + ', "pasos6": "' + $("#pasos6").val().trim() + '" '
    + ', "pasos7": "' + $("#pasos7").val().trim() + '" '
    + ', "fechapa1": "' + $("#fechapa1").val() + '" '
    + ', "fechapa2": "' + $("#fechapa2").val() + '" '
    + ', "fechapa3": "' + $("#fechapa3").val() + '" '
    + ', "fechapa4": "' + $("#fechapa4").val() + '" '
    + ', "fechapa5": "' + $("#fechapa5").val() + '" '
    + ', "fechapa6": "' + $("#fechapa6").val() + '" '
    + ', "fechapa7": "' + $("#fechapa7").val() + '" '
    + ', "fechapa11": "' + $("#fechapa11").val() + '" '
    + ', "fechapa12": "' + $("#fechapa12").val() + '" '
    + ', "fechapa13": "' + $("#fechapa13").val() + '" '
    + ', "fechapa14": "' + $("#fechapa14").val() + '" '
    + ', "fechapa15": "' + $("#fechapa15").val() + '" '
    + ', "fechapa16": "' + $("#fechapa16").val() + '" '
    + ', "fechapa17": "' + $("#fechapa17").val() + '" }';

    var tabla3 = '{ "categoria3": "' + $("#categoria3").val() + '" '
    + ', "fecha31": "' + $("#fecha31").val() + '" '
    + ', "fecha32": "' + $("#fecha32").val() + '" '
    + ', "terminado3": "' + $("#terminado3").val() + '" '
    + ', "pasos31": "' + $("#pasos31").val() + '" '
    + ', "pasos32": "' + $("#pasos32").val() + '"}';

    var tabla4 = '{ "categoria4": "' + $("#categoria4").val() + '" '
    + ', "fecha41": "' + $("#fecha41").val() + '" '
    + ', "fecha42": "' + $("#fecha42").val() + '" '
    + ', "terminado4": "' + $("#terminado4").val() + '" '
    + ', "pasos41": "' + $("#pasos41").val() + '" '
    + ', "pasos42": "' + $("#pasos42").val() + '"}';

    var tabla5 = '{ "categoria5": "' + $("#categoria5").val() + '" '
    + ', "fecha51": "' + $("#fecha51").val() + '" '
    + ', "fecha52": "' + $("#fecha52").val() + '" '
    + ', "terminado5": "' + $("#terminado5").val() + '" '
    + ', "notafinal5": "' + $("#notafinal5").val() + '" '
    + ', "pasos51": "' + $("#pasos51").val() + '" '
    + ', "notafinaljefatura5": "' + $("#notafinaljefatura5").val() + '" '
    + ', "pasos52": "' + $("#pasos52").val() + '"}';

    if ($.cookie("IdUsuarioRevisa") == null) {
        alert("No hay Usuario");
        return;
    }
    else
        cvad = parseInt($.cookie("IdUsuarioRevisa"));

    var param = "cvad=" + usuario + "&evalid=" + $.cookie("evalId") + "&numobj=" + numobjetivo
        + "&tabla1=" + tabla1
        + "&tabla2=" + tabla2
        + "&tabla3=" + tabla3
        + "&tabla4=" + tabla4
        + "&tabla5=" + tabla5 + '&callback=?';

    //var blobf = new Blob([param], { type: "text/csv;charset=utf-8" });
    //if (window.navigator.msSaveOrOpenBlob) {
    //    window.navigator.msSaveBlob(blobf, 'log.txt');
    //}
    //alert(param);

    urlmod = "Servicios/edddatosperf.asmx/guarda_obj";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "text",
        success: function (data) {
            //$("#guardarobjetivo").css("background-color", "#063E74");
            $("#tabla1a3").hide();
            $("#tabla4a4").hide();
            $("#tabla5a5").hide();
            $("#tabla6a6").hide();
            $("#guardarobjetivo").attr('disabled', true).css("background-color", "#D8D8D8");
            $("#instrucciones0").css('visibility', 'visible');
            $("#instrucciones").css('visibility', 'visible');
            $("#aceptarjefe").css("background-color", "#063E74"); $("#aceptarjefe").removeAttr('disabled');
            $("#rechazarjefe").css("background-color", "#063E74"); $("#rechazarjefe").removeAttr('disabled');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("error:" + jqXHR.status);
            alert("error:" + jqXHR.responseText);
            $("#guardarobjetivo").attr('disabled', true).css("background-color", "#D8D8D8");
        }
    });
} //fin guarda objetivos

function limpiar_obj() {
    for (i = 1; i <= 7; i++) {
        $("#obj" + i).removeAttr('disabled');
        $("#obj" + i).css("background-color", "#063E74");
    }
    $("#guardarobjetivo").css("background-color", "#063E74");
    $("#aceptarjefe").css("background-color", "#063E74"); $("#aceptarjefe").removeAttr('disabled');
    $("#rechazarjefe").css("background-color", "#063E74"); $("#rechazarjefe").removeAttr('disabled');

    $("#categoria").val("Salud");
    $("#objetivo").val("");
    $("#logros").val("");

    $("#medicion").val("");
    $("#pasos1").val("");
    $("#pasos2").val("");
    $("#pasos3").val("");
    $("#pasos4").val("");
    $("#pasos5").val("");
    $("#pasos6").val("");
    $("#pasos7").val("");
    $("#fechapa1").val("");
    $("#fechapa2").val("");
    $("#fechapa3").val("");
    $("#fechapa4").val("");
    $("#fechapa5").val("");
    $("#fechapa6").val("");
    $("#fechapa7").val("");
    $("#fechapa11").val("");
    $("#fechapa12").val("");
    $("#fechapa13").val("");
    $("#fechapa14").val("");
    $("#fechapa15").val("");
    $("#fechapa16").val("");
    $("#fechapa17").val("");

    $("#categoria3").val("Cancelado");
    $("#fecha31").val("");
    $("#fecha32").val("");
    $("#terminado3").val("");
    $("#pasos31").val("");
    $("#pasos32").val("");

    $("#categoria4").val("Cancelado");
    $("#fecha41").val("");
    $("#fecha42").val("");
    $("#terminado4").val("");
    $("#pasos41").val("");
    $("#pasos42").val("");

    $("#categoria5").val("Cancelado");
    $("#fecha51").val("");
    $("#fecha52").val("");
    $("#terminado5").val("");
    $("#notafinal5").val("No calificado");
    $("#notafinaljefatura5").val("");
    $("#pasos52").val("");

    $("#tabla1a3").hide();
    $("#tabla4a4").hide();
    $("#tabla5a5").hide();
    $("#tabla6a6").hide();

}

var dato_acp;
function actualiza_jefe(acepta) {
    estado_obj = $.cookie("estado_obj");
    //alert(estado_obj);
    if (estado_obj == 1 && acepta == 1) estado_obj = 2;
    if (estado_obj == 1 && acepta == 0) estado_obj = 3;
    if (estado_obj == 3 && acepta == 1) estado_obj = 2;
    if (estado_obj == 3 && acepta == 0) estado_obj = 3;

    if (estado_obj == 4 && acepta == 1) estado_obj = 5;
    if (estado_obj == 4 && acepta == 0) estado_obj = 6;
    if (estado_obj == 6 && acepta == 1) estado_obj = 5;
    if (estado_obj == 6 && acepta == 0) estado_obj = 6;

    if (estado_obj == 7 && acepta == 1) estado_obj = 8;
    if (estado_obj == 7 && acepta == 0) estado_obj = 9;
    if (estado_obj == 9 && acepta == 1) estado_obj = 8;
    if (estado_obj == 9 && acepta == 0) estado_obj = 9;

    if (dato_acp) { dato_acp.abort(); }
    $("#guardarobjetivo").hide();
    $("#aceptarjefe").hide();
    $("#rechazarjefe").hide();
    usuario = $.cookie("IdUsuarioRevisa");
    var param = '{' + '"usuario":' + '"' + usuario + '","estado":'+'"'+ estado_obj + '"}';
    //alert(param);
    urlmod = "Servicios/edddatosperf.asmx/actualiza_estado_obj";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error Datos Acepta/Rechaza");
            alert(XMLHttpRequest.responseText);
        }
    });
}