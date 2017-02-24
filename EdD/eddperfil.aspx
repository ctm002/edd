<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eddperfil.aspx.cs" Inherits="EdD.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head>
    <title></title>
    <link href="../estilos/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="../estilos/cv.css" type="text/css" rel="stylesheet" />
    <link href="/estilos/estilos.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.11.12.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.cookie.js"></script>
    <script src="../js/cv.js"></script>
    <script src="../js/funciones.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 1012px;
            height: 41px;
            margin-top: 10px;
        }
        .auto-style2 {
            float: left;
            width: 80px;
            margin-left: 712px;
        }
        .auto-style3 {
            float: left;
            width: 139px;
            margin-left: 2px;
            height: 37px;
        }
    </style>
</head>
<body>
<div style="margin-left:100px;">
<div id="cajasuperior" class="cajasuperior">
<div>
            <img src="/imagenes/circle_cariola.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 680px;" />
            <img src="/imagenes/circle_sargent.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
            <img src="/imagenes/circle_weekmark.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
</div>     
</div>

<div class="auto-style1">
<div class="auto-style2"><button id="guardarperfil" onclick="guardarperfil()">Guardar</button></div>
<div class="auto-style3"><button id="volver" onclick="volver()">Inicio</button></div>
<form id="form1" runat="server">
            <asp:Button ID="Button_Imprimir" runat="server" OnClick="Button_Imprimir_Click" Text="Imprimir" CssClass="btn" Height="30px" />			
</form>
</div>
<div style="height: 99px; margin-top: 0px;"></div>
<div id="perfil" style="margin-top:40px">
<div id="usuario"><div style="padding-top: 4px;font-size:18px;">PERFIL PERSONAL</div></div>
<div id="cvcaja">
<div id="infopersonal">
<table style="width: 800px; font-size: 14px; border-spacing: 3px;">
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">NOMBRE</td><td><input id="nombre1" name="nombre1" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">SEGUNDO NOMBRE</td><td><input id="nombre2" name="nombre2" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly"/></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">APELLIDO PATERNO</td><td><input id="ape1" name="ape1" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">APELLIDO MATERNO</td><td><input id="ape2" name="ape2" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">NACIONALIDAD</td><td><input id="nacionalidad" name="nacionalidad" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">CARGO</td><td><input id="cargo" name="cargo" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">&Aacute;REA</td><td><input id="area" name="area" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">GERENCIA</td><td><input id="gerencia" name="gerencia" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
<tr>
<td style="text-align: right; margin:0px;font-weight: bold;">JEFE DIRECTO</td><td><input id="jefedirecto" name="jefedirecto" type="text" size="25" maxlength="25" style="background-color: #F7FAFC;" readonly="readonly" /></td>
</tr>
</table>
</div>

<div id="experiencia">
<div style="margin-top:2px;">
<table>
<tr>
<td style="width:930px;">EXPERIENCIA LABORAL EN LA ORGANIZACI&Oacute;N</td>
<td style="width:30px;"><button id="agregaexp">+</button></td>
<td style="width:30px;"><button id="abreexp">[]</button></td>
</tr>
</table>
</div>
</div>
<div class="fondo"></div>
<div id="exper" style="margin-top: -20px; margin-left:5px;">
<table id="listexp" style="font-size:14px;border-spacing: 0px;" >
<tr>
<th style="background-color:#E7F3FB;">CARGO</th><th style="background-color:#E7F3FB;">FECHA INICIO</th><th style="background-color:#E7F3FB;">FECHA T&Eacute;RMINO</th><th style="background-color:#E7F3FB;">TRABAJO AQU&iacute; ACTUALMENTE</th>
</tr>
</table> 
</div>

<div id="empleoant">
<div style="margin-top:2px;">
<table>
<tr>
<td style="width:930px;">EMPLEO ANTERIOR</td>
<td style="width:30px;"><button id="agregaemp">+</button></td>
<td style="width:30px;"><button id="abreemp">[]</button></td>
</tr>
</table>
</div>
</div>

<div class="fondo"></div>

<div id="empleos" style="margin-top: -20px;margin-left:5px;">
<table id="listemp"  style="font-size:14px;border-spacing: 0px;">
<tr>
<th style="background-color:#E7F3FB;">CARGO</th><th style="background-color:#E7F3FB;">NOMBRE COMPAÑIA</th><th style="background-color:#E7F3FB;">FECHA INICIO</th><th style="background-color:#E7F3FB;">FECHA T&Eacute;RMINO</th>
</tr>
</table>
</div>

<div id="educacion">
<div style="margin-top:2px;">
<table>
<tr>
<td style="width:930px;">FORMACI&Oacute;N EDUCACIONAL</td>
<td style="width:30px;"><button id="agregafor">+</button></td>
<td style="width:30px;"><button id="abrefor">[]</button></td>
</tr>
</table>
</div>
</div>

<div class="fondo"></div>

<div id="formacion" style="margin-top:-20px;margin-left:5px; ">
<table id="listfor"  style="font-size:14px; border-spacing: 0px;">
<tr>
<th style="background-color:#E7F3FB;"">NOMBRE PROGRAMA</th><th style="background-color:#E7F3FB;">GRADO DE ESTUDIO</th><th style="background-color:#E7F3FB;">CENTRO DE ESTUDIOS</th><th style="background-color:#E7F3FB;">FECHA INICIO</th><th style="background-color:#E7F3FB;">FECHA T&Eacute;RMINO</th>
</tr>
</table>
</div>

<div class="fondo"></div>

<div id="educacion1">
<div style="margin-top:2px;">
<table>
<tr>
<td style="width:930px;">CAPACITACI&Oacute;N/CURSOS</td>
<td style="width:30px;"><button id="agregacap">+</button></td>
<td style="width:30px;"><button id="abrecap">[]</button></td>
</tr>
</table>
</div>
</div>
<div id="capacitaciones" style="margin-top:-20px;margin-left:5px; ">
<table id="listcap"  style="font-size:14px; border-spacing: 0px;">
<tr>
<th style="background-color:#E7F3FB;">NOMBRE PROGRAMA</th><<th style="background-color:#E7F3FB;">TIPO DE CAPACITACI&Oacute;N</th><th style="background-color:#E7F3FB;"">CENTRO DE ESTUDIOS</th><th style="background-color:#E7F3FB;">FECHA INICIO</th><th style="background-color:#E7F3FB;">FECHA T&Eacute;RMINO</th>
</tr>
</table>
</div>
<div class="fondo"></div>

<div id="idiomas">
    <div style="margin-top:2px;">
<table>
<tr>
<td style="width:930px;">IDIOMAS</td>
<td style="width:30px;" ><button id="agregaidioma">+</button></td>
<td style="width:30px;" ><button id="abreidio">[]</button></td>
</tr>
</table>
</div>
</div>
    <div class="fondo"></div>
<div id="idioma"  style="margin-top:-20px;margin-left:5px; ">
<table id="listidioma"  style="font-size:14px;border-spacing: 0px;">
<tr>
<th style="background-color:#E7F3FB;">IDIOMA</th><th style="background-color:#E7F3FB;">NIVEL IDIOMA</th>
</tr>
</table>
</div>
<div id="movimiento">
    <div style="margin-top:2px;">
<table>
<tr>
<td style="width:416px;">MOVIMIENTO INTERNO</td>
</tr>
</table>
        </div>
</div>
    <div class="fondo"></div>
<div id="movi"  style="margin-top:-20px;margin-left:5px; ">
<table id="listmovi"  style="font-size:14px;border-spacing: 0px;">
<tr>
<th style="background-color:#E7F3FB;">AREA PREFERENCIA</th><th style="background-color:#E7F3FB;">MOTIVACI&Oacute;N (Justificar)</th>
</tr>
<tr>
<td><input id="areapref1" name="areapref1" type="text" size="25" style="background-color: #F7FAFC;"/></td>
<td><input id="areapref2" name="areapref2" type="text" size="100" style="background-color: #F7FAFC;"/></td>
</tr>
</table>
</div>

<div id="premios">
    <div style="margin-top:2px;">
<table>
<tr>
<td style="width:930px;">PREMIOS/RECONOCIMIENTOS</td>
<td style="width:30px;"><button id="agregapremio">+</button></td>
<td style="width:30px;"><button id="abreprem">[]</button></td>
</tr>
</table>
        </div>
</div>
    <div class="fondo"></div>
<div id="premi"  style="margin-top:-20px;margin-left:5px; ">
<table id="listprem"  style="font-size:14px;border-spacing: 0px;">
<tr>
<th style="background-color:#E7F3FB;">NOMBRE PREMIO</th><th style="background-color:#E7F3FB;">INSTITUCI&Oacute;N</th><th style="background-color:#E7F3FB;">AÑO</th>
</tr>
</table>
</div>
<div id="membresia">
    <div style="margin-top:2px;">
<table>
<tr>
<td style="width:930px;">MEMBRES&Iacute;AS</td>
<td style="width:30px;"><button id="agregamemb">+</button></td>
<td style="width:30px;"><button id="abrememb">[]</button></td>
</tr>
</table>
</div>
</div>
<div class="fondo"></div>
<div id="membre"  style="margin-top:-20px;margin-left:5px; ">
<table id="listmemb"  style="font-size:14px;border-spacing: 0px">
<tr>
<th style="background-color:#E7F3FB;">NOMBRE MEMBRES&Iacute;A</th><th style="background-color:#E7F3FB;">NOMBRE INSTITUCI&Oacute;N</th><th style="background-color:#E7F3FB;">AÑO INICIO</th><th style="background-color:#E7F3FB;">AÑO T&Eacute;RMINO (si aplica)</th>
</tr>
</table>
</div>
<div style="clear:both"></div>
<div id="fin"  style="margin-top:15px;margin-left:2px; ">
</div>

</div>
</div>

<div id="dialogoayuda" title="Ayuda"></div>
<div id="cv_id"></div>
<div id="cv_ad"></div>

<script>
      if ($.cookie("IdMaestroUsuario") == null) { alert("Acceso No Autorizado"); window.location.href = "edd.aspx"; }
    $(document).ready(function () {
        crear_entrada();
        esconde_entrada();
        carga_perfil();
        muestra_perfil();
    });

</script>
</div>
</body>
</html>
