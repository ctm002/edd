<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eddorganigrama.aspx.cs" Inherits="EdD.eddorganigrama" %>

<!DOCTYPE html>
<script src="/js/jquery-1.11.12.js"></script>
<script src="/js/jquery-ui.js"></script>
<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<script>google.load("visualization", "1", { packages: ["orgchart"] });</script>
<script>
    function carga_organigrama(){
        $.ajax({
            type: "POST",
            url: "Servicios/edddatosperf.asmx/getOrgData",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_getOrgData,
            error: OnErrorCall_getOrgData
        });
    }
    
    function OnSuccess_getOrgData(repo) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Name');
            data.addColumn('string', 'Manager');
            data.addColumn('string', 'ToolTip');
            var response = repo.d;
            for (var i = 0; i < response.length; i++) {
                var row = new Array();
                var empName = response[i].Employee;
                var mgrName = response[i].Manager;
                var empID = response[i].empID;
                var mgrID = response[i].mgrID;
                var designation = response[i].designation;

                data.addRows([[{
                    v: empID,
                    f: empName
                }, mgrID, designation]]);
            }

            var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
            chart.draw(data, { allowHtml: true });
        }

        function OnErrorCall_getOrgData() {
            console.log("Whoops something went wrong :( ");
        }

        function volver_panel() {
            window.location.href = "eddpanel.aspx";
        }

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
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
    <link href="/estilos/estilos.css" type="text/css" rel="stylesheet" />
    <link href="/estilos/panel.css" type="text/css" rel="stylesheet" />
<head runat="server">
    <title></title>
</head>
<body onload="carga_organigrama()" style="width: 952px;">
     <div id="cajasuperior" class="cajasuperior">
       <div>
            <img src="/imagenes/circle_cariola.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 680px;" />
            <img src="/imagenes/circle_sargent.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
            <img src="/imagenes/circle_weekmark.png" style="float:left; height: 100px; width: 100px; margin-right: 0px; margin-top: 12px; margin-left: 10px;" />
       </div>     
    </div>
    <div style="margin-top: 10px; " class="auto-style10">
            <div class="auto-style7"><button id="ayuda" onclick="volver_panel()" class="auto-style8" >Inicio</button></div>        
    </div>
    <form id="form1" runat="server">
        <div id="chart_div" style="margin-top:150px;"></div>
    </form>

</body>
</html>
