<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="informes.aspx.cs" Inherits="EdD.informes" %>

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
    <script src="/js/panel.js"></script>
    <script src="/js/informes.js"></script>
    <style type="text/css">
        .auto-style2 {
            float: left;
            width: 115px;
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
        table {
           border: none !important;
        }

        td {
           width:200px;
           padding:4px;
           text-align:left;
           border: none !important;
        }
    </style>
</head>
<body style="height: 45px; width: 952px;">
    <div style="margin-left:100px;">
      <div id="cajasuperior" class="cajasuperior">
       <div>
            <img src="/imagenes/circle_cariola.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 680px;" />
            <img src="/imagenes/circle_sargent.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
            <img src="/imagenes/circle_weekmark.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
       </div>     
    </div>
    <div style="margin-top: 10px; " class="auto-style10">
        <div style="float: left; width: 50px; margin-left: 718px;"><button id="informeeval" onclick="mostrar_informe()" class="btn" style="width: 63px; ">Informe</button></div>        
        <div style="float: left; width: 50px; margin-left: 26px;"><button id="graficoeval" onclick="mostrar_grafico()" class="btn" style="width: 63px; ">Grafico</button></div>        
       <div style="float: left; width: 50px; margin-left: 26px;"><button id="ayuda" onclick="ayuda()" class="btn" style="width: 63px; ">Ayuda</button></div>        
       <div style="float: left; width: 50px; margin-left: 26px;"><button id="volver" onclick="volver()" class="btn" style="width: 63px; ">Inicio</button></div>        
    </div>
   <div style="clear:both;"></div>

<div id="informegerente" style="position: absolute;padding:6px;line-height: 80%;margin-top:30px;margin-left:30px;width:820px; height:550px; border: 1px solid #063E74; border-collapse: collapse; border-radius: 4px 4px 4px 4px; visibility:hidden;">
<p>INFORME ESTADO EVALUACION</p>
<table>
    <tr><td>Cargo</td><td>Estado Objetivos</td><td>Estado Competencias</td></tr>
    <tr><td>Gerente</td><td>Pendiente</td><td>Completado</td></tr>
    <tr><td>SubGerente</td><td>Completado</td><td>Completado</td></tr>
    <tr><td>Admin1</td><td>Completado</td><td>Pendiente</td></tr>
    <tr><td>Admin2</td><td>Pendiente</td><td>Completado</td></tr>
</table>
</div>

<div id="informesubgerente" style="position: absolute;padding:6px;line-height: 80%;margin-top:30px;margin-left:30px;width:820px; height:550px; border: 1px solid #063E74; border-collapse: collapse; border-radius: 4px 4px 4px 4px; visibility:hidden;">
<p>INFORME ESTADO EVALUACION</p>
    <table>
    <tr><td>Cargo</td><td>Estado Objetivos</td><td>Estado Competencias</td></tr>
    <tr><td>Subgerente</td><td>Completado</td><td>Completado</td></tr>
    <tr><td>Admin1</td><td>Completado</td><td>Pendiente</td></tr>
    <tr><td>Admin2</td><td>Pendiente</td><td>Completado</td></tr>
</table>
</div>

<div id="graficogerente" style="position: absolute;padding:6px;line-height: 80%;margin-top:30px;margin-left:30px;width:820px; height:550px; border: 1px solid #063E74; border-collapse: collapse; border-radius: 4px 4px 4px 4px; visibility:hidden;">
<p>GRAFICO ESTADO EVALUACION</p>
</div>

<div id="graficosubgerente" style="position: absolute;padding:6px;line-height: 80%;margin-top:30px;margin-left:30px;width:820px; height:550px; border: 1px solid #063E74; border-collapse: collapse; border-radius: 4px 4px 4px 4px; visibility:hidden;">
<p>GRAFICO ESTADO EVALUACION</p>
</div>


<div id="dialogoayuda" title="Ayuda" class="auto-style6"></div>

<script>
if ($.cookie("IdMaestroUsuario") == null) { alert("Acceso No Autorizado"); window.location.href = "edd.aspx"; }
</script>
</div>
</body>
</html>
