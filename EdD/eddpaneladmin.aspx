<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eddpaneladmin.aspx.cs" Inherits="EdD.eddpaneladmin" %>

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
   <div style="clear:both;"></div>
    <form id="form1" runat="server" class="auto-style4">
          <div class="auto-style2">
              <asp:Button ID="Button4" runat="server" Text="Evaluacion" Width="107px" OnClick="Button1_Click"  CssClass="btn" />
              <asp:Button ID="Button5" runat="server" Text="Limpia" Width="107px" OnClick="Button2_Click"  CssClass="btn" />
              <asp:Button ID="Button9" runat="server" Text="Salir" Width="107px" OnClick="Button9_Click"  CssClass="btn" />
          </div>
  </form>


<div id="dialogoayuda" title="Ayuda" class="auto-style6"></div>

<script>
    //$("#resumen").hide();
if ($.cookie("IdMaestroUsuario") == null) { alert("Acceso No Autorizado"); window.location.href = "edd.aspx"; }

</script>
</div>
</body>
</html>
