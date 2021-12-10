// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function setAlert() {
    let actionMessage = $('#alert-message');
    actionMessage.addClass('visually-hidden');

    actionMessage.removeClass('alert-success');
    actionMessage.removeClass('alert-warning');
    actionMessage.removeClass('alert-danger');
    actionMessage.removeClass('alert-info');

    if(actionMessage.html().lastIndexOf("Low") >= 0){
        actionMessage.addClass('alert-info');
    }
    else if(actionMessage.html().lastIndexOf("Ideal") >= 0){
        actionMessage.addClass('alert-success');
    }
    else if(actionMessage.html().lastIndexOf("Pre-High") >= 0){
        actionMessage.addClass('alert-warning');
    }
    else if(actionMessage.html().lastIndexOf("High") >= 0){
        actionMessage.addClass('alert-danger');
    }

    actionMessage.removeClass('visually-hidden');
}