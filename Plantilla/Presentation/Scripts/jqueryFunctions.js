// ------------ DatePicker---------- //

    $(".inCalendar").datepicker({
        //minDate: -1,
        maxDate: "+60M +365D",
        changeMonth: true,
        changeYear: true,
        yearRange:'2000:2021',
        showOn: "button",
        buttonImage: "../Images/calendar.png",
        dateFormat: "dd-mm-y",
        buttonImageOnly: true

        
    });


    //$(".dialog").dialog({
    //    autoOpen: false,
    //    show: {
    //        effect: "blind",
    //        duration: 1000
    //    },
    //    hide: {
    //        effect: "explode",
    //        duration: 1000
    //    }
    //});

    //$(".crearLote").click(function () {
    //    $(".dialog").dialog("open");
        
    //});

    //$(document).ready(function () {
    //    $(".dialog").hide();
    //})

// -------------- ***************************** --------------
    
    function valida(valorTexto, objeto) {
        if (valorTexto == null || valorTexto == "") {
            objeto.addClass("ui-state-error");
            return false;
        } else {
            objeto.removeClass("ui-state-error");
            return true;
        }
    }
    
    // -------------- FORMS ANALISIS PROTEINA --------------

    $(function () {

        var dato1 = $("#MainContent_ctrNuevoAnalisis_txtVolumenHCI"),
        dato2 = $("#MainContent_ctrNuevoAnalisis_txtConcentracionHCL"),
        dato3 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraProteina"),
        allFields = $([]).add(dato1).add(dato2).add(dato3);

        $(".form_Proteina").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(dato1.val(), dato1);
                    bvalida = bvalida && valida(dato2.val(), dato2);
                    bvalida = bvalida && valida(dato3.val(), dato3);

                    if (bvalida) {
                        var intDato1 = parseFloat(dato1.val());
                        var intDato2 = parseFloat(dato2.val());
                        var intDato3 = parseFloat(dato3.val());
                        var calculoTotal = (intDato1 * intDato2 * .014 * 6.25 * 100) / intDato3;
                        
                        if (isNaN(calculoTotal))
                            calculoTotal = 0;
                        $("#MainContent_ctrNuevoAnalisis_txtProteina").val(calculoTotal.toFixed(2));
                        
                        //var proteina = parseFloat($("#MainContent_ctrNuevoAnalisis_btnProteina").attr("value"));


                        $(this).dialog("close");

                        
                    }
                    
                    
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtProteina")
          .button()
          .click(function () {
              $(".form_Proteina").dialog("open");
          });
    });

   // -------------- FORMS HUMEDAD --------------

    $(function () {

        var dato1 = $("#MainContent_ctrNuevoAnalisis_txtPesoPlatoMuestra"),
        dato2 = $("#MainContent_ctrNuevoAnalisis_txtPesoPlatoVacio"),
        dato3 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraHumedad"),
        allFields = $([]).add(dato1).add(dato2).add(dato3);

        $(".form_Humedad").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(dato1.val(), dato1);
                    bvalida = bvalida && valida(dato2.val(), dato2);
                    bvalida = bvalida && valida(dato3.val(), dato3);

                    if (bvalida) {
                        var intDato1 = parseFloat(dato1.val());
                        var intDato2 = parseFloat(dato2.val());
                        var intDato3 = parseFloat(dato3.val());
                        var calculoTotal = 100 - ((intDato1 - intDato2) / intDato3) * 100;
                        if (isNaN(calculoTotal) || calculoTotal == 'Infinity')
                            calculoTotal = 0;

                        $("#MainContent_ctrNuevoAnalisis_txtHumedad").val(calculoTotal.toFixed(2));
                        $(this).dialog("close");
                    }
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtHumedad")
          .button()
          .click(function () {
              $(".form_Humedad").dialog("open");
          });
    });

    // -------------- FORMS CENIZA --------------

    $(function () {

        var txtDato1 = $("#MainContent_ctrNuevoAnalisis_txtPesoCrisolMuestra"),
        txtDato2 = $("#MainContent_ctrNuevoAnalisis_txtPesoCrisolVacio"),
        txtDato3 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraCeniza"),
        allFields = $([]).add(txtDato1).add(txtDato2).add(txtDato3);

        $(".form_Ceniza").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(txtDato1.val(), txtDato1);
                    bvalida = bvalida && valida(txtDato2.val(), txtDato2);
                    bvalida = bvalida && valida(txtDato3.val(), txtDato3);

                    if (bvalida) {
                        var intDato1 = parseFloat(txtDato1.val());
                        var intDato2 = parseFloat(txtDato2.val());
                        var intDato3 = parseFloat(txtDato3.val());

                        var calculoTotal = ((intDato1 - intDato2) * 100) / intDato3;
                        if (isNaN(calculoTotal))
                            calculoTotal = 0;

                        $("#MainContent_ctrNuevoAnalisis_txtCeniza").val(calculoTotal.toFixed(2));
                        $(this).dialog("close");
                    }
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtCeniza")
          .button()
          .click(function () {
              $(".form_Ceniza").dialog("open");
          });
    });

    // -------------- FORMS GRASA --------------

    $(function () {

        var txtDato1 = $("#MainContent_ctrNuevoAnalisis_txtPesoBalon"),
        txtDato2 = $("#MainContent_ctrNuevoAnalisis_txtGrasaAnalisis"),
        txtDato3 = $("#MainContent_ctrNuevoAnalisis_txtPesoBalonVacio"),
        txtDato4 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraGrasa"),
        allFields = $([]).add(txtDato1).add(txtDato2).add(txtDato3).add(txtDato4);

        $(".form_Grasa").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(txtDato1.val(), txtDato1);
                    bvalida = bvalida && valida(txtDato2.val(), txtDato2);
                    bvalida = bvalida && valida(txtDato3.val(), txtDato3);
                    bvalida = bvalida && valida(txtDato4.val(), txtDato4);

                    if (bvalida) {
                        var intDato1 = parseFloat(txtDato1.val());
                        var intDato2 = parseFloat(txtDato2.val());
                        var intDato3 = parseFloat(txtDato3.val());
                        var intDato4 = parseFloat(txtDato4.val());
                        var calculoTotal = ((intDato1 + intDato2 - intDato3) * 100) / intDato4;
                        if (isNaN(calculoTotal))
                            calculoTotal = 0;

                        $("#MainContent_ctrNuevoAnalisis_txtGrasa").val(calculoTotal.toFixed(2));
                        $(this).dialog("close");
                    }
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtGrasa")
          .button()
          .click(function () {
              $(".form_Grasa").dialog("open");
          });
    });

    // -------------- FORMS DIGEST PESTINA --------------

    $(function () {

        var dato1 = $("#MainContent_ctrNuevoAnalisis_txtVolumenHCIPestina"),
        dato2 = $("#MainContent_ctrNuevoAnalisis_txtConcentracionHCLPestina"),
        dato3 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraPestina"),
        allFields = $([]).add(dato1).add(dato2).add(dato3);

        $(".form_Pestina").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(dato1.val(), dato1);
                    bvalida = bvalida && valida(dato2.val(), dato2);
                    bvalida = bvalida && valida(dato3.val(), dato3);

                    if (bvalida) {
                        var intDato1 = parseFloat(dato1.val());
                        var intDato2 = parseFloat(dato2.val());
                        var intDato3 = parseFloat(dato3.val());
                        var calculoTotal = (intDato1 * intDato2 * .014 * 6.25 * 100) / intDato3;
                        var dato4 = $("#MainContent_ctrNuevoAnalisis_txtProteina").val();
                        dato4 = parseFloat(dato4);
                        calculoTotal = parseFloat(calculoTotal);
                        if (isNaN(calculoTotal))
                            calculoTotal = 0;
                        var calculoFinal = calculoTotal / dato4;
                        if (isNaN(calculoFinal))
                            calculoFinal = 0;
                        $("#MainContent_ctrNuevoAnalisis_txtPestina").val(calculoFinal.toFixed(2));
                        $(this).dialog("close");
                    }
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtPestina")
          .button()
          .click(function () {
              $(".form_Pestina").dialog("open");
          });
    });

    // -------------- FORMS DIGEST ACIDEZ --------------

    $(function () {

        var dato1 = $("#MainContent_ctrNuevoAnalisis_txtVolumenGastadoNAOH"),
        dato2 = $("#MainContent_ctrNuevoAnalisis_txtConcentracionNAOH"),
        dato3 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraAcidez"),
        allFields = $([]).add(dato1).add(dato2).add(dato3);

        $(".form_Acidez").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(dato1.val(), dato1);
                    bvalida = bvalida && valida(dato2.val(), dato2);
                    bvalida = bvalida && valida(dato3.val(), dato3);

                    if (bvalida) {
                        var intDato1 = parseFloat(dato1.val());
                        var intDato2 = parseFloat(dato2.val());
                        var intDato3 = parseFloat(dato3.val());
                        var calculoTotal = (intDato1 * intDato2 * 28.2) / intDato3;
                        if (isNaN(calculoTotal))
                            calculoTotal = 0;
                        $("#MainContent_ctrNuevoAnalisis_txtAcidez").val(calculoTotal.toFixed(2));
                        $(this).dialog("close");
                    }
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtAcidez")
          .button()
          .click(function () {
              $(".form_Acidez").dialog("open");
          });
    });

    // -------------- FORMS DIGEST PEROXIDO --------------

    $(function () {

        var dato1 = $("#MainContent_ctrNuevoAnalisis_txtVolGastadoTiosulfato"),
        dato2 = $("#MainContent_ctrNuevoAnalisis_txtVolumenBlanco"),
        dato3 = $("#MainContent_ctrNuevoAnalisis_txtConcentracionTiosulfato"),
        dato4 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraPeroxido"),
        allFields = $([]).add(dato1).add(dato2).add(dato3).add(dato4);

        $(".form_Peroxido").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(dato1.val(), dato1);
                    bvalida = bvalida && valida(dato2.val(), dato2);
                    bvalida = bvalida && valida(dato3.val(), dato3);
                    bvalida = bvalida && valida(dato4.val(), dato4);

                    if (bvalida) {
                        var intDato1 = parseFloat(dato1.val());
                        var intDato2 = parseFloat(dato2.val());
                        var intDato3 = parseFloat(dato3.val());
                        var intDato4 = parseFloat(dato4.val());
                        var calculoTotal = ((intDato1 - intDato2) * intDato3 * 1000) / intDato4;
                        if (isNaN(calculoTotal))
                            calculoTotal = 0;

                        $("#MainContent_ctrNuevoAnalisis_txtPeroxido").val(calculoTotal.toFixed(2));
                        $(this).dialog("close");
                    }
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtPeroxido")
          .button()
          .click(function () {
              $(".form_Peroxido").dialog("open");
          });
    });

    // -------------- FORMS RETENIDO TAMIZ --------------

    $(function () {

        var dato1 = $("#MainContent_ctrNuevoAnalisis_txtPesoRetenido"),
        dato2 = $("#MainContent_ctrNuevoAnalisis_txtPesoMuestraTamix"),
        allFields = $([]).add(dato1).add(dato2);

        $(".form_Tamiz").dialog({
            autoOpen: false,
            height: 250,
            width: 225,
            modal: true,
            buttons: {
                "Guardar": function () {
                    var bvalida = true;
                    allFields.removeClass("ui-state-error");
                    bvalida = bvalida && valida(dato1.val(), dato1);
                    bvalida = bvalida && valida(dato2.val(), dato2);
                    
                    if (bvalida) {
                        var intDato1 = parseFloat(dato1.val());
                        var intDato2 = parseFloat(dato2.val());
                        var calculoTotal = (intDato1 / intDato2) * 100;
                        if (isNaN(calculoTotal))
                            calculoTotal = 0;

                        $("#MainContent_ctrNuevoAnalisis_txtTamiz").val(calculoTotal.toFixed(2));
                        $(this).dialog("close");
                    }
                },
                Cancelar: function () {
                    allFields.removeClass("ui-state-error");
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");
            }
        });

        $("#MainContent_ctrNuevoAnalisis_txtTamiz")
          .button()
          .click(function () {
              $(".form_Tamiz").dialog("open");
          });
    });

    
$("#MainContent_ctrNuevoAnalisis_btnSumatoriaTotal")
          .button()
          .click(function () {

              var proteina = parseFloat($("#MainContent_ctrNuevoAnalisis_txtProteina").val());
              if(isNaN(proteina))
                 proteina = 0;
              var humedad = parseFloat($("#MainContent_ctrNuevoAnalisis_txtHumedad").val());
              if (isNaN(humedad))
                  humedad = 0;
              var ceniza = parseFloat($("#MainContent_ctrNuevoAnalisis_txtCeniza").val());
              if (isNaN(ceniza))
                  ceniza = 0;
              var grasa = parseFloat($("#MainContent_ctrNuevoAnalisis_txtGrasa").val());
              if (isNaN(grasa))
                  grasa = 0;
              var sumatoria = proteina + humedad + ceniza + grasa;
                  
              
              $("#MainContent_ctrNuevoAnalisis_btnSumatoriaTotal").val(sumatoria.toFixed(2));
              
          });
 
//--------------------------------------------------------------------------------

$(function () {

    $('.checkSelec input:checkbox').click(function () {
        $('.checkSelec input[type=checkbox]:checked').each(function () {
            if ($('.checkSelec input[type=checkbox]:checked').length > 1) {
                alert("Solo puede seleccionar un lote");
                $('.checkSelec input[type=checkbox]').attr('checked', false);
            } 
        });
   });
});
   

