function mostrar_informe(){
    usuario = $.cookie("IdMaestroUsuario");
    $("#graficogerente").css('visibility', 'hidden');
    $("#graficosubgerente").css('visibility', 'hidden');
    if(usuario==100){
        $("#informegerente").css('visibility', 'visible');
        $("#informesubgerente").css('visibility', 'hidden');
    }
    if(usuario==101){
        $("#informegerente").css('visibility', 'hidden');
        $("#informesubgerente").css('visibility', 'visible');
    }
}

function mostrar_grafico() {
    usuario = $.cookie("IdMaestroUsuario");
    $("#informegerente").css('visibility', 'hidden');
    $("#informesubgerente").css('visibility', 'hidden');
    if (usuario == 100) {
        $("#graficogerente").css('visibility', 'visible');
        $("#graficosubgerente").css('visibility', 'hidden');
    }
    if (usuario == 101) {
        $("#graficogerente").css('visibility', 'hidden');
        $("#graficosubgerente").css('visibility', 'visible');
    }
}