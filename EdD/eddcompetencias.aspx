<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eddcompetencias.aspx.cs" Inherits="EdD.eddcompetencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Competencias</title>
    <link href="../estilos/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="../estilos/estilos.css" type="text/css" rel="stylesheet" />
    <link href="../estilos/competencia.css" type="text/css" rel="stylesheet" />    
    <script src="../js/jquery-1.11.12.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.cookie.js"></script>
    <script src="../js/funciones.js"></script>
        <script src="../js/competencia.js"></script>
</head>
<body>
<div style="margin-left:100px;">
<!--<div id="cajasuperior" class="cajasuperior">
       <div>
            <img src="/imagenes/circle_cariola.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 680px;" />
            <img src="/imagenes/circle_sargent.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
            <img src="/imagenes/circle_weekmark.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
       </div>    
</div>
-->
<div style="clear:both"></div>
<div style="margin-top: 20px; width:1400px;">
     <div style="float: left; width: 50px; margin-left: 666px;"><button id="instrcomp" onclick="instrcomp()" class="btn" >Instrucciones</button></div>
     <div style="float: left; width: 50px; margin-left: 50px;"><button id="guardarcomp" onclick="actualiza_comp()" class="btn" style="width: 63px; ">Guardar</button></div>
    <div style="float: left; width: 50px; margin-left: 22px;"><button id="enviarajefaturacomp" onclick="enviar_jefaturacomp()" class="btn" style="width: 100px; ">A Jefatura</button></div>
     <div style="float: left; width: 50px; margin-left: 60px;"><button id="volver" onclick="volver()" class="btn" style="width: 63px; ">Inicio</button></div>        
</div>
<div style="clear:both"></div>
<div class="encabezado1">EVALUACION PRINCIPIO DE AÑO</div>
<div style="clear:both"></div>

<div id="compinicio">
<div id="tablaini1">
    <div class="tit1">Competencia</div>
    <div class="tit2">Evaluación Consensuada</div>
    <div class="tit3">Plan de Acción</div>
    <div class="tit3">Comentarios Evaluado</div>
    <div class="tit3">Comentarios Jefatura</div>
</div>
<div style="clear:both"></div>
<div id="fila1" style="float:left;margin-top:20px;">
<div id="col11" class="cel1"></div>
<div id="col12" class="cel2">
<select id="evaljefe12" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col13" class="cel3"><textarea id="evaljefe13" rows="4" cols="35" ></textarea></div>
<div id="col14" class="cel4"><textarea id="evaljefe14" rows="4" cols="35"></textarea></div>
<div id="col15" class="cel5"><textarea id="evaljefe15" rows="4" cols="35"></textarea></div>
</div>
<div id="fila2" style="float:left;margin-top:10px;">
<div id="col21" class="cel1"></div>
<div id="col22" class="cel2">
<select id="evaljefe22" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col23" class="cel3"><textarea id="evaljefe23" rows="4" cols="35"></textarea></div>
<div id="col24" class="cel4"><textarea id="evaljefe24" rows="4" cols="35"></textarea></div>
<div id="col25" class="cel5"><textarea id="evaljefe25" rows="4" cols="35"></textarea></div>
</div>
<div id="fila3" style="float:left;margin-top:10px;">
<div id="col31" class="cel1"></div>
<div id="col32" class="cel2">
<select id="evaljefe32" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col33" class="cel3"><textarea id="evaljefe33" rows="4" cols="35"></textarea></div>
<div id="col34" class="cel4"><textarea id="evaljefe34" rows="4" cols="35"></textarea></div>
<div id="col35" class="cel5"><textarea id="evaljefe35" rows="4" cols="35"></textarea></div>
</div>
<div id="fila4" style="float:left;margin-top:10px;">
<div id="col41" class="cel1"></div>
<div id="col42" class="cel2">
<select id="evaljefe42" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col43" class="cel3"><textarea id="evaljefe43" rows="4" cols="35"></textarea></div>
<div id="col44" class="cel4"><textarea id="evaljefe44" rows="4" cols="35"></textarea></div>
<div id="col45" class="cel5"><textarea id="evaljefe45" rows="4" cols="35"></textarea></div>
</div>
<div id="fila5" style="float:left;margin-top:10px;">
<div id="col51" class="cel1"></div>
<div id="col52" class="cel2">
<select id="evaljefe52" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col53" class="cel3"><textarea id="evaljefe53" rows="4" cols="35"></textarea></div>
<div id="col54" class="cel4"><textarea id="evaljefe54" rows="4" cols="35"></textarea></div>
<div id="col55" class="cel5"><textarea id="evaljefe55" rows="4" cols="35"></textarea></div>>
</div>
<div id="fila6" style="float:left;margin-top:10px;">
<div id="col61" class="cel1"></div>
<div id="col62" class="cel2">
<select id="evaljefe62" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col63" class="cel3"><textarea id="evaljefe63" rows="4" cols="35"></textarea></div>
<div id="col64" class="cel4"><textarea id="evaljefe64" rows="4" cols="35"></textarea></div>
<div id="col65" class="cel5"><textarea id="evaljefe65" rows="4" cols="35"></textarea></div>
</div>
<div id="fila7" style="float:left;margin-top:10px;">
<div id="col71" class="cel1"></div>
<div id="col72" class="cel2">
<select id="evaljefe72" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col73" class="cel3"><textarea id="evaljefe73" rows="4" cols="35"></textarea></div>
<div id="col74" class="cel4"><textarea id="evaljefe74" rows="4" cols="35"></textarea></div>
<div id="col75" class="cel5"><textarea id="evaljefe75" rows="4" cols="35"></textarea></div>
</div>
</div>

<div style="clear:both"></div>
<div id="encabezadofinal" class="encabezado1">EVALUACION FINAL DE AÑO</div>
<div style="clear:both"></div>

<div id="compfinal">
<div id="tablafin1">
    <div class="tit1">Competencia</div>
    <div class="tit2">Evaluación Consensuada</div>
    <div class="tit3">Plan de Acción</div>
    <div class="tit3">Comentarios Evaluado</div>
    <div class="tit3">Comentarios Jefatura</div>
</div>
<div style="clear:both"></div>
<div id="fila1f" style="float:left;margin-top:20px;">
<div id="col11f" class="cel1"></div>
<div id="col12f" class="cel2">
<select id="evaljefe12f" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col13f" class="cel3"><textarea id="evaljefe13f" rows="4" cols="35" ></textarea></div>
<div id="col14f" class="cel4"><textarea id="evaljefe14f" rows="4" cols="35"></textarea></div>
<div id="col15f" class="cel5"><textarea id="evaljefe15f" rows="4" cols="35"></textarea></div>
</div>
<div id="fila2f" style="float:left;margin-top:10px;">
<div id="col21f" class="cel1"></div>
<div id="col22f" class="cel2">
<select id="evaljefe22f" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col23f" class="cel3"><textarea id="evaljefe23f" rows="4" cols="35"></textarea></div>
<div id="col24f" class="cel4"><textarea id="evaljefe24f" rows="4" cols="35"></textarea></div>
<div id="col25f" class="cel5"><textarea id="evaljefe25f" rows="4" cols="35"></textarea></div>
</div>
<div id="fila3f" style="float:left;margin-top:10px;">
<div id="col31f" class="cel1"></div>
<div id="col32f" class="cel2">
<select id="evaljefe32f" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col33f" class="cel3"><textarea id="evaljefe33f" rows="4" cols="35"></textarea></div>
<div id="col34f" class="cel4"><textarea id="evaljefe34f" rows="4" cols="35"></textarea></div>
<div id="col35f" class="cel5"><textarea id="evaljefe35f" rows="4" cols="35"></textarea></div>
</div>
<div id="fila4f" style="float:left;margin-top:10px;">
<div id="col41f" class="cel1"></div>
<div id="col42f" class="cel2">
<select id="evaljefe42f" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col43f" class="cel3"><textarea id="evaljefe43f" rows="4" cols="35"></textarea></div>
<div id="col44f" class="cel4"><textarea id="evaljefe44f" rows="4" cols="35"></textarea></div>
<div id="col45f" class="cel5"><textarea id="evaljefe45f" rows="4" cols="35"></textarea></div>
</div>
<div id="fila5f" style="float:left;margin-top:10px;">
<div id="col51f" class="cel1"></div>
<div id="col52f" class="cel2">
<select id="evaljefe52f" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col53f" class="cel3"><textarea id="evaljefe53f" rows="4" cols="35"></textarea></div>
<div id="col54f" class="cel4"><textarea id="evaljefe54f" rows="4" cols="35"></textarea></div>
<div id="col55f" class="cel5"><textarea id="evaljefe55f" rows="4" cols="35"></textarea></div>>
</div>
<div id="fila6f" style="float:left;margin-top:10px;">
<div id="col61f" class="cel1"></div>
<div id="col62f" class="cel2">
<select id="evaljefe62f" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col63f" class="cel3"><textarea id="evaljefe63f" rows="4" cols="35"></textarea></div>
<div id="col64f" class="cel4"><textarea id="evaljefe64f" rows="4" cols="35"></textarea></div>
<div id="col65f" class="cel5"><textarea id="evaljefe65f" rows="4" cols="35"></textarea></div>
</div>
<div id="fila7f" style="float:left;margin-top:10px;">
<div id="col71f" class="cel1"></div>
<div id="col72f" class="cel2">
<select id="evaljefe72f" style="height:66px;width:304px;">
<option value="1" selected="selected">No calificado</option>
<option value="2">Pobre, no cumple el estándar</option>
<option value="3">Suficiente, cumple unos pocos estándares</option>
<option value="4">Bien, cumple algunos estándares</option>
<option value="5">Muy bien, cumple la mayoría de los estándares</option>
<option value="6">Excelente, cumple todos los estándares</option>
</select>
</div>
<div id="col73f" class="cel3"><textarea id="evaljefe73f" rows="4" cols="35"></textarea></div>
<div id="col74f" class="cel4"><textarea id="evaljefe74f" rows="4" cols="35"></textarea></div>
<div id="col75f" class="cel5"><textarea id="evaljefe75f" rows="4" cols="35"></textarea></div>
</div>

</div>
</div>
<div id="dialogoinstrcomp" title="Instrucciones Competencias"></div>
<div id="guardacomp" title="Guardar"></div>
<div id="dialogovalidacomp" title="Valida Competencias"></div>
<div id="dialogocompajefatura" title="Envia a Jefatura"></div>
<script>
    limpia_campos();
    lee_eval_comp();
    lee_cargo_comp();
    lee_competencias();
    lee_estado_comp();
    control_tablas_comp();
</script>
</body>
</html>
