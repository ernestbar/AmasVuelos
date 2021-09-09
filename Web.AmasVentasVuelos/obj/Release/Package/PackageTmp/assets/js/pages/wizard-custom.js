'use strict';
$(document).ready(function() {
    setTimeout(function() {
        // [ Smart Wizard ]
        $('#smartwizard').smartWizard({
            theme: 'dots',
            transitionEffect: 'fade',
            autoAdjustHeight: false,
            useURLhash: false,
            showStepURLhash: false
        });
    }, 700);
    $("#theme_selector").on("change", function() {
        $('#smartwizard').smartWizard("theme", $(this).val());
        return true;
    });
    $('#smartwizard .sw-toolbar').appendTo($('#smartwizard .sw-container'));
    $("#theme_selector").change();

    // [ smart Vartical-left wizard ]
    setTimeout(function() {
        $('#smartwizard-left').smartWizard({
            theme: 'dots',
            transitionEffect: 'fade',
            showStepURLhash: true,
            autoAdjustHeight: true,
            useURLhash: true,
            showStepURLhash: true
        });
        $('#smartwizard-left .sw-toolbar').appendTo($('#smartwizard-left .sw-container'));
    }, 700);

    //  [ smart Vartical-right wizard ]
    setTimeout(function() {
        $('#smartwizard-right').smartWizard({
            theme: 'dots',
            transitionEffect: 'fade',
            showStepURLhash: true,
            autoAdjustHeight: true,
            useURLhash: true,
            showStepURLhash: true
        });
        $('#smartwizard-right .sw-toolbar').appendTo($('#smartwizard-right .sw-container'));
    }, 700);
});
