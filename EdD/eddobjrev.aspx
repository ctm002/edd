<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eddobjrev.aspx.cs" Inherits="EdD.eddobjrev" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../estilos/jquery-ui.css" type="text/css" rel="stylesheet" />
<link href="../estilos/estilos.css" type="text/css" rel="stylesheet" />
<link href="../estilos/obj.css" type="text/css" rel="stylesheet" />
<script src="../js/jquery-1.11.12.js"></script>
<script src="../js/jquery-ui.js"></script>
<script src="../js/jquery.cookie.js"></script>
<script src="../js/funciones.js"></script>
<script src="../js/objrev.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>OBJETIVOS</title>
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
     <div style="float: left; width: 50px; margin-left: 10px;"><button id="obj1" class="btn" onclick="lee_obj(1)">Obj.1</button></div>
     <div style="float: left; width: 50px; margin-left: 10px;"><button id="obj2" class="btn" onclick="lee_obj(2)">Obj.2</button></div>
     <div style="float: left; width: 50px; margin-left: 10px;"><button id="obj3" class="btn" onclick="lee_obj(3)">Obj.3</button></div>
     <div style="float: left; width: 50px; margin-left: 10px;"><button id="obj4" class="btn" onclick="lee_obj(4)">Obj.4</button></div>
     <div style="float: left; width: 50px; margin-left: 10px;"><button id="obj5" class="btn" onclick="lee_obj(5)">Obj.5</button></div>
     <div style="float: left; width: 50px; margin-left: 10px;"><button id="obj6" class="btn" onclick="lee_obj(6)">Obj.6</button></div>
     <div style="float: left; width: 50px; margin-left: 10px;"><button id="obj7" class="btn" onclick="lee_obj(7)">Obj.7</button></div>
     <div style="float: left; width: 50px; margin-left: 134px;"><button id="instrobj" onclick="instrobj()" class="btn" >Instrucciones</button></div>
     <div style="float: left; width: 50px; margin-left: 50px;"><button id="limpiarobjetivo" onclick="limpiar_obj()" class="btn" style="width: 63px;">Cancelar</button></div>
     <div style="float: left; width: 50px; margin-left: 22px;"><button id="guardarobjetivo" onclick="guarda_obj()" class="btn" style="width: 63px; ">Guardar</button></div>
     <div style="float: left; width: 50px; margin-left: 22px;"><button id="aceptarjefe" onclick="actualiza_jefe(1)" class="btn" style="width: 63px; ">Aceptar</button></div>
     <div style="float: left; width: 50px; margin-left: 22px;"><button id="rechazarjefe" onclick="actualiza_jefe(0)" class="btn" style="width: 63px; ">Rechazar</button></div>
     <div style="float: left; width: 50px; margin-left: 22px;"><button id="volver" onclick="volver()" class="btn" style="width: 63px; ">Inicio</button></div>        
</div>
<div style="clear:both"></div>
<div id="contenedor" style="width:4000px; visibility:hidden;">
<div id="tabla1a3">
<div id="encabezado1">Etapa Establecimiento de Objetivos</div>
<div style="float:left;font-size:12px;margin-top:6px;">Los campos con </div><div style="float:left;font-size:12px;color:red;width:10px;text-align:center;margin-top:6px;"> * </div><div style="float:left;font-size:12px;margin-top:6px;"> son obligatorios</div>
<div style="clear:both"></div>
<div id="tabla1">
<div id="cajat11">
<div id="cajat111">Categor&iacute;a</div>
<div id="cajat112"><select id="categoria" name="categoria" style="margin-left:10px;" >
  <option value="Funcional">Funcional</option>
  <option value="Personas">Personas</option>
  <option value="Salud y Seguridad">Salud y Seguridad</option>
  <option value="Operacional">Operacional</option>
  <option value="Costos">Costos</option>
  <option value="Mejora">Mejora Continua</option>
  <option value="Produccion">Produccion</option>
  <option value="Investigacion">Investigacion</option>
  <option value="Desarrollo">Desarrollo</option>
  <option value="Comunicacion">Comunicacion</option>
  <option value="Equipo">Equipo</option>
  <option value="Redaccion">Redaccion</option>
  <option value="Tiempo">Tiempo</option>
  <option value="Sistemas">Sistemas</option>
  <option value="Dominio Tecnologico">Dominio Tecnologico</option>
  <option value="Proceso">Procesos</option>
  <option value="Otro">Otro</option>
</select></div>
</div>
<div style="clear:both"></div>
<div id="cajat12">
<div id="cajat121"><div style="color:red;">(*)</div> Objetivo de Desempeño:</div>
<div id="cajat122"><textarea id="objetivo" name="objetivo" cols="46" rows="19"></textarea></div>
</div>
<div style="clear:both"></div>
<div id="cajat13">
<div id="cajat131"><div style="color:red;float:left;">(*)</div>Qué se ha logrado:</div>
<div id="cajat132"><textarea id="logros" name="logros" cols="46" rows="21"></textarea></div>
</div>
</div>

<div id="tabla2">
<div id="encabezado2"></div>
<div id="cajat21">
</div>
<div style="clear:both"></div>
<div id="cajat22">
<div id="cajat221"><div style="color:red;float:left;">(*)</div>Medici&oacute;n:</div>
<div id="cajat222"><textarea id="medicion" name="medicion" cols="46" rows="19" ></textarea></div>
</div>
<div style="clear:both"></div>
<div id="cajat23">
<div id="cajat231">Pasos Plan de Acci&oacute;n:</div>
<div id="cajat232">
<div id="linea0">
<div style="float: left; height: 20px; color:white;">Descripci&oacute;n</div>
<div style="float: left; height: 20px; margin-left: 146px; color:white;">Comienzo</div>
<div style="float: left; height: 20px; margin-left: 32px; color:white;">T&eacute;rmino</div>
<div><button id="agregapaso" onclick="agregapaso()" >+</button></div>
<div style="clear:both"></div>
</div>
<div id="linea1" class="linea">
<div style="float:left;"><textarea id="pasos1" name="pasos1" cols="24" rows="2" ></textarea></div>
<div style="float:left;"><input id="fechapa1" type="text" size="8"/></div>
<div style="float:left;"><input id="fechapa11" type="text" size="8"/></div>
</div>
<div style="clear:both"></div>
<div id="linea2" class="linea">
<div style="float:left;"><textarea id="pasos2" name="pasos2" cols="24" rows="2" ></textarea></div>
<div style="float:left;"><input id="fechapa2" type="text" size="8"/></div>
<div style="float:left;"><input id="fechapa12" type="text" size="8"/></div>
</div>
<div style="clear:both"></div>
<div id="linea3" class="linea">
<div style="float:left;"><textarea id="pasos3" name="pasos3" cols="24" rows="2" ></textarea></div>
<div style="float:left;"><input id="fechapa3" type="text" size="8"/></div>
<div style="float:left;"><input id="fechapa13" type="text" size="8"/></div>
</div>
<div style="clear:both"></div>
<div id="linea4" class="linea">
<div style="float:left;"><textarea id="pasos4" name="pasos4" cols="24" rows="2" ></textarea></div>
<div style="float:left;"><input id="fechapa4" type="text" size="8"/></div>
<div style="float:left;"><input id="fechapa14" type="text" size="8"/></div>
</div>
<div style="clear:both"></div>
<div id="linea5" class="linea">
<div style="float:left;"><textarea id="pasos5" name="pasos5" cols="24" rows="2" ></textarea></div>
<div style="float:left;"><input id="fechapa5" type="text" size="8"/></div>
<div style="float:left;"><input id="fechapa15" type="text" size="8"/></div>
</div>
<div style="clear:both"></div>
<div id="linea6" class="linea">
<div style="float:left;"><textarea id="pasos6" name="pasos6" cols="24" rows="2" ></textarea></div>
<div style="float:left;"><input id="fechapa6" type="text" size="8"/></div>
<div style="float:left;"><input id="fechapa16" type="text" size="8"/></div>
</div>
<div style="clear:both"></div>
<div id="linea7" class="linea">
<div style="float:left;"><textarea id="pasos7" name="pasos7" cols="24" rows="2" ></textarea></div>
<div style="float:left;"><input id="fechapa7" type="text" size="8"/></div>
<div style="float:left;"><input id="fechapa17" type="text" size="8"/></div>
</div>
<div style="clear:both"></div>
</div>
</div>
</div>

<div id="tabla3">
<div id="encabezado3"></div>
<div id="cajat31">
</div>
<div style="clear:both"></div>

<div id="cajat32a">
<div id="cajat32at1"><div style="color:red;float:left;">(*)</div><div style="float:left;">Estado</div></div>
<div id="cajat32at2"><div style="color:red;float:left;">(*)</div><div style="float:left;">Fec.Comienzo</div></div>
<div id="cajat32at3"><div style="color:red;float:left;">(*)</div><div style="float:left;">Fec.T&eacute;rmino</div></div>
<div id="cajat32at4">% Avance</div>
<div style="clear:both"></div>
<div id="cajat32at1b"><select id="categoria3" name="categoria3" style="width: 120px">
  <option value="Cancelado">Cancelado</option>
  <option value="No iniciado">No iniciado</option>
  <option value="Retrasado">Retrasado</option>
  <option value="Segun planificacion">Segun planificacion</option>
  <option value="Completado">Completado</option>
</select></div>
<div id="cajat32at2b"><input id="fecha31" type="text" size="10"/></div>
<div id="cajat32at3b"><input id="fecha32" type="text" size="10"/></div>
<div id="cajat32at4b"><input id="terminado3" type="text" size="3" />%</div>
</div>
<div style="clear:both"></div>
<div id="cajat32">
<div id="cajat321"><div style="color:red;">(*)</div>Comentarios Empleado:</div>
<div id="cajat322"><textarea id="pasos31" name="pasos31" cols="46" rows="14" ></textarea></div>
</div>
<div style="clear:both"></div>
<div id="cajat33">
<div id="cajat331"><div style="color:red;">(*)</div>Comentarios Jefatura:</div>
<div id="cajat332"><textarea id="pasos32" name="pasos32" cols="46" rows="21" ></textarea></div>
</div>
</div>
</div>

<div id="tabla4a4">
<div id="encabezado4">Etapa Evaluaci&oacute;n/Conversación Mitad de A&ntilde;o</div>

<div id="cajat41">
</div>
<div style="clear:both"></div>

<div id="cajat42a">
<div id="cajat42at1"><div style="color:red;float:left;">(*)</div><div style="float:left;">Estado</div></div>
<div id="cajat42at2"><div style="color:red;float:left;">(*)</div><div style="float:left;">Fec. Comienzo</div></div>
<div id="cajat42at3"><div style="color:red;float:left;">(*)</div><div style="float:left;">Fec. T&eacute;rmino</div></div>
<div id="cajat42at4">% Avance</div>
<div style="clear:both"></div>
<div id="cajat42at1b"><select id="categoria4" name="categoria4" >
  <option value="Cancelado">Cancelado</option>
  <option value="No iniciado">No iniciado</option>
  <option value="Retrasado">Retrasado</option>
  <option value="Segun planificacion">Segun planificacion</option>
  <option value="Completado">Completado</option>
</select></div>
<div id="cajat42at2b"><input id="fecha41" type="text" size="10"/></div>
<div id="cajat42at3b"><input id="fecha42" type="text" size="10"/></div>
<div id="cajat42at4b"><input id="terminado4" type="text" size="3" />%</div>
</div>
<div style="clear:both"></div>
<div id="cajat42">
<div id="cajat421"><div style="color:red;">(*)</div>Comentarios Empleado (Sólo en caso de modificación de objetivo por cancelación o razones de fuerza mayor):</div>
<div id="cajat422"><textarea id="pasos41" name="pasos41" cols="46" rows="14" ></textarea></div>
</div>
<div style="clear:both"></div>
<div id="cajat43">
<div id="cajat431"><div style="color:red;">(*)</div>Comentarios Jefatura (En caso de que haya alguna modificación, debe estar el Visto Bueno del Jefe):</div>
<div id="cajat432"><textarea id="pasos42" name="pasos42" cols="46" rows="21" ></textarea></div>
</div>

</div>

<div id="tabla5a5">
<div id="encabezado5">Etapa Evaluaci&oacute;n de Final de A&ntilde;o</div>

<div id="cajat51"></div>

<div style="clear:both"></div>

<div id="cajat52a">
<div id="cajat52at1"><div style="color:red;float:left;">(*)</div><div style="float:left;">Estado</div></div>
<div id="cajat52at2"><div style="color:red;float:left;">(*)</div><div style="float:left;">Fec. Comienzo</div></div>
<div id="cajat52at3"><div style="color:red;float:left;">(*)</div><div style="float:left;">Fec. T&eacute;rmino</div></div>
<div id="cajat52at4"><div style="color:red;float:left;">(*)</div><div style="float:left;">% Avance</div></div>
<div id="cajat52at5"><div style="color:red;float:left;">(*)</div><div style="float:left;">Calificaci&oacute;n</div></div>
<div style="clear:both"></div>
<div id="cajat52at1b"><select id="categoria5" name="categoria5" >
  <option value="Cancelado">Cancelado</option>
  <option value="No iniciado">No iniciado</option>
  <option value="Retrasado">Retrasado</option>
  <option value="Segun planificacion">Segun planificacion</option>
  <option value="Completado">Completado</option>
</select></div>
<div id="cajat52at2b"><input id="fecha51" type="text" size="10"/></div>
<div id="cajat52at3b"><input id="fecha52" type="text" size="10"/></div>
<div id="cajat52at4b"><input id="terminado5" type="text" size="3" />%</div>
<div id="cajat52at5b"><select id="notafinal5" name="notafinal5" >
  <option value="No calificado">No calificado</option>
  <option value="No cumplio con el objetivo">No cumplio con el objetivo</option>
  <option value="Objetivo parcialmente cumplido">Objetivo parcialmente cumplido</option>
  <option value="Objetivo logrado">Objetivo logrado</option>
  <option value="Objetivo excedido">Objetivo excedido</option>
  <option value="Objetivo claramente excedido">Objetivo claramente excedido</option>
</select>
</div>
<div style="clear:both"></div>
<div id="cajat52">
<div id="cajat521"><div style="color:red;">(*)</div>Comentarios empleado:</div>
<div id="cajat522"><textarea id="pasos51" name="pasos51" cols="62" rows="13" ></textarea></div>
</div>
<div style="clear:both"></div>
<div id="cajat52b">
<div id="cajat52b1"><div style="color:red;float:left;">(*)</div><div style="float:left;">Calificación Jefatura</div></div>
<div style="clear:both"></div>
<div id="cajat52b2"><select id="notafinaljefatura5" name="notafinaljefatura5" >
  <option value="No calificado">No calificado</option>
  <option value="No cumplio con el objetivo">No cumplio con el objetivo</option>
  <option value="Objetivo parcialmente cumplido">Objetivo parcialmente cumplido</option>
  <option value="Objetivo logrado">Objetivo logrado</option>
  <option value="Objetivo excedido">Objetivo excedido</option>
  <option value="Objetivo claramente excedido">Objetivo claramente excedido</option>
</select>
</div>
</div>

<div style="clear:both"></div>
<div id="cajat53">
<div id="cajat531"><div style="color:red;">(*)</div>Comentarios Jefatura:</div>
<div id="cajat532"><textarea id="pasos52" name="pasos52" cols="62" rows="16" ></textarea></div>
</div>
</div>
</div>
<div id="instrucciones0" style="font-size:14px;padding:6px;width:994px; visibility:hidden;">
<div style="clear:both"></div>
<div id="encabezado11">Informaci&oacute;n</div>
<div style="clear:both"></div>
<div style="width:994px;font-size:11px;margin-left:6px;">
El propósito del establecimiento de objetivos es hacer participar a los empleados y jefaturas de conversaciones 
relevantes entorno al establecimiento de objetivos de desempeño que conduzcan a resultados comerciales y de 
desarrollo que permitan el crecimiento de los empleados y la empresa. En caso de requerir ayuda, por favor contactar 
a Carolina Arriagada y/o Michela Ballotta de Recursos Humanos.
</div>
<div style="clear:both"></div>
<div id="encabezado111">Objetivos de Desempeño</div>
<div style="width:994px;font-size:11px;margin-left:6px;">
Los objetivos de desempeño alinean las contribuciones del empleado con las prioridades y resultados del negocio.
Los objetivos pueden ser una combinación de proyectos y responsabilidades primarias de un trabajo. Es recomendable
que los empleados establezcan entre 5 y 7 objetivos. 
</div>
<div style="clear:both"></div>
</div>

<div id="instrucciones" style="font-size:14px;padding:6px;line-height: 130%;margin-top:30px;margin-left:90px;width:820px; height:450px; border: 1px solid #063E74; border-collapse: collapse; border-radius: 4px 4px 4px 4px; visibility:hidden;">
<p>INGRESO DE OBJETIVOS	</p>
<ol style="text-align: justify;">
<li>El primer paso consta en que la Jefatura y el Empleado discutan y acuerden los objetivos del año.</li>
<li>Una vez acordados los objetivos, el empleado debe ingresarlos en el sistema.</li>
<li>Ingresar con su usuario y contraseña al portal de evaluación de desempeño.</li>
<li>Su página de inicio le mostrará a su izquierda una lista de botones, y deberá de hacer click en "Objetivos" para poder acceder al formulario de ingreso de objetivos.</li>
<li>Una vez que haya ingresado a "Objetivos", aparecerán los botones Obj.1, Obj.2, Obj.3, Obj.4, Obj.5, Obj.6, y Obj.7. Estos botones representan la cantidad de objetivos con sus detalles a ingresar.</li>
<li>Hacer click en el botón "Obj.1" para ingresar el primer objetivo.</li>
<li>Elegir Categoría para clasificar el tipo de objetivo.</li>
<li>Debe ingresar el Objetivo de Desempeño, describiéndolo a cabalidad e incluyendo sus implicancias.</li>
<li>Ingresar la Medición, es decir las métricas/KPI's asociadas al cumplimiento de dicho objetivo.</li>
<li>Ingresar lo Qué se ha logrado,  campo que se llena a medida que se realiza el seguimiento periódico del objetivo.</li>
<li>Ingresar opcionalmente el Plan de Acción, considerando las actividades necesarias para cumplir dicho objetivo (como una Carta Gantt).</li>
<li>El Estado debe ser ingresado acorde al progreso actual del objetivo, y así actualizarlo de acuerdo a lo planeado.</li>
<li>Llenar Fecha de Comienzo y Término, que corresponden a los plazos durante el cual se debe lograr el objetivo.</li>
<li>Llenar el campo % Avance, correspondiente al % de objetivo completado.</li>
<li>Ingresar los comentarios que usted estime pertinentes para ser enviados a su Jefatura respecto a dicho objetivo.</li>
<li>Repetir desde el paso 6 al 15 para el resto de los objetivos.</li>
<li>Cuando termine de ingresar todos sus objetivos, el formulario deber ser enviado a su Jefatura para su revisión y aprobación.</li>
</ol>
</div>


</div>
<div id="dialogoayuda" title="Ayuda"></div>
<div id="cv_id"></div>
<div id="cv_ad"></div>
<div id="dialogoobj" title="Instrucciones Objetivos"></div>
<div id="dialogoguardar" title="Guardar"></div>
<div id="dialogovalidaobj" title="Validaciones"></div>
<script>
    if ($.cookie("IdMaestroUsuario") == null) { alert("Acceso No Autorizado"); window.location.href = "edd.aspx"; }
    $("#instrucciones").css('visibility', 'visible');
    $("#instrucciones0").css('visibility', 'visible');
    lee_eval();
    lee_estado_obj();
    control_tablas();
</script>
        </div>
</body>
</html>
