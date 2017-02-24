var fecin;
var fecprimeval;
var fecinter;
var fecter;
var ncompetencias = 0;

function limpia_campos() {
    for (var i = 1; i < 8; i++) {
        strobj = "#col" + i + "1"; strobjf = "#col" + i + "1f";
        $(strobj).html("");
        $(strobjf).html("");
    }
    for (var i = 1; i < 8; i++) {
        $("#evaljefe" + i + "2").val("1");
        $("#evaljefe" + i + "3").val("");
        $("#evaljefe" + i + "4").val("");
        $("#evaljefe" + i + "5").val("");
        $("#evaljefe" + i + "2f").val("");
        $("#evaljefe" + i + "3f").val("");
        $("#evaljefe" + i + "4f").val("");
        $("#evaljefe" + i + "5f").val("");
    }
}

var dato_eval;
function lee_eval_comp() {
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
            $.cookie("evalId", data.d[0].eval_id);
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

var dato_comp;
function lee_estado_comp() {
    if (dato_comp) { dato_comp.abort(); }
    usuario = $.cookie("IdUsuarioRevisa");
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    urlmod = "Servicios/edddatosperf.asmx/lee_estado_comp";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.cookie("estado_comp", data.d);
            //alert($.cookie("estado_comp"));
        },
        error: function (data) {
            alert("Error Datos Estado");
        }
    });
}

var dato_cargocomp;
function lee_cargo_comp() {
    if (dato_cargocomp) { dato_cargocomp.abort(); }
    usuario = $.cookie("IdUsuarioRevisa");
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    urlmod = "Servicios/edddatosperf.asmx/lee_cargo_comp";
    //alert(usuario);
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            // cel11 a cel71 completar con Competencias por Cargo
            //alert(data.d.length);
            for (var i = 0; i < data.d.length; i++) {
                strobj = "#col" + (i + 1) + "1"; strobjf = "#col" + (i + 1) + "1f";
                //alert(strobj); alert(strobjf); alert(data.d[i].cargo_desc);
                $(strobj).html(data.d[i].cargo_desc);
                $(strobjf).html(data.d[i].cargo_desc);
            }
            ncompetencias = data.d.length;
            //alert(i);
            for (var j = i; j < 8; j++) {
                strobj = "#fila" + (j + 1); strobjf = "#fila" + (j + 1) + "f";
                $(strobj).hide();
                $(strobjf).hide();
            }
            //alert($.cookie("estado_comp"));
        },
        error: function (data) {
            alert("Error Datos Cargos");
        }
    });
}

function control_tablas_comp() {
    estado_comp = $.cookie("estado_comp");
    fec_primera_eval = $.cookie("fecha_primera_evaluacion");
    fec_final = $.cookie("fecha_termino");
    //alert(estado_comp);
    //alert(ncompetencias);
    //alert(diashoy(fec_primera_eval));
    //alert(diashoy(fec_final));
    if (diashoy(fec_primera_eval) < 0) {
        $("#encabezadofinal").hide();
        $("#compfinal").hide();
        for (kk = 1; kk <= ncompetencias; kk++) {
            $("#evaljefe" + kk + "2").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "2").css('background-color', 'E6E6E6');
            $("#evaljefe" + kk + "3").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "4").attr('disabled', true).css("background-color","#A4A4A4");
        }
        if (estado_comp == 0) {
            $("#enviarajefaturacomp").hide();
            $("#guardarcomp").hide();
        }
        else if (estado_comp == 1) {
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
        } else if (estado_comp == 3) {
            $("#enviarajefaturacomp").hide();
            $("#guardarcomp").hide();
        }
        else {
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
        }
    }
    else if (diashoy(fec_primera_eval) >= 0 && diashoy(fec_final) < 0) {
        $("#compinicio").attr('disabled', true).css("background-color","#A4A4A4");
        for (kk = 1; kk <= ncompetencias; kk++) {
            $("#evaljefe" + kk + "2").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "2").css('background-color', 'E6E6E6');
            $("#evaljefe" + kk + "3").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "4").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "5").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "5").css('background-color', 'E6E6E6');
            $("#evaljefe" + kk + "6").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "7").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + kk + "7").css('background-color', 'E6E6E6');
        }
        $("#compfinal").show();
        if (estado_comp == 4) {
            ncalib = 0;
            for (var ll = 1; ll <= ncompetencias; ll++) {
                //alert($("#evaljefe" + ll + "7f").val());
                if ($("#evaljefe" + ll + "7").val() == 1) ncalib++;
            }
            for (kk = 1; kk <= ncompetencias; kk++) {
                $("#evaljefe" + kk + "2f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + kk + "2f").css('background-color', 'E6E6E6');
                $("#evaljefe" + kk + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + kk + "7f").css('background-color', 'E6E6E6');
                if (ncalib == 0) {
                    $("#evaljefe" + kk + "5f").attr('disabled', true).css("background-color","#A4A4A4");
                    $("#evaljefe" + kk + "5f").css('background-color', 'E6E6E6');
                }
            }
            $("#aceptarjefecomp").show();
            $("#rechazarjefecomp").show();
            $("#guardarcomp").show();
        }
        else {
            for (kk = 1; kk <= ncompetencias; kk++) {
                $("#evaljefe" + kk + "2f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + kk + "2f").css('background-color', 'E6E6E6');
                $("#evaljefe" + kk + "5f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + kk + "5f").css('background-color', 'E6E6E6');
                $("#evaljefe" + kk + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + kk + "7f").css('background-color', 'E6E6E6');
            }
            $("#aceptarjefecomp").show();
            $("#rechazarjefecomp").show();
            $("#guardarcomp").show();
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

function actualiza_comp() {
    strhtml = "<p>Confirmar Guardar Competencias.</p>";
    $("#guardacomp").html(strhtml);
    $("#guardacomp").dialog({
        position: { my: "center center" },
        resizable: false,
        height: 200,
        width: 200,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        modal: true,
        buttons: {
            "Si": function () { actualiza_competencias(); $(this).dialog("close"); },
            "No": function () { $(this).dialog("close"); }
        }
    });
}

var dato_gcomp;
function actualiza_competencias() {
    if (dato_gcomp) { dato_gcomp.abort(); }
    for (var i = 1; i <= ncompetencias; ++i) {
        usuario = $.cookie("IdUsuarioRevisa");
        evalid = $.cookie("evalId");

        var param = '{'
        + '"id":' + '"' + i
        + '","usuario":' + '"' + usuario
        + '","evalid":' + '"' + evalid
        + '","cargo":' + '"' + i
        + '","eval_inicial_consensuada":' + '"' + $("#evaljefe" + i + "2").val()
        + '","eval_inicial_plan_accion":' + '"' + $("#evaljefe" + i + "3").val()
        + '","eval_inicial_comentario":' + '"' + $("#evaljefe" + i + "4").val()
        + '","eval_inicial_jefe":' + '"' + $("#evaljefe" + i + "5").val()
        + '","eval_final_consensuada":' + '"' + $("#evaljefe" + i + "2f").val()
        + '","eval_final_plan_accion":' + '"' + $("#evaljefe" + i + "3f").val()
        + '","eval_final_comentario":' + '"' + $("#evaljefe" + i + "4f").val()
        + '","eval_final_jefe":' + '"' + $("#evaljefe" + i + "5f").val()
        + '"}';
        //alert(param); 
        //muestra(param);
        urlmod = "Servicios/edddatosperf.asmx/actualiza_comp";
        dato_eval = $.ajax({
            url: urlmod,
            async: false,
            data: param,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
            },
            error: function (data) {
                alert("Error Graba Competencias");
            }
        });

    }
}

var dato_jefc;
function enviar_jefaturacomp() {
    if (dato_jefc) { dato_jefc.abort(); }
    $("#enviarajefaturacomp").hide();
    $("#guardarcomp").hide();
    usuario = $.cookie("IdUsuarioRevisa");
    estado_comp = $.cookie("estado_comp");
    //alert(estado_comp);
    if (estado_comp == 0) estado_comp = 1;
    else if (estado_comp == 2) estado_comp = 4;
    else if (estado_comp == 5) estado_comp = 7
    else return;
    $.cookie("estado_comp", estado_comp);
    var param = '{' + '"usuario":' + '"' + usuario + '","estado":' + '"' + estado_comp + '"}';
    //alert(param);
    urlmod = "Servicios/edddatosperf.asmx/actualiza_estado_comp";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert($.cookie("estado_obj"));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error Actualiza Estado");
            alert(XMLHttpRequest.responseText);
        }
    });
}

var dato_leecomp;
function lee_competencias() {
    if (dato_leecomp) { dato_leecomp.abort(); }
    usuario = $.cookie("IdUsuarioRevisa");
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    urlmod = "Servicios/edddatosperf.asmx/lee_competencias";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            // Leer Competencias
            //alert(data.d.length);
            if (data.d.length > 0) {
                for (var i = 0; i < data.d.length; i++) {
                    $("#evaljefe" + (i + 1) + "1").val(data.d[i].comp_desc);
                    $("#evaljefe" + (i + 1) + "2").val(data.d[i].comp_inicial_consensuada);
                    $("#evaljefe" + (i + 1) + "3").val(data.d[i].comp_inicial_plan_accion);
                    $("#evaljefe" + (i + 1) + "4").val(data.d[i].comp_inicial_comentario);
                    $("#evaljefe" + (i + 1) + "5").val(data.d[i].comp_inicial_jefe);
                    $("#evaljefe" + (i + 1) + "1f").val(data.d[i].comp_desc);
                    $("#evaljefe" + (i + 1) + "2f").val(data.d[i].comp_final_consensuada);
                    $("#evaljefe" + (i + 1) + "3f").val(data.d[i].comp_final_plan_accion);
                    $("#evaljefe" + (i + 1) + "4f").val(data.d[i].comp_final_comentario);
                    $("#evaljefe" + (i + 1) + "5f").val(data.d[i].comp_final_jefe);
                }
                ncompetencias = data.d.length;
                for (var j = i; j < 8; j++) {
                    strobj = "#fila" + (j + 1); strobjf = "#fila" + (j + 1) + "f";
                    $(strobj).hide();
                    $(strobjf).hide();
                }
            }
        },
        error: function (data) {
            alert("Error Datos Competencias");
        }
    });
}

function muestra(param) {
    $("#dialogoinstrcomp").html("<p>" + param + "</p>");
    $("#dialogoinstrcomp").dialog({
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
}

var dato_acpc;
function actualiza_jefecomp(acepta) {

    // APF revisar y eliminar
    if (acepta == 1000) {
        // contar si hay evaluaciones menores del jefe en la fechas de evaluacion
        nce = 0; ncb = 0;
        if (diashoy(fec_primera_eval) < 0) {
            for (var ll = 1; ll <= ncompetencias; ll++) {
                //alert($("#evaljefe" + ll + "7").val());
                if ($("#evaljefe" + ll + "5").val() >= $("#evaljefe" + ll + "2").val()) nce++;
            }
            for (var ll = 1; ll <= ncompetencias; ll++) {
                //alert($("#evaljefe" + ll + "7").val());
                if ($("#evaljefe" + ll + "7").val() > 1) ncb++;
            }
        }
        else {
            for (var ll = 1; ll <= ncompetencias; ll++) {
                //alert($("#evaljefe" + ll + "7f").val());
                if ($("#evaljefe" + ll + "5f").val() >= $("#evaljefe" + ll + "2f").val()) nce++;
            }
            for (var ll = 1; ll <= ncompetencias; ll++) {
                    //alert($("#evaljefe" + ll + "7").val());
                    if ($("#evaljefe" + ll + "7f").val() > 1) ncb++;
            }
        }
        // si el contador es mayor que cero cambiar acepta=1 por acepta=0 se rechaza
        if (nce < ncompetencias && ncb == 0) acepta = 0;
        //alert(nce + '-' + ncb + '-' + ncompetencias + '-' + acepta);
    }
    estado_comp = $.cookie("estado_comp");
    //alert(estado_comp+'-'+acepta);
    if (estado_comp == 1 && acepta == 1) estado_comp = 2;
    else if (estado_comp == 1 && acepta == 0) estado_comp = 3;
    else if (estado_comp == 3 && acepta == 1) estado_comp = 2;
    else if (estado_comp == 3 && acepta == 0) estado_comp = 3;
    else if (estado_comp == 31 && acepta == 1) estado_comp = 2;
    else if (estado_comp == 31 && acepta == 0) estado_comp = 32;
    else if (estado_comp == 6 && acepta == 1) estado_comp = 5;
    else if (estado_comp == 6 && acepta == 0) estado_comp = 6;
    else if (estado_comp == 61 && acepta == 1) estado_comp = 7;
    else if (estado_comp == 61 && acepta == 0) estado_comp = 62;
    else if (estado_comp == 4 && acepta == 1) estado_comp = 5;
    else if (estado_comp == 4 && acepta == 0) estado_comp = 6;
    else return;
    //alert(estado_comp + '-' + acepta);
    if (dato_acpc) { dato_acpc.abort(); }
    $("#guardarcomp").hide();
    $("#aceptarjefecomp").hide();
    $("#rechazarjefecomp").hide();
    usuario = $.cookie("IdUsuarioRevisa");
    var param = '{' + '"usuario":' + '"' + usuario + '","estado":' + '"' + estado_comp + '"}';
    //alert(param);
    urlmod = "Servicios/edddatosperf.asmx/actualiza_estado_comp";
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
