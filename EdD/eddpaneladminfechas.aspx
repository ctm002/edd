<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eddpaneladminfechas.aspx.cs" Inherits="EdD.eddpaneladminfechas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Panel de Funciones</title>
    <link href="/estilos/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="/estilos/estilos.css" type="text/css" rel="stylesheet" />
    <link href="/estilos/panel.css" type="text/css" rel="stylesheet" />
    <script src="/js/jquery-1.11.12.js"></script>
    <script src="/js/jquery-ui.js"></script>
    <script src="/js/jquery.cookie.js"></script>
    <script src="/js/funciones.js"></script>
 <script>
     function volver_fechas() {
         window.location.href = "eddpaneladmin.aspx";
     }
     var dato_fechas;
     function lee_fechas() {
             if (dato_fechas) { dato_fechas.abort(); }
             urlmod = "Servicios/edddatosperf.asmx/lee_eval";
             dato_fechas = $.ajax({
                 url: urlmod,
                 async: false,
                 data: {},
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     //var obj = JSON.parse(data.d[0]);
                     $.cookie("fecha_primera_evaluacion", data.d[0].eval_fecha_primera_evaluacion);
                     $.cookie("fecha_intermedio", data.d[0].eval_fecha_intermedio);
                     $("#fechaprimera").val($.cookie("fecha_primera_evaluacion").substring(0,10));
                     $("#fechasegunda").val($.cookie("fecha_intermedio").substring(0,10));
                 },
                 error: function (data) {
                     alert("Error Datos Fechas");
                 }
             });
     }

     var dato_gfec;
     function guardar_fechas() {
         if (dato_gfec) { dato_gfec.abort(); }
         urlmod = "Servicios/edddatosperf.asmx/act_eval";
         fecuno = $("#fechaprimera").val();
         fecdos = $("#fechasegunda").val();
         param = '{' + '"fecuno":' + '"' + fecuno + '"' +','+ '"fecdos":' + '"' + fecdos + '"' + '}';
         //alert(param);
         dato_gfec = $.ajax({
             url: urlmod,
             async: false,
             data: param,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (data) {
             },
             error: function (data) {
                 alert("Error Guarda Fechas");
             }
         });

     }
 </script>
    <style type="text/css">
        .auto-style2 {
            float: left;
            width: 115px;
            margin-top:40px;
        }
        .auto-style22 {
            float: left;
            width: 400px;
            margin-top:40px;
        }
        .auto-style3 {
            float: inherit;
            height: 307px;
            width: 662px;
            margin-left: 154px;
            margin-right: 120px;
            margin-top: 0px;
        }
        .auto-style4 {
            width: 938px;
            height: 364px;
            margin-top:10px;
        }
        .auto-style6 {
            width: 936px;
        }
        .auto-style7 {
            float: left;
            width: 678px;
        }
        .auto-style8 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #215778;
            color: white;
            padding: 8px 10px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 12px;
            margin: 4px 2px 4px 958px;
            border-radius: 5px;
        }
        .auto-style10 {
            width: 1074px;
            height: 41px;
        }
    </style>
</head>
<body onload="lee_fechas()" style="height: 45px; width: 952px;">
    <div style="margin-left:100px;">
      <div id="cajasuperior" class="cajasuperior">
       <div>
            <img src="/imagenes/circle_cariola.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 680px;" />
            <img src="/imagenes/circle_sargent.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
            <img src="/imagenes/circle_weekmark.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
       </div>     
    </div>
   <div style="clear:both;"></div>
     <div class="auto-style2">
       <div style="float: left; width: 50px; margin-left: 22px;"><button id="guardarfechas" onclick="guardar_fechas()" class="btn" style="width: 107px; ">Guardar</button></div>
       <div style="float: left; width: 50px; margin-left: 22px;"><button id="volverpanel" onclick="volver_fechas()" class="btn" style="width: 107px; ">Volver</button></div>        
     </div>
     <div class="auto-style22">
         <div style="float:left; margin-left:50px;">Fecha Primera Etapa: <input id="fechaprimera" type="text" size="10"/></div>
         <div style="float:left; margin-left:50px;margin-top:10px;">Fecha Segunda Etapa: <input id="fechasegunda" type="text" size="10"/></div>
     </div>


<div id="dialogoayuda" title="Ayuda" class="auto-style6"></div>

<script>
    //$("#resumen").hide();
if ($.cookie("IdMaestroUsuario") == null) { alert("Acceso No Autorizado"); window.location.href = "edd.aspx"; }
</script>
</div>
</body>
</html>

