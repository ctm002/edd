var fecin;
var fecprimeval;
var fecinter;
var fecter;
var ncompetencias=0;

function limpia_campos(){
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
    usuario = $.cookie("IdMaestroUsuario");
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
    usuario = $.cookie("IdMaestroUsuario");
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

function control_tablas_comp(){
    estado_comp=$.cookie("estado_comp");
    fec_primera_eval=$.cookie("fecha_primera_evaluacion");
    fec_final=$.cookie("fecha_termino");
    //alert(estado_comp);alert(diashoy(fec_primera_eval));alert(diashoy(fec_final));

    if (diashoy(fec_primera_eval) < 0) {
        $("#encabezadofinal").hide();
        $("#compfinal").hide();
        $("#evaljefe15").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe16").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe17").attr('disabled', true).css("background-color","#A4A4A4");
        $("#evaljefe25").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe26").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe27").attr('disabled', true).css("background-color","#A4A4A4");
        $("#evaljefe35").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe36").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe37").attr('disabled', true).css("background-color","#A4A4A4");
        $("#evaljefe45").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe46").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe47").attr('disabled', true).css("background-color","#A4A4A4");
        $("#evaljefe55").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe56").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe57").attr('disabled', true).css("background-color","#A4A4A4");
        $("#evaljefe65").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe66").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe67").attr('disabled', true).css("background-color","#A4A4A4");
        $("#evaljefe75").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe76").attr('disabled', true).css("background-color","#A4A4A4"); $("#evaljefe77").attr('disabled', true).css("background-color","#A4A4A4");
        //alert(estado_comp);

        if( estado_comp==0){
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
        }
        else if (estado_comp == 1) {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "2").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "3").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "4").attr('disabled', true).css("background-color","#A4A4A4");
            }
            $("#enviarajefaturacomp").hide();
            $("#guardarcomp").hide();
        }
        else if (estado_comp == 2) {
            $("#enviarajefaturacomp").hide();
            $("#guardarcomp").hide();
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "2").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "3").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "4").attr('disabled', true).css("background-color", "#A4A4A4");
                $("#evaljefe" + ll + "5").attr('disabled', true).css("background-color", "#A4A4A4");
            }
        }
        else if ( estado_comp == 3 ) {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2").removeAttr('disabled');
                $("#evaljefe" + ll + "3").removeAttr('disabled');
                $("#evaljefe" + ll + "4").removeAttr('disabled');
                $("#evaljefe" + ll + "5").attr('disabled', true).css("background-color", "#A4A4A4");
            }
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
        }
         else {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2").attr('disabled', true).css("background-color", "#A4A4A4");
                $("#evaljefe" + ll + "2").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "3").attr('disabled', true).css("background-color", "#A4A4A4");
                $("#evaljefe" + ll + "4").attr('disabled', true).css("background-color", "#A4A4A4");
                $("#evaljefe" + ll + "5").attr('disabled', true).css("background-color", "#A4A4A4");
                $("#evaljefe" + ll + "5").css('background-color', 'E6E6E6');
            }
            $("#enviarajefaturacomp").hide();
            $("#guardarcomp").hide();
        }
    }
    else if( diashoy(fec_primera_eval)>=0 && diashoy(fec_final)<0){
        $("#compinicio").attr('disabled', true).css("background-color","#A4A4A4");
        for (ll = 1; ll <= ncompetencias; ll++) {
            $("#evaljefe" + ll + "2").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + ll + "2").css('background-color', 'E6E6E6');
            $("#evaljefe" + ll + "3").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + ll + "4").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + ll + "5").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + ll + "5").css('background-color', 'E6E6E6');
        }
        $("#compfinal").show();
        for (ll = 1; ll <= ncompetencias; ll++) {
            $("#evaljefe" + ll + "2f").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + ll + "2f").css('background-color', 'E6E6E6');
            $("#evaljefe" + ll + "5f").attr('disabled', true).css("background-color","#A4A4A4");
            $("#evaljefe" + ll + "5f").css('background-color', 'E6E6E6');
        }

        if (estado_comp == 62) estado_comp = 61;
        if (estado_comp == 2) {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2f").removeAttr('disabled');
                $("#evaljefe" + ll + "2f").css('background-color', 'FFFFFF');
            }
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
        }
        else if (estado_comp == 4) {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "2f").css('background-color', 'FFFFFF');
            }
            $("#enviarajefaturacomp").hide();
            $("#guardarcomp").hide();
        }
        else if (estado_comp == 5) {
            niguales = 0;
            for (var k = 1; k <= ncompetencias; k++) {
                //alert($("#evaljefe" + k+"2").val() + '-' + $("#evaljefe" + k + "5").val())
                if ($("#evaljefe" + k + "2f").val() <= $("#evaljefe" + k + "5f").val()) niguales++;
            }

            ncalib = 0;
            for (var ll = 1; ll <= ncompetencias; ll++)
                if ($("#evaljefe" + ll + "7f").val() >= $("#evaljefe" + ll + "5f").val() ) ncalib++;
            //alert(niguales +'-'+ncompetencias+'-'+ncalib);
            if (niguales == ncompetencias) {
                for (var l = 1; l <= ncompetencias; l++){
                    $("#evaljefe" + l + "7f").val($("#evaljefe" + l + "5f").val());
                    $("#evaljefe" + l + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                    $("#evaljefe" + l + "7f").css('background-color', 'E6E6E6');
                    $("#enviarajefaturacomp").hide();
                    $("#guardarcomp").hide();
                }
            }
            else if (ncalib == ncompetencias) {
                for (var l = 1; l <= ncompetencias; l++) {
                    $("#evaljefe" + l + "7f").val($("#evaljefe" + l + "5f").val());
                    $("#evaljefe" + l + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                    $("#evaljefe" + l + "7f").css('background-color', 'E6E6E6');
                    $("#enviarajefaturacomp").hide();
                    $("#guardarcomp").hide();
                }
            }
            else {
                estado_comp = 61;
                for (var l = 1; l <= ncompetencias; l++) {
                    $("#evaljefe" + l + "7f").removeAttr('disabled');
                    $("#evaljefe" + l + "7f").css('background-color', 'E6E6E6');
                }
                $("#enviarajefaturacomp").show();
                $("#guardarcomp").show();
            }
        }
        else if ( estado_comp == 61 ) {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "2f").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "5f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "5f").css('background-color', 'E6E6E6');
            }
            for (var k = 1; k <= ncompetencias; k++) {
                $("#evaljefe" + k + "7f").removeAttr('disabled');
                $("#evaljefe" + k + "7f").css('background-color', 'FFFFFF');
            }
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
        } else if (estado_comp == 6) {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "2f").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "3f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "4f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "5f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "5f").css('background-color', 'E6E6E6');
            }
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
            niguales = 0;
            for (var k = 1; k <= ncompetencias; k++) {
                if ($("#evaljefe" + k + "2f").val() <= $("#evaljefe" + k + "5f").val()) niguales++;
            }
            if (niguales == ncompetencias) {
                for (var l = 1; l <= ncompetencias; l++){
                    $("#evaljefe" + l + "7f").val($("#evaljefe" + l + "5f").val());
                    $("#evaljefe" + l + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                    $("#evaljefe" + l + "7f").css('background-color', 'E6E6E6');
                }
            }
            else
                for (var k = 1; k <= ncompetencias; k++) {
                    $("#evaljefe" + k + "7f").removeAttr('disabled');
                    $("#evaljefe" + k + "7f").css('background-color', 'FFFFFF');
                }
        }
        else if (estado_comp == 61) {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "2f").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "3f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "4f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "5f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "5f").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "7f").css('background-color', 'E6E6E6');
            }
            $("#enviarajefaturacomp").show();
            $("#guardarcomp").show();
            niguales = 0;
            for (var k = 1; k <= ncompetencias; k++) {
                if ($("#evaljefe" + k + "2f").val() == $("#evaljefe" + k + "5f").val()) niguales++;
            }
            if (niguales == ncompetencias) {
                for (var l = 1; l <= ncompetencias; l++){
                    $("#evaljefe" + l + "7f").val($("#evaljefe" + l + "5f").val());
                    $("#evaljefe" + l + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                    $("#evaljefe" + l + "7f").css('background-color', 'E6E6E6');
                }
            }
            else
                for (var k = 1; k <= ncompetencias; k++) {
                    $("#evaljefe" + k + "7f").removeAttr('disabled');
                    $("#evaljefe" + k + "7f").css('background-color', 'FFFFFF');
                }
        }
        else {
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "2f").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "5f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "5f").css('background-color', 'E6E6E6');
                $("#evaljefe" + ll + "7f").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "7f").css('background-color', 'E6E6E6');
            }
            $("#enviarajefaturacomp").hide();
            $("#guardarcomp").hide();
        }
    }

    $.cookie("estado_comp", estado_comp);
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
function actualiza_competencias(){
    if (dato_gcomp) { dato_gcomp.abort(); }
    for (var i = 1; i <= ncompetencias; ++i) {
        usuario = $.cookie("IdMaestroUsuario");
        evalid = $.cookie("evalId");

        var param = '{'
        + '"id":' + '"' + i
        + '","usuario":' + '"' + usuario
        + '","evalid":' + '"' + evalid
        + '","cargo":' + '"' + i
        + '","eval_inicial_consensuada":' + '"' + $("#evaljefe"+i+"2").val()
        + '","eval_inicial_plan_accion":' + '"' + $("#evaljefe"+i+"3").val()
        + '","eval_inicial_comentario":' + '"' + $("#evaljefe"+i+"4").val()
        + '","eval_inicial_jefe":' + '"' + $("#evaljefe"+i+"5").val()
        + '","eval_final_consensuada":' + '"' + $("#evaljefe"+i+"2f").val()
        + '","eval_final_plan_accion":' + '"' + $("#evaljefe"+i+"3f").val()
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

function enviar_jefaturacomp() {
    res = hay_competencia();
    if (!res) return;
    aviso_compajefatura();
}

function aviso_compajefatura() {
    strhtml = "<p>Confirmar envio a Jefatura.</p>";
    $("#dialogocompajefatura").html(strhtml);
    $("#dialogocompajefatura").dialog({
        position: { my: "center center" },
        resizable: false,
        height: 200,
        width: 200,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        modal: true,
        buttons: {
            "Si": function () { enviar_jefatura_comp_valida(); $(this).dialog("close"); },
            "No": function () { $(this).dialog("close"); }
        }
    });
}

var dato_jefc;
function enviar_jefatura_comp_valida() {
    if (dato_jefc) { dato_jefc.abort(); }
    $("#enviarajefaturacomp").hide();
    $("#guardarcomp").hide();
    usuario = $.cookie("IdMaestroUsuario");
    estado_comp = $.cookie("estado_comp");
    //alert(estado_comp);
    if (estado_comp == 0) estado_comp = 1;
    else if (estado_comp == 2) estado_comp = 4;
    else if (estado_comp == 3) estado_comp = 1;
    else if (estado_comp == 6) estado_comp = 4;
    else if (estado_comp == 31) estado_comp = 31;
    else if (estado_comp == 61) estado_comp = 61;
    else if (estado_comp == 5) estado_comp = 7;
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
            for (ll = 1; ll <= ncompetencias; ll++) {
                $("#evaljefe" + ll + "2").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "3").attr('disabled', true).css("background-color","#A4A4A4");
                $("#evaljefe" + ll + "4").attr('disabled', true).css("background-color","#A4A4A4");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error Actualiza Estado");
            alert(XMLHttpRequest.responseText);
        }
    });
}

var dato_leecomp;
function lee_competencias(){
    if (dato_leecomp) { dato_leecomp.abort(); }
    usuario = $.cookie("IdMaestroUsuario");
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
    $("#dialogoinstrcomp").html("<p>"+param+"</p>");
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

var dato_hayc;
function hay_competencia() {
    if (dato_hayc) { dato_hayc.abort(); }
    usuario = $.cookie("IdMaestroUsuario");
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    //alert(param);
    urlmod = "Servicios/edddatosperf.asmx/hay_comp";
    retorna = 0;
    dato_hayc = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(parseInt(data.d[0]));
            if (parseInt(data.d[0]) == 0) { aviso_comp(); }
            retorna = parseInt(data.d[0]);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error Competencias");
            alert(XMLHttpRequest.responseText);
            retorna = 0;
        }
    });
    return retorna;
}

function aviso_comp() {
    strhtml = "<p>No hay Competencias. Debe Completar para enviar a Jefatura.</p>";
    $("#dialogovalidacomp").html(strhtml);
    $("#dialogovalidacomp").dialog({
        position: { my: "center center" },
        resizable: false,
        height: 400,
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