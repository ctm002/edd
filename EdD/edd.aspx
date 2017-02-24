<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edd.aspx.cs" Inherits="EdD.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio</title>
    <link href="../estilos/estilos.css" type="text/css" rel="stylesheet" />
</head>
<body style="width: 1097px;background-image:url(/imagenes/content.jpg);">
<div style="margin-left:100px;">
    <div id="cajasuperior" class="cajasuperior">
        <div>
            <img src="/imagenes/circle_cariola.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 680px;" />
            <img src="/imagenes/circle_sargent.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
            <img src="/imagenes/circle_weekmark.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
        </div>     
    </div>

    <form id="form1" runat="server">
    <div style="width: 297px; height: 129px; margin-left: 555px">
        <asp:Login ID="Login1" runat="server" Height="131px" Width="298px" OnAuthenticate="Unnamed1_Authenticate" LoginButtonText="Ingrese" PasswordLabelText="Clave:  " RememberMeText="Recordar Usuario y Clave." TitleText="" UserNameLabelText="Usuario:" style="margin-top: 0px" LoginButtonStyle-CssClass="btn" Font-Names="Arial" DisplayRememberMe="False" ForeColor="#063E74" Font-Size="Smaller"></asp:Login>
        <br />
        <asp:Label ID="mensajeconexion" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#215778" Text=""></asp:Label>
    </div>
    </form>
</div>
</body>
</html>

