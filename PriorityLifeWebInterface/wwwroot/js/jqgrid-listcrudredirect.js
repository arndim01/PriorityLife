function deleteItem(itemID) {
    var dialogTitle = 'Permanently Delete?';

    $("#errorConfirmationDialog").html('<p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>Please click delete to confirm deletion.</p>');

    $("#errorConfirmationDialog").dialog({
        title: dialogTitle,
        modal: true,
        buttons: {
            "Delete": function () {
                var url = urlAndMethod + '?handler=Remove&id=' + itemID; 
                callWebMethod(url, '');
                $(this).dialog("close");
            },
            "Cancel": function () { $(this).dialog("close"); }
        }
    });

    $('#errorConfirmationDialog').dialog('open');
    return false;
}

function deleteTeamDetaialItem(itemID, tableId) {
    var dialogTitle = 'Permanently Delete ?';

    $("#errorConfirmationDialog").html('<p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>Please click delete to confirm deletion.</p>');

    $("#errorConfirmationDialog").dialog({
        title: dialogTitle,
        modal: true,
        buttons: {
            "Delete": function () {
                var url = urlAndMethod + '?handler=RemoveTeamDetail&id=' + itemID;
                callWebDetailsMethod(url, tableId, '');
                $(this).dialog("close");
            },
            "Cancel": function () { $(this).dialog("close"); }
        }
    });

    $('#errorConfirmationDialog').dialog('open');
    return false;
}


function callWebMethod(url, parameter) {
    jQuery.ajax({
        type: "GET",
        url: url,
        data: "{" + parameter + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#list-grid").trigger("reloadGrid");
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowError(xhr.responseText, '');
        }
    });
}

function callWebDetailsMethod(url, tableId, parameter) {
    jQuery.ajax({
        type: "GET",
        url: url,
        data: "{" + parameter + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#" + tableId).trigger("reloadGrid");
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowError(xhr.responseText, '');
        }
    });
}

function ShowError(errorMessage, errorTitle) {
    $(document).ready(function () {
        $("#errorDialog").html(errorMessage);
        $("#errorDialog").dialog({
            modal: true,
            title: errorTitle,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });
    });
}