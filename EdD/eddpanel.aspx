<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eddpanel.aspx.cs" Inherits="EdD.WebForm2" %>

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
    <script src="/js/obj.js"></script>
    <script src="/js/panel.js"></script>
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
            <div class="auto-style7"><button id="ayuda" onclick="ayuda()" class="auto-style8" >Ayuda</button></div>        
    </div>
   <div style="clear:both;"></div>
    <form id="form1" runat="server" class="auto-style4">
          <div class="auto-style2">
              <asp:Button ID="Button3" runat="server" Text="Inicio" Width="107px"  CssClass="btn" />
              <asp:Button ID="Button4" runat="server" Text="Mi Perfil" Width="107px" OnClick="Button4_Click"  CssClass="btn" />
              <asp:Button ID="Button5" runat="server" Text="Objetivos" Width="107px" OnClick="Button5_Click"  CssClass="btn" />
              <asp:Button ID="Button6" runat="server" Text="Competencias" Width="107px" OnClick="Button6_Click"  CssClass="btn" />
              <asp:Button ID="Button7" runat="server" Text="Evaluación" Width="107px"  OnClick="Imprimir_Evaluacion" CssClass="btn" />
              <asp:Button ID="Button10" runat="server" Text="Organigrama" Width="107px"  OnClick="Organigrama" CssClass="btn" />
              <asp:Button ID="Button11" runat="server" Text="Informes" Visible="false" Width="107px"  OnClick="Button11_Click" CssClass="btn" />
              <asp:Button ID="Button9" runat="server" Text="Salir" Width="107px" OnClick="Button9_Click"  CssClass="btn" />
          </div>
<!--          <div id="resumen" style="margin-bottom: 200px;" class="auto-style3">
              <asp:Label ID="NombreEmpleado" runat="server" Text="Nombre del Empleado" Font-Names="Verdana" Font-Size="Medium" ForeColor="#215778"></asp:Label>
              <br />
              <asp:Label ID="EstadoEvaluacion" runat="server" Text="El Estado de su Evaluación" Font-Names="Verdana" Font-Size="Small" ForeColor="#215778"></asp:Label>
              <br />
              <br />
              <asp:Label ID="titEstadoEvaluaciones" runat="server" Font-Names="Verdana" Font-Size="Medium" Text="Estado de la Evaluación de los Colaboradores" Font-Strikeout="False" Font-Underline="False" ForeColor="#215778"></asp:Label>
              <asp:Table ID="TablaColaboradores" runat="server" Width="100%" Font-Size="Small" ForeColor="#215778"> 
              </asp:Table>
-->
  </form>

<div id="panelcentral">
<div id="panelizq">
    <div id="pendiente"><div style="text-align:center;">ETAPAS DEL PROCESO</div>
    <div id="detpendiente"></div>
</div>
<div id="realizado"><div style="text-align:center;">ETAPAS REALIZADAS</div>
    <div id="detrealizado"></div>
</div>
<div id="revisar"><div style="text-align:center;">ESTADO DE ACTIVIDADES</div>
    <div id="detrevisar"></div>
</div>
</div>
<div id="panelder"><div style="text-align:center;">MENSAJE DE BIENVENIDA</div>
        <div id="detbienvenida"></div>
</div>
</div>


<div id="dialogoayuda" title="Ayuda" class="auto-style6"></div>
<div id="dialogobienvenida" title="Bienvenida" class="auto-style6"></div>
<script>
    //$("#resumen").hide();
if ($.cookie("IdMaestroUsuario") == null) { alert("Acceso No Autorizado"); window.location.href = "edd.aspx"; }

mostrar_bienvenida();
lee_estado_obj();
lee_estado_comp();
detalle_revisar();
detalle_pendiente();
detalle_realizado();
detalle_bienvenida();

</script>
</div>
</body>
</html>