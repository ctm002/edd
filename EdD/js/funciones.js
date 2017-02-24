function volver() {
    window.location.href = "eddpanel.aspx";
}

function ayuda() {
        strhtml = '<div style="overflow-x:hidden; overflow-y:visible; font-family: Arial; font-size: 10px;"><table style="border:none ! important;width:500px;text-align:justify;" cellpadding="6">';
        strhtml+='<tr><td align="justify">';
        strhtml+='A continuación se describen las opciones del sistema de Evaluación e Desempeño de Profesionales:';
        strhtml+='</td></tr>';
        strhtml += '<tr><td align="justify">';
        strhtml+='<b>Mi Perfil</b>: Permite ingresar los antecedentes del profesional, equivalente a un Curriculum Vitae.';
        strhtml+='</td></tr>';
        strhtml += '<tr><td align="justify">';
        strhtml+='<b>Objetivos</b>: Esta opción se utiliza para que el usuario pueda definir sus objetivos de evaluación, y que serán controlados en forma anual.';
        strhtml+='</td></tr>';
        strhtml += '<tr><td align="justify">';
        strhtml+='<b>Competencias</b>: Esta opción permite definir las competencias de un profesional. Se utilizan calificaciones definidas para que el usuario se evalue.';
        strhtml+='</td></tr>';
        strhtml += '<tr><td align="justify">';
        strhtml+='<b>Evaluación</b>: Informa de la evaluación asociada al periodo.';
        strhtml+='</td></tr>';
        strhtml += '<tr><td align="justify">';
        strhtml+='<b>Historia</b>: Reporte que permite revisar las actividades que ha realizado el usuario.';
        strhtml+='</td></tr>';
        strhtml += '<tr><td align="justify">';
        strhtml+='<b>Salir</b>: Volver a la ventana de Ingreso.';
        strhtml+='</tr></td>';
        strhtml+='</table></div>';

        $("#dialogoayuda").html(strhtml);

        $("#dialogoayuda").dialog({
            position: { my: "center center"},
            resizable: false,
            height: 300,
            width: 600,
            closeOnEscape: false,
            open: function(event, ui) { $(".ui-dialog-titlebar-close").hide();},
            modal: true,
            buttons: {
                "Volver": function() { $( this ).dialog( "close" );
                }
            }
        });
}

function instrcomp() {
        strhtml = '<div style="overflow-x:hidden; overflow-y:visible; font-family: Arial; font-size: 10px;"><table cellpadding="6">';  
        strhtml += '<p><b>COMPETENCIAS</b></p>';
        strhtml += '<p>Las competencias corresponden a habilidades, comportamientos y conocimientos necesarios para poder realizar sus labores y alcanzar cabalmente los objetivos. Dichas competencias son las mismas del Descriptor de Cargo de cada empleado de la Compañía. Cada Empleado y Jefatura deberán monitorear constantemente dichas competencias para garantizar el éxito en el cumplimiento de sus objetivos de desempeño. Por último, ambas partes deberán evaluar las habilidades a comienzos y final de año.</p>';
        strhtml += '<p>1. Se deberá autoevaluar para cada una de las competencias que aparecerán en el formulario y entregar un comentario acorde a la competencia justificando su autoevaluación. A su vez, deberá incluir un plan de acción para optimizar dicha competencia.</p>';
        strhtml += '<p>2. Una vez que evalúe cada competencia, deberá enviar el formulario a su Jefatura para su revisión y aprobación mediante el botón "Enviar a Jefatura".</p>';
        strhtml += '<p>3. La Jefatura debe revisar la autoevaluación del empleado e incluir su evaluación por cada competencia en "Comentarios Jefatura". Dentro de los comentarios debe hacer referencia al estado actual de la competencia.</p>';
        strhtml += '<p style="margin-left:14px;">';
        strhtml += 'a. En caso de terminar la evaluación, deberá hacer click en el botón "Completar Evaluación".</p>';
        strhtml += '<p style="margin-left:14px;">';
        strhtml += 'b. Si requiere algún tipo de corrección por parte del Empleado antes de emitir algún comentario, deberá devolverlo haciendo click en "Devolver Evaluación", e incluir un comentario con la razón por la cuál se está devolviendo.</p>';
        strhtml += '<p>4. En el caso de que la Jefatura deba devolver el formulario al empelado, éste debe leer los comentarios de la Jefatura y si lo requiere deben juntarse nuevamente para discutir y acordar los comentarios.</p>';
        strhtml += '<p>5. El Empleado debe enviar la versión final del formulario mediante el botón "Enviar a Jefatura".</p>';
        strhtml += '<p>6. En caso de que la Jefatura apruebe lo revisado en el formulario, deberá aprobarlos mediante el botón "Aprobación Evaluación"</p>';
        strhtml += '</div>';

        $("#dialogoinstrcomp").html(strhtml);

        $("#dialogoinstrcomp").dialog({
            position: { my: "center center" },
            resizable: false,
            height: 300,
            width: 600,
            closeOnEscape: false,
            open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
            modal: true,
            buttons: {
                "Volver": function () {
                    $(this).dialog("close");
                }
            }
        });
}

function instrobj() {
    strhtml = '<div style="overflow-x:hidden; overflow-y:visible; font-family: Arial; font-size: 10px;"><table  style="border:none;" cellpadding="6">';
    strhtml += '<p><b>INSTRUCCIONES SOBRE EL PROCESO ANUAL</b></p>';
    strhtml += '<p><b>PRIMERA ETAPA - ESTABLECIMIENTO DE OBJETIVOS</b></p>';
    strhtml += '<p>1. La primera etapa es la de "Establecimiento de Objetivos", en donde la Jefatura y Empleado se reúnen para discutir y acordar los objetivos del año.</p>';
    strhtml += '<p>2.El Empleado ingresa sus objetivos del año en la plataforma.</p>';
    strhtml += '<p>3. Una vez ingresados los objetivos debe enviarlos a su Jefatura para su revisión mediante el botón "Enviar a Jefatura".</p>';
    strhtml += '<p>4.La Jefatura revisa los objetivos ingresados por el empleado y tiene dos opciones:</p>';
    strhtml += '<p  style="margin-left:14px;">';
    strhtml += 'a. Aprobar el formulario con los objetivos ingresados mediante el botón "Aprobación Objetivos".';
    strhtml += '<p  style="margin-left:14px;">';
    strhtml += 'b. Si requiere la corrección de algún elemento, debe devolver al empleado el formulario realizando los comentarios correspondientes mediante el botón "Devolver Objetivos".</p>';
    strhtml += '<p>5.En el caso de que la Jefatura deba devolver los objetivos al empelado, éste debe leer los comentarios de la jefatura y si lo requiere deben juntarse nuevamente para discutir y acordar los comentarios.</p>';
    strhtml += '<p>6.El Empleado debe enviar la versión final de los objetivos mediante el botón "Enviar a Jefatura".</p>';
    strhtml += '<p>7.En caso de que la Jefatura apruebe lo revisado en el formulario de Objetivos, deberá aprobarlos mediante el botón "Aprobación Objetivos".</p>';
    strhtml += '<p><b>SEGUNDA ETAPA - EVALUACIÓN DE MITAD DE AÑO</b></p>';
    strhtml += '<p>1. El Empleado debe ingresar a la plataforma de evaluación de desempeño y  hacer click en "Objetivos".</p>';
    strhtml += '<p>2. El Empleado debe realizar una autoevaluación de cada objetivo establecido a comienzos de año, detallando su estado de avance, fechas y estableciendo un porcentaje de avance. Por último, agregar los comentarios pertinentes.</p>';
    strhtml += '<p>3. Una vez finalizado el punto anterior, el Empleado debe enviar la autoevaluación a su Jefatura mediante el botón "Enviar a Jefatura".</p>';
    strhtml += '<p>4. De ser necesario, en esta etapa se pueden agregar nuevos objetivos o cancelar (no eliminar) objetivos que ya no aplican.</p>';
    strhtml += '<p>5. La Jefatura debe revisar la autoevaluación del empleado e incluir su evaluación por cada objetivo en "Comentarios Jefatura". Dentro de los comentarios debe hacer referencia al estado actual del objetivo, fechas y porcentaje de avance, además de incluir comentarios adicionales a éstos.</p>';
    strhtml += '<p  style="margin-left:14px;">';
    strhtml += 'a. En caso de terminar la evaluación de mitad de año, deberá hacer click en el botón "Completar Evaluación Mitad de Año".</p>';
    strhtml += '<p  style="margin-left:14px;">';
    strhtml += 'b. Si requiere algún tipo de corrección por parte del Empleado antes de emitir algún comentario, deberá devolverlo haciendo click en "Devolver Evaluación", e incluir un comentario con la razón por la cuál se está devolviendo.</p>';
    strhtml += '<p>6. En el caso de que la Jefatura deba devolver el formulario al empelado, éste debe leer los comentarios de la Jefatura y si lo requiere deben juntarse nuevamente para discutir y acordar los comentarios.</p>';
    strhtml += '<p>7. El Empleado debe enviar la versión final del formulario mediante el botón "Enviar a Jefatura".</p>';
    strhtml += '<p>8. En caso de que la Jefatura apruebe lo revisado en el formulario, deberá aprobarlos mediante el botón "Aprobación Evaluación"</p>';
    strhtml += '<p><b>TERCERA ETAPA - EVALUACIÓN DE FINAL DE AÑO</b></p>';
    strhtml += '<p>1. El Empleado debe ingresar a la plataforma de evaluación de desempeño y  hacer click en "Objetivos".</p>';
    strhtml += '<p>2. El Empleado debe realizar una autoevaluación de cada objetivo establecido a comienzos de año, detallando su estado de avance, fechas y estableciendo un porcentaje de avance. Por último, agregar los comentarios pertinentes.</p>';
    strhtml += '<p>3. Una vez finalizado el punto anterior, el Empleado debe enviar la autoevaluación a su Jefatura mediante el botón "Enviar a Jefatura".</p>';
    strhtml += '<p>4. La Jefatura debe revisar la autoevaluación del empleado e incluir su evaluación por cada objetivo en "Comentarios Jefatura". Dentro de los comentarios debe hacer referencia al estado actual del objetivo, fechas y porcentaje de avance, además de incluir comentarios adicionales a éstos.</p>';
    strhtml += '<p style="margin-left:14px;">';
    strhtml += 'a. En caso de terminar la evaluación de mitad de año, deberá hacer click en el botón "Completar Evaluación Mitad de Año".</p>';
    strhtml += '<p  style="margin-left:14px;">';
    strhtml += 'b. Si requiere algún tipo de corrección por parte del empleado antes de emitir algún comentario, deberá devolverlo haciendo click en "Devolver Evaluación", e incluir un comentario con la razón por la cuál se está devolviendo.</p>';
    strhtml += '<p>5. En el caso de que la Jefatura deba devolver el formulario al empelado, éste debe leer los comentarios de la Jefatura y si lo requiere deben juntarse nuevamente para discutir y acordar los comentarios.</p>';
    strhtml += '<p>6.El Empleado debe enviar la versión final del formulario mediante el botón "Enviar a Jefatura".</p>';
    strhtml += '<p>7. En caso de que la Jefatura apruebe lo revisado en el formulario, deberá aprobarlos mediante el botón "Aprobación Evaluación"</p>';
    strhtml += '<p><b>ETAPA FINAL - FIRMA DEL FORMULARIO</b></p>';
    strhtml += '<p>1. El Empleado debe ingresar a la plataforma de evaluación de desempeño y  hacer click en "Objetivos".</p>';
    strhtml += '<p>2. El Empleado debe tomar conocimiento de su evaluación final y de los comentarios finales de su Jefatura mediante el botón "Firma Electrónica Empleado". Recordar que esto no implica estar de acuerdo con la evaluación, sino que estar en conocimiento.</p>';
    strhtml += '<p>3. La Jefatura recibe el formulario firmado electrónicamente por el Empleado y de igual forma deberá firmarlo mediante el botón "Firma Electrónica Jefatura".</p>';
    strhtml += '</div>';

    $("#dialogoobj").html(strhtml);

    $("#dialogoobj").dialog({
        position: { my: "center center" },
        resizable: false,
        height: 300,
        width: 600,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        modal: true,
        buttons: {
            "Volver": function () {
                $(this).dialog("close");
            }
        }
    });
}

$.datepicker.regional['es'] = {
    closeText: 'Cerrar',
    prevText: '<Ant',
    nextText: 'Sig>',
    currentText: 'Hoy',
    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
    weekHeader: 'Sm',
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: '',
    changeMonth: true,
    changeYear: true,
    yearRange: '-0:+0'
};
$.datepicker.setDefaults($.datepicker.regional['es']);

