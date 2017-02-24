var nexp = 1;
var nemp = 1;
var ncap = 1;
var nfor = 1;
var nidiomas = 1;
var npremios = 1;
var nmemb = 1;

function crear_entrada() {
    for (i = 1; i < 5; i++) {
        id1 = "expfecini" + i; id2 = "expfecter" + i; id3 = "expcargo" + i; id4 = "trabajaqui" + i;
        $("#listexp").append("<tr><td><input id='" + id3 + "' name='" + id3 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td><input id='" + id1 + "' name='" + id1 + "' type='text' style='background-color: #F7FAFC;'/></td><td><input id='" + id2 + "' name='" + id2 + "' type='text' style='background-color: #F7FAFC;'/></td><td><select id='" + id4 + "' name='" + id4 + "' type='text' style='background-color: #F7FAFC;'><option value='NO'>NO</option><option value='SI'>SI</option></select></td></tr>");
        $("#" + id1).datepicker(); $("#" + id2).datepicker();
    }
    for (i = 1; i < 11; i++) {
        id1 = "empfecini" + i; id2 = "empfecter" + i; id3 = "empcargo" + i; id4 = "empresa" + i;
        $("#listemp").append("<tr><td><input id='" + id3 + "' name='" + id3 + "' type='text' style='background-color: #F7FAFC;' value='' /></td><td><input id='" + id4 + "' name='" + id4 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td><input id='" + id1 + "' name='" + id1 + "' type='text' style='background-color: #F7FAFC;'/></td><td><input id='" + id2 + "' name='" + id2 + "' type='text' style='background-color: #F7FAFC;' /></td></tr>");
        $("#" + id1).datepicker(); $("#" + id2).datepicker();
    }
    for (i = 1; i < 9; i++) {
        id1 = "forfecini" + i; id2 = "forfecter" + i; id3 = "forprograma" + i; id4 = "forgrado" + i; id5 = "forinstitucion" + i;
        $("#listfor").append("<tr><td><input id='" + id3 + "' name='" + id3 + "' type='text' style='background-color: #F7FAFC;'/></td><td><input id='" + id4 + "' name='" + id4 + "' type='text' style='background-color: #F7FAFC;' /></td><td><input id='" + id5 + "' name='" + id5 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td><input id='" + id1 + "' name='" + id1 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td><input id='" + id2 + "' name='" + id2 + "' type='text' size='30' style='background-color: #F7FAFC;' value=''/></td></tr>");
        $("#" + id1).datepicker(); $("#" + id2).datepicker();
    }
    for(i=1;i<9;i++){
        id1 = "capfecini" + i; id2 = "capfecter" + i; id3 = "captitulo" + i; id4 = "captitestudio"+i; id5 = "capinstitucion" + i;
        $("#listcap").append("<tr><td><input id='" + id3 + "' name='" + id3 + "' type='text' style='background-color: #F7FAFC;'/></td><td><input id='" + id4 + "' name='" + id4 + "' type='text' style='background-color: #F7FAFC;' /></td><td><input id='" + id5 + "' name='" + id5 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td><input id='" + id1 + "' name='" + id1 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td><input id='" + id2 + "' name='" + id2 + "' type='text' size='30' style='background-color: #F7FAFC;' value=''/></td></tr>");
        $("#" + id1).datepicker(); $("#" + id2).datepicker();
    }
    for(i=1;i<6;i++){
        id1 = "idiom" + i; id2 = "nivel" + i;
        $("#listidioma").append("<tr><td><input id='" + id1 + "' name='" + id1 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td>" + "<select style='background-color: #F7FAFC;' id='" + id2 + "' name='" + id2 + "' ><option value='BASICO'>BASICO</option><option value='INTERMEDIO'>INTERMEDIO</option><option value='AVANZADO'>AVANZADO</option><option value='NATIVO'>NATIVO</option></select>" + "</td></tr>");
    }
    for(i=1;i<11;i++) {
        id1 = "nomprem" + i; id2 = "fecprem" + i; id3 = "orgprem" + i;
        $("#listprem").append("<tr><td><input id='" + id1 + "' name='" + id1 + "' type='text' style='background-color: #F7FAFC;' value=''/></td><td><input id='" + id3 + "' name='" + id3 + "' type='text' style='background-color: #F7FAFC;' /></td><td><input id='" + id2 + "' name='" + id2 + "' type='text' style='background-color: #F7FAFC;' value='' /></td></tr>");
        $("#" + id2).datepicker();
    }
    for (i = 1; i < 6; i++) {
        id1 = "memb" + i; id2 = "membfecini" + i; id3 = "membfecter" + i; id4 = "instmemb" + i;
        $("#listmemb").append("<tr><td><input id='" + id1 + "' name='" + id1 + "' type='text' size='30' style='background-color: #F7FAFC;' value='' /></td><td><input id='" + id4 + "' name='" + id4 + "' type='text' size='30' style='background-color: #F7FAFC;' value='' /></td><td><input id='" + id2 + "' name='" + id2 + "' type='text' style='background-color: #F7FAFC;' /></td><td><input id='" + id3 + "' name='" + id3 + "' type='text' style='background-color: #F7FAFC;'/></td></tr>");
        $("#" + id2).datepicker(); $("#" + id3).datepicker();
    }
}

function esconde_entrada() {
    for (i = 1; i < 5; i++) {
        id1 = "#expfecini" + i; id2 = "#expfecter" + i; id3 = "#expcargo" + i; id4 = "#trabajaqui" + i;
        $(id1).hide(); $(id2).hide(); $(id3).hide(); $(id4).hide();
    }
    for (i = 1; i < 11; i++) {
        id1 = "#empfecini" + i; id2 = "#empfecter" + i; id3 = "#empcargo" + i; id4 = "#empresa" + i;
        $(id1).hide(); $(id2).hide(); $(id3).hide(); $(id4).hide();
    }
    for (i = 1; i < 9; i++) {
        id1 = "#forfecini" + i; id2 = "#forfecter" + i; id3 = "#forprograma" + i; id4 = "#forgrado" + i; id5 = "#forinstitucion" + i;
        $(id1).hide(); $(id2).hide(); $(id3).hide(); $(id4).hide(); $(id5).hide();
    }
    for (i = 1; i < 9; i++) {
        id1 = "#capfecini" + i; id2 = "#capfecter" + i; id3 = "#captitulo" + i; id4 = "#captitestudio"+i; id5 = "#capinstitucion" + i;
        $(id1).hide();$(id2).hide(); $(id3).hide();$(id4).hide();$(id5).hide();
    }
    for (i = 1; i < 6; i++) {
        id1 = "#idiom" + i; id2 = "#nivel" + i;
        $(id1).hide();$(id2).hide();
    }
    for (i = 1; i < 11; i++) {
        id1 = "#nomprem" + i; id2 = "#fecprem" + i; id3 = "#orgprem" + i;
        $(id1).hide();$(id2).hide();$(id3).hide();
    }
    for (i = 1; i < 6; i++) {
        id1 = "#memb" + i; id2 = "#membfecini" + i; id3 = "#membfecter" + i; id4 = "#instmemb" + i;
        $(id1).hide(); $(id2).hide(); $(id3).hide(); $(id4).hide();
    }
}


$(document).ready(function () {
    $("#agregaexp").click(function () {
        if (nexp < 5) {
            id1 = "#expfecini" + nexp; id2 = "#expfecter" + nexp; id3 = "#expcargo" + nexp; id4 = "#trabajaqui" + nexp;
            $(id1).show();
            $(id2).show();
            $(id3).show();
            $(id4).show();
            nexp++;
        }
    });
    $("#agregaemp").click(function () {
        if (nemp < 11) {
            id1 = "#empfecini" + nemp; id2 = "#empfecter" + nemp; id3 = "#empcargo" + nemp; id4 = "#empresa" + nemp;
            $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show();
            nemp++;
        }
    });
    $("#agregafor").click(function () {
        if (nfor < 9) {
            id1 = "#forfecini" + nfor; id2 = "#forfecter" + nfor; id3 = "#forprograma" + nfor; id4 = "#forgrado" + nfor; id5 = "#forinstitucion" + nfor;
            $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show(); $(id5).show();
            nfor++;
        }
    });
    $("#agregacap").click(function () {
        if (ncap < 9) {
            id1 = "#capfecini" + ncap; id2 = "#capfecter" + ncap; id3 = "#captitulo" + ncap; id4 = "#captitestudio"+ncap; id5 = "#capinstitucion" + ncap;
            $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show(); $(id5).show();
            ncap++;
        }
    });
    $("#agregaidioma").click(function () {
        if (nidiomas < 6) {
            id1 = "#idiom" + nidiomas; id2 = "#nivel" + nidiomas;
            $(id1).show(); $(id2).show();
            nidiomas++;
        }
    });
    $("#agregapremio").click(function () {
        if (npremios < 11) {
            id1 = "#nomprem" + npremios; id2 = "#fecprem" + npremios; id3 = "#orgprem" + npremios;
            $(id1).show(); $(id2).show(); $(id3).show();
            npremios++;
        }
    });
    $("#agregamemb").click(function () {
        if (nmemb < 6) {
            id1 = "#memb" + nmemb; id2 = "#membfecini" + nmemb; id3 = "#membfecter" + nmemb; id4 = "#instmemb" + nmemb;
            $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show();
            nmemb++;
        }
    });
    
    $("#abreexp").click(function () {
        $("#exper").toggle();
    });
    $("#abreemp").click(function () {
        $("#empleos").toggle();
    });
    $("#abrefor").click(function () {
        $("#formacion").toggle();
    });
    $("#abrecap").click(function () {
        $("#capacitaciones").toggle();
    });
    $("#abreidio").click(function () {
        $("#idioma").toggle();
    });
    $("#abreprem").click(function () {
        $("#premi").toggle();
    });
    $("#abrememb").click(function () {
        $("#membre").toggle();
    });

});

var dato_jef;
function leer_jefatura() {
    jefatura = "";
    if (dato_jef) { dato_jef.abort(); }
    usuario = $.cookie("IdMaestroUsuario");
    var param = '{' + '"usuario":' + '"' + usuario + '"}';
    urlmod = "Servicios/edddatosperf.asmx/leer_jefatura";
    dato_obj = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(data.d);
            jefatura = data.d;
            return jefatura;
        },
        error: function (data) {
            alert("Error Datos Jefatura");
        }
    });
    return jefatura;
}

var dato_perfil;
function carga_perfil(usuario_ad) {
    if (dato_perfil) { dato_perfil.abort(); }
    usuario = $.cookie("IdMaestroUsuario");
    var param = '{' + '"usuario":' + '"' + usuario + '"' + '}';
    //alert(param);
    urlmod = "Servicios/edddatosperf.asmx/leer_perfil";
    dato_perfil = $.ajax({
        url: urlmod,
        async: false,
        data: param,
        type: "POST",
        contentType: "application/json; charset=utf-8",    
        dataType: "json",
        success: function (data) {          
            if (data.d.length != 0) {
                var datosleidos = JSON.parse(data.d[0].cv_datos);
                $("#cv_id").val(datosleidos.cv_id);
                $("#cv_ad").val(datosleidos.cv_ad);
                $("#nombre1").val(datosleidos.nombre1.trim());
                $("#nombre2").val(datosleidos.nombre2.trim());
                $("#ape1").val(datosleidos.ape1);
                $("#ape2").val(datosleidos.ape2);
                $("#nacionalidad").val(datosleidos.nacionalidad);
                $("#cargo").val(datosleidos.cargo);
                $("#area").val(datosleidos.area);
                $("#gerencia").val(datosleidos.gerencia);
                $("#jefedirecto").val(leer_jefatura(usuario));

                $("#expfecini1").val(datosleidos.expfecini1);
                $("#expfecter1").val(datosleidos.expfecter1);
                $("#expcargo1").val(datosleidos.expcargo1.trim()); 
                $("#expfecini2").val(datosleidos.expfecini2); 
                $("#expfecter2").val(datosleidos.expfecter2);
                $("#expcargo2").val(datosleidos.expcargo2);
                $("#expfecini3").val(datosleidos.expfecini3);
                $("#expfecter3").val(datosleidos.expfecter3);
                $("#expcargo3").val(datosleidos.expcargo3);
                $("#expfecini4").val(datosleidos.expfecini4);
                $("#expfecter4").val(datosleidos.expfecter4);
                $("#expcargo4").val(datosleidos.expcargo4);
                $("#trabajaqui1").val(datosleidos.trabajaqui1);
                $("#trabajaqui2").val(datosleidos.trabajaqui2);
                $("#trabajaqui3").val(datosleidos.trabajaqui3);
                $("#trabajaqui4").val(datosleidos.trabajaqui4);
                for (i = 1; i < 5;i++)
                    if (!$("#expcargo" + i).val().length) break;
                nexp = i;

                $("#empfecini1").val(datosleidos.empfecini1);
                $("#empfecter1").val(datosleidos.empfecter1);
                $("#empcargo1").val(datosleidos.empcargo1);
                $("#empresa1").val(datosleidos.empresa1);
                $("#empfecini2").val(datosleidos.empfecini2);
                $("#empfecter2").val(datosleidos.empfecter2);
                $("#empcargo2").val(datosleidos.empcargo2);
                $("#empresa2").val(datosleidos.empresa2);
                $("#empfecini3").val(datosleidos.empfecini3);
                $("#empfecter3").val(datosleidos.empfecter3);
                $("#empcargo3").val(datosleidos.empcargo3);
                $("#empresa3").val(datosleidos.empresa3);
                $("#empfecini4").val(datosleidos.empfecini4);
                $("#empfecter4").val(datosleidos.empfecter4);
                $("#empcargo4").val(datosleidos.empcargo4);
                $("#empresa4").val(datosleidos.empresa4);
                $("#empfecini5").val(datosleidos.empfecini5);
                $("#empfecter5").val(datosleidos.empfecter5);
                $("#empcargo5").val(datosleidos.empcargo5);
                $("#empresa5").val(datosleidos.empresa5);
                $("#empfecini6").val(datosleidos.empfecini6);
                $("#empfecter6").val(datosleidos.empfecter6);
                $("#empcargo6").val(datosleidos.empcargo6);
                $("#empresa6").val(datosleidos.empresa6);
                $("#empfecini7").val(datosleidos.empfecini7);
                $("#empfecter7").val(datosleidos.empfecter7);
                $("#empcargo7").val(datosleidos.empcargo7);
                $("#empresa7").val(datosleidos.empresa7);
                $("#empfecini8").val(datosleidos.empfecini8);
                $("#empfecter8").val(datosleidos.empfecter8);
                $("#empcargo8").val(datosleidos.empcargo8);
                $("#empresa8").val(datosleidos.empresa8);
                $("#empfecini9").val(datosleidos.empfecini9);
                $("#empfecter9").val(datosleidos.empfecter9);
                $("#empcargo9").val(datosleidos.empcargo9);
                $("#empresa9").val(datosleidos.empresa9);
                $("#empfecini10").val(datosleidos.empfecini10);
                $("#empfecter10").val(datosleidos.empfecter10);
                $("#empcargo10").val(datosleidos.empcargo10);
                $("#empresa10").val(datosleidos.empresa10);
                for (i = 1; i < 11; i++)
                    if ( !$("#empcargo" + i).val().length) break;
                nemp = i;

                $("#forprograma1").val(datosleidos.forprograma1);
                $("#forprograma2").val(datosleidos.forprograma2);
                $("#forprograma3").val(datosleidos.forprograma3);
                $("#forprograma4").val(datosleidos.forprograma4);
                $("#forprograma5").val(datosleidos.forprograma5);
                $("#forprograma6").val(datosleidos.forprograma6);
                $("#forprograma7").val(datosleidos.forprograma7);
                $("#forprograma8").val(datosleidos.forprograma8);
                $("#forprograma9").val(datosleidos.forprograma9);
                $("#forgrado1").val(datosleidos.forgrado1);
                $("#forgrado2").val(datosleidos.forgrado2);
                $("#forgrado3").val(datosleidos.forgrado3);
                $("#forgrado4").val(datosleidos.forgrado4);
                $("#forgrado5").val(datosleidos.forgrado5);
                $("#forgrado6").val(datosleidos.forgrado6);
                $("#forgrado7").val(datosleidos.forgrado7);
                $("#forgrado8").val(datosleidos.forgrado8);
                $("#forgrado9").val(datosleidos.forgrado9);
                $("#forinstitucion1").val(datosleidos.forinstitucion1);
                $("#forinstitucion2").val(datosleidos.forinstitucion2);
                $("#forinstitucion3").val(datosleidos.forinstitucion3);
                $("#forinstitucion4").val(datosleidos.forinstitucion4);
                $("#forinstitucion5").val(datosleidos.forinstitucion5);
                $("#forinstitucion6").val(datosleidos.forinstitucion6);
                $("#forinstitucion7").val(datosleidos.forinstitucion7);
                $("#forinstitucion8").val(datosleidos.forinstitucion8);
                $("#forinstitucion9").val(datosleidos.forinstitucion9);
                $("#forfecini1").val(datosleidos.forfecini1);
                $("#forfecini2").val(datosleidos.forfecini2);
                $("#forfecini3").val(datosleidos.forfecini3);
                $("#forfecini4").val(datosleidos.forfecini4);
                $("#forfecini5").val(datosleidos.forfecini5);
                $("#forfecini6").val(datosleidos.forfecini6);
                $("#forfecini7").val(datosleidos.forfecini7);
                $("#forfecini8").val(datosleidos.forfecini8);
                $("#forfecini9").val(datosleidos.forfecini9);
                $("#forfecter1").val(datosleidos.forfecter1);
                $("#forfecter2").val(datosleidos.forfecter2);
                $("#forfecter3").val(datosleidos.forfecter3);
                $("#forfecter4").val(datosleidos.forfecter4);
                $("#forfecter5").val(datosleidos.forfecter5);
                $("#forfecter6").val(datosleidos.forfecter6);
                $("#forfecter7").val(datosleidos.forfecter7);
                $("#forfecter8").val(datosleidos.forfecter8);
                $("#forfecter9").val(datosleidos.forfecter9);
                for (i = 1; i < 9; i++)
                    if (!$("#forprograma" + i).val().length) break;
                nfor = i;

                $("#capfecini1").val(datosleidos.capfecini1);
                $("#capfecini2").val(datosleidos.capfecini2);
                $("#capfecini3").val(datosleidos.capfecini3);
                $("#capfecini4").val(datosleidos.capfecini4);
                $("#capfecini5").val(datosleidos.capfecini5);
                $("#capfecini6").val(datosleidos.capfecini6);
                $("#capfecini7").val(datosleidos.capfecini7);
                $("#capfecini8").val(datosleidos.capfecini8);
                $("#capfecter1").val(datosleidos.capfecter1);
                $("#capfecter2").val(datosleidos.capfecter2);
                $("#capfecter3").val(datosleidos.capfecter3);
                $("#capfecter4").val(datosleidos.capfecter4);
                $("#capfecter5").val(datosleidos.capfecter5);
                $("#capfecter6").val(datosleidos.capfecter6);
                $("#capfecter7").val(datosleidos.capfecter7);
                $("#capfecter8").val(datosleidos.capfecter8);
                $("#captitulo1").val(datosleidos.captitulo1);
                $("#captitulo2").val(datosleidos.captitulo2);
                $("#captitulo3").val(datosleidos.captitulo3);
                $("#captitulo4").val(datosleidos.captitulo4);
                $("#captitulo5").val(datosleidos.captitulo5);
                $("#captitulo6").val(datosleidos.captitulo6);
                $("#captitulo7").val(datosleidos.captitulo7);
                $("#captitulo8").val(datosleidos.captitulo8);
                $("#captitestudio1").val(datosleidos.captitestudio1);
                $("#captitestudio2").val(datosleidos.captitestudio2);
                $("#captitestudio3").val(datosleidos.captitestudio3);
                $("#captitestudio4").val(datosleidos.captitestudio4);
                $("#captitestudio5").val(datosleidos.captitestudio5);
                $("#captitestudio6").val(datosleidos.captitestudio6);
                $("#captitestudio7").val(datosleidos.captitestudio7);
                $("#captitestudio8").val(datosleidos.captitestudio8);
                $("#capinstitucion1").val(datosleidos.capinstitucion1);
                $("#capinstitucion2").val(datosleidos.capinstitucion2);
                $("#capinstitucion3").val(datosleidos.capinstitucion3);
                $("#capinstitucion4").val(datosleidos.capinstitucion4);
                $("#capinstitucion5").val(datosleidos.capinstitucion5);
                $("#capinstitucion6").val(datosleidos.capinstitucion6);
                $("#capinstitucion7").val(datosleidos.capinstitucion7);
                $("#capinstitucion8").val(datosleidos.capinstitucion8);
                for (i = 1; i < 9; i++)
                    if (!$("#captitestudio" + i).val().length) break;
                ncap = i;

                $("#idiom1").val(datosleidos.idiom1);
                $("#idiom2").val(datosleidos.idiom2);
                $("#idiom3").val(datosleidos.idiom3);
                $("#idiom4").val(datosleidos.idiom4);
                $("#idiom5").val(datosleidos.idiom5);
                $("#nivel1").val(datosleidos.nivel1);
                $("#nivel2").val(datosleidos.nivel2);
                $("#nivel3").val(datosleidos.nivel3);
                $("#nivel4").val(datosleidos.nivel4);
                $("#nivel5").val(datosleidos.nivel5);
                for (i = 1; i < 6; i++)
                    if (!$("#idiom" + i).val().length) break;
                nidiomas = i;
                $("#areapref1").val(datosleidos.areapref1);
                $("#disp1").val(datosleidos.disp1);
                $("#nomprem1").val(datosleidos.nomprem1);
                $("#nomprem2").val(datosleidos.nomprem2);
                $("#nomprem3").val(datosleidos.nomprem3);
                $("#nomprem4").val(datosleidos.nomprem4);
                $("#nomprem5").val(datosleidos.nomprem5);
                $("#nomprem6").val(datosleidos.nomprem6);
                $("#nomprem7").val(datosleidos.nomprem7);
                $("#nomprem8").val(datosleidos.nomprem8);
                $("#nomprem9").val(datosleidos.nomprem9);
                $("#nomprem10").val(datosleidos.nomprem10);                
                $("#fecprem1").val(datosleidos.fecprem1);
                $("#fecprem2").val(datosleidos.fecprem2);
                $("#fecprem3").val(datosleidos.fecprem3);
                $("#fecprem4").val(datosleidos.fecprem4);
                $("#fecprem5").val(datosleidos.fecprem5);
                $("#fecprem6").val(datosleidos.fecprem6);
                $("#fecprem7").val(datosleidos.fecprem7);
                $("#fecprem8").val(datosleidos.fecprem8);
                $("#fecprem9").val(datosleidos.fecprem9);
                $("#fecprem10").val(datosleidos.fecprem10);
                $("#orgprem1").val(datosleidos.orgprem1);
                $("#orgprem2").val(datosleidos.orgprem2);
                $("#orgprem3").val(datosleidos.orgprem3);
                $("#orgprem4").val(datosleidos.orgprem4);
                $("#orgprem5").val(datosleidos.orgprem5);
                $("#orgprem6").val(datosleidos.orgprem6);
                $("#orgprem7").val(datosleidos.orgprem7);
                $("#orgprem8").val(datosleidos.orgprem8);
                $("#orgprem9").val(datosleidos.orgprem9);
                $("#orgprem10").val(datosleidos.orgprem10);
                for (i = 1; i < 11; i++)
                    if (!$("#nomprem" + i).val().length) break;
                npremios = i;

                $("#memb1").val(datosleidos.memb1);
                $("#memb2").val(datosleidos.memb2);
                $("#memb3").val(datosleidos.memb3);
                $("#memb4").val(datosleidos.memb4);
                $("#memb5").val(datosleidos.memb5);
                $("#instmemb1").val(datosleidos.instmemb1);
                $("#instmemb2").val(datosleidos.instmemb2);
                $("#instmemb3").val(datosleidos.instmemb3);
                $("#instmemb4").val(datosleidos.instmemb4);
                $("#instmemb5").val(datosleidos.instmemb5);
                $("#membfecini1").val(datosleidos.membfecini1);
                $("#membfecini2").val(datosleidos.membfecini2);
                $("#membfecini3").val(datosleidos.membfecini3);
                $("#membfecini4").val(datosleidos.membfecini4);
                $("#membfecini5").val(datosleidos.membfecini5);
                $("#membfecter1").val(datosleidos.membfecter1);
                $("#membfecter2").val(datosleidos.membfecter2);
                $("#membfecter3").val(datosleidos.membfecter3);
                $("#membfecter4").val(datosleidos.membfecter4);
                $("#membfecter5").val(datosleidos.membfecter5);
                for (i = 1; i < 6; i++)
                    if (!$("#memb" + i).val().length) break;
                nmemb = i;
                //alert(nexp+'-'+nemp+'-'+ncap+'-'+nidiomas+'-'+npremios+'-'+nmemb);
            }
            else {
                $("#cv_id").val('"'+0+'"');
                $("#cv_ad").val('"'+usuario+'"');
                $("#nombre1").val("");
                $("#nombre2").val("");
                $("#ape1").val("");
                $("#ape2").val("");
                $("#nacionalidad").val("");
                $("#cargo").val("");
                $("#area").val("");
                $("#gerencia").val("");

                $("#expfecini1").val("");
                $("#expfecter1").val("");
                $("#expcargo1").val("");
                $("#expfecini2").val("");
                $("#expfecter2").val("");
                $("#expcargo2").val("");
                $("#expfecini3").val("");
                $("#expfecter3").val("");
                $("#expcargo3").val("");
                $("#expfecini4").val("");
                $("#expfecter4").val("");
                $("#expcargo4").val("");
                $("#trabajaqui1").val("");
                $("#trabajaqui2").val("");
                $("#trabajaqui3").val("");
                $("#trabajaqui4").val("");

                $("#empfecini1").val("");
                $("#empfecter1").val("");
                $("#empcargo1").val("");
                $("#empresa1").val("");
                $("#empfecini2").val("");
                $("#empfecter2").val("");
                $("#empcargo2").val("");
                $("#empresa2").val("");
                $("#empfecini3").val("");
                $("#empfecter3").val("");
                $("#empcargo3").val("");
                $("#empresa3").val("");
                $("#empfecini4").val("");
                $("#empfecter4").val("");
                $("#empcargo4").val("");
                $("#empresa4").val("");
                $("#empfecini5").val("");
                $("#empfecter5").val("");
                $("#empcargo5").val("");
                $("#empresa5").val("");
                $("#empfecini6").val("");
                $("#empfecter6").val("");
                $("#empcargo6").val("");
                $("#empresa6").val("");
                $("#empfecini7").val("");
                $("#empfecter7").val("");
                $("#empcargo7").val("");
                $("#empresa7").val("");
                $("#empfecini8").val("");
                $("#empfecter8").val("");
                $("#empcargo8").val("");
                $("#empresa8").val("");
                $("#empfecini9").val("");
                $("#empfecter9").val("");
                $("#empcargo9").val("");
                $("#empresa9").val("");
                $("#empfecini10").val("");
                $("#empfecter10").val("");
                $("#empcargo10").val("");
                $("#empresa10").val("");

                $("#forprograma1").val("");
                $("#forprograma2").val("");
                $("#forprograma3").val("");
                $("#forprograma4").val("");
                $("#forprograma5").val("");
                $("#forprograma6").val("");
                $("#forprograma7").val("");
                $("#forprograma8").val("");
                $("#forprograma9").val("");
                $("#forgrado1").val("");
                $("#forgrado2").val("");
                $("#forgrado3").val("");
                $("#forgrado4").val("");
                $("#forgrado5").val("");
                $("#forgrado6").val("");
                $("#forgrado7").val("");
                $("#forgrado8").val("");
                $("#forgrado9").val("");
                $("#forinstitucion1").val("");
                $("#forinstitucion2").val("");
                $("#forinstitucion3").val("");
                $("#forinstitucion4").val("");
                $("#forinstitucion5").val("");
                $("#forinstitucion6").val("");
                $("#forinstitucion7").val("");
                $("#forinstitucion8").val("");
                $("#forinstitucion9").val("");
                $("#forfecini1").val("");
                $("#forfecini2").val("");
                $("#forfecini3").val("");
                $("#forfecini4").val("");
                $("#forfecini5").val("");
                $("#forfecini6").val("");
                $("#forfecini7").val("");
                $("#forfecini8").val("");
                $("#forfecini9").val("");
                $("#forfecter1").val("");
                $("#forfecter2").val("");
                $("#forfecter3").val("");
                $("#forfecter4").val("");
                $("#forfecter5").val("");
                $("#forfecter6").val("");
                $("#forfecter7").val("");
                $("#forfecter8").val("");
                $("#forfecter9").val("");

                $("#capfecini1").val("");
                $("#capfecini2").val("");
                $("#capfecini3").val("");
                $("#capfecini4").val("");
                $("#capfecini5").val("");
                $("#capfecini6").val("");
                $("#capfecini7").val("");
                $("#capfecini8").val("");
                $("#capfecter1").val("");
                $("#capfecter2").val("");
                $("#capfecter3").val("");
                $("#capfecter4").val("");
                $("#capfecter5").val("");
                $("#capfecter6").val("");
                $("#capfecter7").val("");
                $("#capfecter8").val("");
                $("#captitulo1").val("");
                $("#captitulo2").val("");
                $("#captitulo3").val("");
                $("#captitulo4").val("");
                $("#captitulo5").val("");
                $("#captitulo6").val("");
                $("#captitulo7").val("");
                $("#captitulo8").val("");
                $("#captitestudio1").val("");
                $("#captitestudio2").val("");
                $("#captitestudio3").val("");
                $("#captitestudio4").val("");
                $("#captitestudio5").val("");
                $("#captitestudio6").val("");
                $("#captitestudio7").val("");
                $("#captitestudio8").val("");
                $("#capinstitucion1").val("");
                $("#capinstitucion2").val("");
                $("#capinstitucion3").val("");
                $("#capinstitucion4").val("");
                $("#capinstitucion5").val("");
                $("#capinstitucion6").val("");
                $("#capinstitucion7").val("");
                $("#capinstitucion8").val("");

                $("#idiom1").val("");
                $("#idiom2").val("");
                $("#idiom3").val("");
                $("#idiom4").val("");
                $("#idiom5").val("");
                $("#nivel1").val("");
                $("#nivel2").val("");
                $("#nivel3").val("");
                $("#nivel4").val("");
                $("#nivel5").val("");

                $("#areapref1").val("");
                $("#disp1").val("");

                $("#nomprem1").val("");
                $("#nomprem2").val("");
                $("#nomprem3").val("");
                $("#nomprem4").val("");
                $("#nomprem5").val("");
                $("#nomprem6").val("");
                $("#nomprem7").val("");
                $("#nomprem8").val("");
                $("#nomprem9").val("");
                $("#nomprem10").val("");
                $("#fecprem1").val("");
                $("#fecprem2").val("");
                $("#fecprem3").val("");
                $("#fecprem4").val("");
                $("#fecprem5").val("");
                $("#fecprem6").val("");
                $("#fecprem7").val("");
                $("#fecprem8").val("");
                $("#fecprem9").val("");
                $("#fecprem10").val("");
                $("#orgprem1").val("");
                $("#orgprem2").val("");
                $("#orgprem3").val("");
                $("#orgprem4").val("");
                $("#orgprem5").val("");
                $("#orgprem6").val("");
                $("#orgprem7").val("");
                $("#orgprem8").val("");
                $("#orgprem9").val("");
                $("#orgprem10").val("");

                $("#memb1").val("");
                $("#memb2").val("");
                $("#memb3").val("");
                $("#memb4").val("");
                $("#memb5").val("");
                $("#instmemb1").val("");
                $("#instmemb2").val("");
                $("#instmemb3").val("");
                $("#instmemb4").val("");
                $("#instmemb5").val("");
                $("#membfecini1").val("");
                $("#membfecini2").val("");
                $("#membfecini3").val("");
                $("#membfecini4").val("");
                $("#membfecini5").val("");
                $("#membfecter1").val("");
                $("#membfecter2").val("");
                $("#membfecter3").val("");
                $("#membfecter4").val("");
                $("#membfecter5").val("");
            }
        },
        error: function (data) {
            alert("error:" + xhr.responseText);
        }
    });
}

var dato_carga;  
function guardarperfil() {
    if (dato_carga) { dato_carga.abort(); }
    var datosperfil = '{ "nombre1": "' + $("#nombre1").val().trim() + '" '
    + ', "nombre2": "' + $("#nombre2").val().trim() + '" '
    + ', "ape1": "' + $("#ape1").val().trim() + '" '
    + ', "ape2": "' + $("#ape2").val().trim() + '" '
    + ', "nacionalidad": "' + $("#nacionalidad").val().trim() + '" '
    + ', "cargo": "' + $("#cargo").val().trim() + '" '
    + ', "area": "' + $("#area").val().trim() + '" '
    + ', "gerencia": "' + $("#gerencia").val().trim() + '" '
//    + ', "celular": "' + $("#celular").val() + '" '
    + ', "expfecini1": "' + $("#expfecini1").val() + '" '
    + ', "expfecter1": "' + $("#expfecter1").val() + '" '
    + ', "expcargo1": "' + $("#expcargo1").val() + '" '
    + ', "trabajaqui1": "' + $("#trabajaqui1").val() + '" '
    + ', "expfecini2": "' + $("#expfecini2").val() + '" '
    + ', "expfecter2": "' + $("#expfecter2").val() + '" '
    + ', "expcargo2": "' + $("#expcargo2").val() + '" '
    + ', "trabajaqui2": "' + $("#trabajaqui2").val() + '" '
    + ', "expfecini3": "' + $("#expfecini3").val() + '" '
    + ', "expfecter3": "' + $("#expfecter3").val() + '" '
    + ', "expcargo3": "' + $("#expcargo3").val() + '" '
    + ', "trabajaqui3": "' + $("#trabajaqui3").val() + '" '
    + ', "expfecini4": "' + $("#expfecini4").val() + '" '
    + ', "expfecter4": "' + $("#expfecter4").val() + '" '
    + ', "expcargo4": "' + $("#expcargo4").val() + '" '
    + ', "trabajaqui4": "' + $("#trabajaqui4").val() + '" '
    + ', "empfecini1": "' + $("#empfecini1").val() + '" '
    + ', "empfecini2": "' + $("#empfecini2").val() + '" '
    + ', "empfecini3": "' + $("#empfecini3").val() + '" '
    + ', "empfecini4": "' + $("#empfecini4").val() + '" '
    + ', "empfecini5": "' + $("#empfecini5").val() + '" '
    + ', "empfecini6": "' + $("#empfecini6").val() + '" '
    + ', "empfecini7": "' + $("#empfecini7").val() + '" '
    + ', "empfecini8": "' + $("#empfecini8").val() + '" '
    + ', "empfecini9": "' + $("#empfecini9").val() + '" '
    + ', "empfecini10": "' + $("#empfecini10").val() + '" '
    + ', "empfecter1": "' + $("#empfecter1").val() + '" '
    + ', "empfecter2": "' + $("#empfecter2").val() + '" '
    + ', "empfecter3": "' + $("#empfecter3").val() + '" '
    + ', "empfecter4": "' + $("#empfecter4").val() + '" '
    + ', "empfecter5": "' + $("#empfecter5").val() + '" '
    + ', "empfecter6": "' + $("#empfecter6").val() + '" '
    + ', "empfecter7": "' + $("#empfecter7").val() + '" '
    + ', "empfecter8": "' + $("#empfecter8").val() + '" '
    + ', "empfecter9": "' + $("#empfecter9").val() + '" '
    + ', "empfecter10": "' + $("#empfecter10").val() + '" '
    + ', "empcargo1": "' + $("#empcargo1").val() + '" '
    + ', "empcargo2": "' + $("#empcargo2").val() + '" '
    + ', "empcargo3": "' + $("#empcargo3").val() + '" '
    + ', "empcargo4": "' + $("#empcargo4").val() + '" '
    + ', "empcargo5": "' + $("#empcargo5").val() + '" '
    + ', "empcargo6": "' + $("#empcargo6").val() + '" '
    + ', "empcargo7": "' + $("#empcargo7").val() + '" '
    + ', "empcargo8": "' + $("#empcargo8").val() + '" '
    + ', "empcargo9": "' + $("#empcargo9").val() + '" '
    + ', "empcargo10": "' + $("#empcargo10").val() + '" '
    + ', "empresa1": "' + $("#empresa1").val() + '" '
    + ', "empresa2": "' + $("#empresa2").val() + '" '
    + ', "empresa3": "' + $("#empresa3").val() + '" '
    + ', "empresa4": "' + $("#empresa4").val() + '" '
    + ', "empresa5": "' + $("#empresa5").val() + '" '
    + ', "empresa6": "' + $("#empresa6").val() + '" '
    + ', "empresa7": "' + $("#empresa7").val() + '" '
    + ', "empresa8": "' + $("#empresa8").val() + '" '
    + ', "empresa9": "' + $("#empresa9").val() + '" '
    + ', "empresa10": "' + $("#empresa10").val() + '" '
    + ', "forprograma1": "' + $("#forprograma1").val() + '" '
    + ', "forprograma2": "' + $("#forprograma2").val() + '" '
    + ', "forprograma3": "' + $("#forprograma3").val() + '" '
    + ', "forprograma4": "' + $("#forprograma4").val() + '" '
    + ', "forprograma5": "' + $("#forprograma5").val() + '" '
    + ', "forprograma6": "' + $("#forprograma6").val() + '" '
    + ', "forprograma7": "' + $("#forprograma7").val() + '" '
    + ', "forprograma8": "' + $("#forprograma8").val() + '" '
    + ', "forprograma9": "' + $("#forprograma8").val() + '" '
    + ', "forgrado1": "' + $("#forgrado1").val() + '" '
    + ', "forgrado2": "' + $("#forgrado2").val() + '" '
    + ', "forgrado3": "' + $("#forgrado3").val() + '" '
    + ', "forgrado4": "' + $("#forgrado4").val() + '" '
    + ', "forgrado5": "' + $("#forgrado5").val() + '" '
    + ', "forgrado6": "' + $("#forgrado6").val() + '" '
    + ', "forgrado7": "' + $("#forgrado7").val() + '" '
    + ', "forgrado8": "' + $("#forgrado8").val() + '" '
    + ', "forgrado9": "' + $("#forgrado8").val() + '" '
    + ', "forinstitucion1": "' + $("#forinstitucion1").val() + '" '
    + ', "forinstitucion2": "' + $("#forinstitucion2").val() + '" '
    + ', "forinstitucion3": "' + $("#forinstitucion3").val() + '" '
    + ', "forinstitucion4": "' + $("#forinstitucion4").val() + '" '
    + ', "forinstitucion5": "' + $("#forinstitucion5").val() + '" '
    + ', "forinstitucion6": "' + $("#forinstitucion6").val() + '" '
    + ', "forinstitucion7": "' + $("#forinstitucion7").val() + '" '
    + ', "forinstitucion8": "' + $("#forinstitucion8").val() + '" '
    + ', "forinstitucion9": "' + $("#forinstitucion8").val() + '" '
    + ', "forfecini1": "' + $("#forfecini1").val() + '" '
    + ', "forfecini2": "' + $("#forfecini2").val() + '" '
    + ', "forfecini3": "' + $("#forfecini3").val() + '" '
    + ', "forfecini4": "' + $("#forfecini4").val() + '" '
    + ', "forfecini5": "' + $("#forfecini5").val() + '" '
    + ', "forfecini6": "' + $("#forfecini6").val() + '" '
    + ', "forfecini7": "' + $("#forfecini7").val() + '" '
    + ', "forfecini8": "' + $("#forfecini8").val() + '" '
    + ', "forfecini9": "' + $("#forfecini8").val() + '" '
    + ', "forfecter1": "' + $("#forfecter1").val() + '" '
    + ', "forfecter2": "' + $("#forfecter2").val() + '" '
    + ', "forfecter3": "' + $("#forfecter3").val() + '" '
    + ', "forfecter4": "' + $("#forfecter4").val() + '" '
    + ', "forfecter5": "' + $("#forfecter5").val() + '" '
    + ', "forfecter6": "' + $("#forfecter6").val() + '" '
    + ', "forfecter7": "' + $("#forfecter7").val() + '" '
    + ', "forfecter8": "' + $("#forfecter8").val() + '" '
    + ', "forfecter9": "' + $("#forfecter8").val() + '" '
    + ', "capfecini1": "' + $("#capfecini1").val() + '" '
    + ', "capfecini2": "' + $("#capfecini2").val() + '" '
    + ', "capfecini3": "' + $("#capfecini3").val() + '" '
    + ', "capfecini4": "' + $("#capfecini4").val() + '" '
    + ', "capfecini5": "' + $("#capfecini5").val() + '" '
    + ', "capfecini6": "' + $("#capfecini6").val() + '" '
    + ', "capfecini7": "' + $("#capfecini7").val() + '" '
    + ', "capfecini8": "' + $("#capfecini8").val() + '" '
    + ', "capfecter1": "' + $("#capfecter1").val() + '" '
    + ', "capfecter2": "' + $("#capfecter2").val() + '" '
    + ', "capfecter3": "' + $("#capfecter3").val() + '" '
    + ', "capfecter4": "' + $("#capfecter4").val() + '" '
    + ', "capfecter5": "' + $("#capfecter5").val() + '" '
    + ', "capfecter6": "' + $("#capfecter6").val() + '" '
    + ', "capfecter7": "' + $("#capfecter7").val() + '" '
    + ', "capfecter8": "' + $("#capfecter8").val() + '" '
    + ', "captitulo1": "' + $("#captitulo1").val() + '" '
    + ', "captitulo2": "' + $("#captitulo2").val() + '" '
    + ', "captitulo3": "' + $("#captitulo3").val() + '" '
    + ', "captitulo4": "' + $("#captitulo4").val() + '" '
    + ', "captitulo5": "' + $("#captitulo5").val() + '" '
    + ', "captitulo6": "' + $("#captitulo6").val() + '" '
    + ', "captitulo7": "' + $("#captitulo7").val() + '" '
    + ', "captitulo8": "' + $("#captitulo8").val() + '" '
    + ', "captitestudio1": "' + $("#captitestudio1").val() + '" '
    + ', "captitestudio2": "' + $("#captitestudio2").val() + '" '
    + ', "captitestudio3": "' + $("#captitestudio3").val() + '" '
    + ', "captitestudio4": "' + $("#captitestudio4").val() + '" '
    + ', "captitestudio5": "' + $("#captitestudio5").val() + '" '
    + ', "captitestudio6": "' + $("#captitestudio6").val() + '" '
    + ', "captitestudio7": "' + $("#captitestudio7").val() + '" '
    + ', "captitestudio8": "' + $("#captitestudio8").val() + '" '
    + ', "capinstitucion1": "' + $("#capinstitucion1").val() + '" '
    + ', "capinstitucion2": "' + $("#capinstitucion2").val() + '" '
    + ', "capinstitucion3": "' + $("#capinstitucion3").val() + '" '
    + ', "capinstitucion4": "' + $("#capinstitucion4").val() + '" '
    + ', "capinstitucion5": "' + $("#capinstitucion5").val() + '" '
    + ', "capinstitucion6": "' + $("#capinstitucion6").val() + '" '
    + ', "capinstitucion7": "' + $("#capinstitucion7").val() + '" '
    + ', "capinstitucion8": "' + $("#capinstitucion8").val() + '" '
    + ', "idiom1": "' + $("#idiom1").val() + '" '
    + ', "idiom2": "' + $("#idiom2").val() + '" '
    + ', "idiom3": "' + $("#idiom3").val() + '" '
    + ', "idiom4": "' + $("#idiom4").val() + '" '
    + ', "idiom5": "' + $("#idiom5").val() + '" '
    + ', "nivel1": "' + $("#nivel1").val() + '" '
    + ', "nivel2": "' + $("#nivel2").val() + '" '
    + ', "nivel3": "' + $("#nivel3").val() + '" '
    + ', "nivel4": "' + $("#nivel4").val() + '" '
    + ', "nivel5": "' + $("#nivel5").val() + '" '
    + ', "areapref1": "' + $("#areapref1").val() + '" '
    + ', "disp1": "' + $("#disp1").val() + '" '
    + ', "nomprem1": "' + $("#nomprem1").val() + '" '
    + ', "nomprem2": "' + $("#nomprem2").val() + '" '
    + ', "nomprem3": "' + $("#nomprem3").val() + '" '
    + ', "nomprem4": "' + $("#nomprem4").val() + '" '
    + ', "nomprem5": "' + $("#nomprem5").val() + '" '
    + ', "nomprem6": "' + $("#nomprem6").val() + '" '
    + ', "nomprem7": "' + $("#nomprem7").val() + '" '
    + ', "nomprem8": "' + $("#nomprem8").val() + '" '
    + ', "nomprem9": "' + $("#nomprem9").val() + '" '
    + ', "nomprem10": "' + $("#nomprem10").val() + '" '
    + ', "fecprem1": "' + $("#fecprem1").val() + '" '
    + ', "fecprem2": "' + $("#fecprem2").val() + '" '
    + ', "fecprem3": "' + $("#fecprem3").val() + '" '
    + ', "fecprem4": "' + $("#fecprem4").val() + '" '
    + ', "fecprem5": "' + $("#fecprem5").val() + '" '
    + ', "fecprem6": "' + $("#fecprem6").val() + '" '
    + ', "fecprem7": "' + $("#fecprem7").val() + '" '
    + ', "fecprem8": "' + $("#fecprem8").val() + '" '
    + ', "fecprem9": "' + $("#fecprem9").val() + '" '
    + ', "fecprem10": "' + $("#fecprem10").val() + '" '
    + ', "orgprem1": "' + $("#orgprem1").val() + '" '
    + ', "orgprem2": "' + $("#orgprem2").val() + '" '
    + ', "orgprem3": "' + $("#orgprem3").val() + '" '
    + ', "orgprem4": "' + $("#orgprem4").val() + '" '
    + ', "orgprem5": "' + $("#orgprem5").val() + '" '
    + ', "orgprem6": "' + $("#orgprem6").val() + '" '
    + ', "orgprem7": "' + $("#orgprem7").val() + '" '
    + ', "orgprem8": "' + $("#orgprem8").val() + '" '
    + ', "orgprem9": "' + $("#orgprem9").val() + '" '
    + ', "orgprem10": "' + $("#orgprem10").val() + '" '
    + ', "memb1": "' + $("#memb1").val() + '" '
    + ', "memb2": "' + $("#memb2").val() + '" '
    + ', "memb3": "' + $("#memb3").val() + '" '
    + ', "memb4": "' + $("#memb4").val() + '" '
    + ', "memb5": "' + $("#memb5").val() + '" '
    + ', "instmemb1": "' + $("#instmemb1").val() + '" '
    + ', "instmemb2": "' + $("#instmemb2").val() + '" '
    + ', "instmemb3": "' + $("#instmemb3").val() + '" '
    + ', "instmemb4": "' + $("#instmemb4").val() + '" '
    + ', "instmemb5": "' + $("#instmemb5").val() + '" '
    + ', "membfecini1": "' + $("#membfecini1").val() + '" '
    + ', "membfecini2": "' + $("#membfecini2").val() + '" '
    + ', "membfecini3": "' + $("#membfecini3").val() + '" '
    + ', "membfecini4": "' + $("#membfecini4").val() + '" '
    + ', "membfecini5": "' + $("#membfecini5").val() + '" '
    + ', "membfecter1": "' + $("#membfecter1").val() + '" '
    + ', "membfecter2": "' + $("#membfecter2").val() + '" '
    + ', "membfecter3": "' + $("#membfecter3").val() + '" '
    + ', "membfecter4": "' + $("#membfecter4").val() + '" '
    + ', "membfecter5": "' + $("#membfecter5").val() + '" }';
    if ($.cookie("IdMaestroUsuario") == null)
        cvad = 0
    else
        cvad = parseInt($.cookie("IdMaestroUsuario"));



    datosperfil = "cvad=" + cvad + "&datosperfil=" + datosperfil;
    //alert(datosperfil);
    //var blobf = new Blob([datosperfil], { type: "text/csv;charset=utf-8" });
    //if (window.navigator.msSaveOrOpenBlob) {
    //    window.navigator.msSaveBlob(blobf, 'log.txt');
    //}
    
    urlmod = "Servicios/edddatosperf.asmx/guardar_perfil";
    dato_perfil = $.ajax({
        url: urlmod,
        async: false,
        data: datosperfil,
        type: "POST",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "text",
        success: function (data) {
            $("#guardarperfil").css("background-color", "#215778");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("error:" + jqXHR.status);
            alert("error:" + jqXHR.responseText);
        }
    });
    //$("#guardarperfil").css("background-color", "#D8D8D8");
}

function muestra_perfil() {
    for (i = 1; i <nexp; i++) {
        id1 = "#expfecini" + i; id2 = "#expfecter" + i; id3 = "#expcargo" + i;
        $(id1).show(); $(id2).show(); $(id3).show();
    }
    for (i = 1; i <nemp; i++) {
        id1 = "#empfecini" + i; id2 = "#empfecter" + i; id3 = "#empcargo" + i; id4 = "#empresa" + i;
        $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show();
    }
    for (i = 1; i < nfor; i++) {
        id1 = "#forfecini" + i; id2 = "#forfecter" + i; id3 = "#forprograma" + i; id4 = "#forgrado" + i; id5 = "#forinstitucion" + i;
        $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show(); $(id5).show();
    }
    for (i = 1; i <ncap; i++) {
        id1 = "#capfecini" + i; id2 = "#capfecter" + i; id3 = "#captitulo" + i; id4 = "#captitestudio" + i; id5 = "#capinstitucion" + i;
        $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show(); $(id5).show();
    }
    for (i = 1; i <nidiomas; i++) {
        id1 = "#idiom" + i; id2 = "#nivel" + i;
        $(id1).show(); $(id2).show();
    }
    for (i = 1; i <npremios; i++) {
        id1 = "#nomprem" + i; id2 = "#fecprem" + i; id3 = "#orgprem" + i;
        $(id1).show(); $(id2).show(); $(id3).show();
    }
    for (i = 1; i < nmemb; i++) {
        id1 = "#memb" + i; id2 = "#membfecini" + i; id3 = "#membfecter" + i; id4 = "#instmemb" + i;
        $(id1).show(); $(id2).show(); $(id3).show(); $(id4).show();
    }
}
