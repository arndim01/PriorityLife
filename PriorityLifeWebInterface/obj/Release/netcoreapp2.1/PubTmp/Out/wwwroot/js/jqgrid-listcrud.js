function InitializeAddUpdateRecordDialog() {
    $('#addUpdateRecordDialog').dialog({
        autoOpen: false,
        resizable: false,
        width: 900,
        height: 500,
        modal: true
    });
}

function closeDialog() {
    $('#addUpdateRecordDialog').dialog('close');
}

function saveNewItem() {
    if (isDataValid()) {
        var serializedData = getSerializedData();
        callWebMethod(urlAndMethod + '?handler=Add&serializedData={' + serializedData + '}', '');
    }
}

function updateCurrentItem() {
    if (isDataValid()) {
        var serializedData = getSerializedData();
        callWebMethod(urlAndMethod + '?handler=Update&serializedData={' + serializedData + '}', '');
    }
}

function deleteItem(itemID) {
    var dialogTitle = 'Permanently Delete Item ' + itemID + '?';

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

function showHideItem(itemID) {
    if (itemID == null) {
        // add
        $('#addUpdateRecordDialog').dialog('open');
        $("#addUpdateRecordDialog").dialog("option", "title", "Add New " + addEditTitle);
        $("#inputAdd").show();                      
        $("#inputUpdate").hide();                   

        if ($("#trPrimaryKey") != null)
            $("#trPrimaryKey").hide();
    }
    else {
        // update
        $('#addUpdateRecordDialog').dialog('open');
        $("#addUpdateRecordDialog").dialog("option", "title", "Edit " + addEditTitle + " " + itemID);
        $("#inputUpdate").show();                     
        $("#inputAdd").hide();                        

        if ($("#trPrimaryKey") != null)
            $("#trPrimaryKey").show();
    }
}

function resetValidationErrors() {
    $('.field-validation-error').removeClass('field-validation-error').addClass('field-validation-valid');
    $('.input-validation-error').removeClass('input-validation-error').addClass('input-validation-valid');
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
            closeDialog();
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

function isNumeric(value) {
    var numericPattern = /^\d+$/;
    var matchArray = value.toString().match(numericPattern);

    if (matchArray != null)
        return true;

    return false;
}

function isDecimal(value) {
    var numericPattern = /^[0-9]+(\.[0-9]+)?$/;
    var matchArray = value.toString().match(numericPattern);

    if (matchArray != null)
        return true;

    return false;
}

function isDate(txtDate) {
    var mSeconds;
    var day;
    var month;
    var year;

    if (txtDate.length !== 10 && txtDate.length !== 9 && txtDate.length !== 8)
        return false;

    // there should be 2 '/' slashes (mainStr.split(",").length - 1)
    if ((txtDate.split('/').length - 1) != 2)
        return false;

    // extract month, day and year from the txtDate (expected format is MM/dd/yyyy), e.g. 7/4/2013
    // subtraction will cast variables to integer implicitly (needed
    // for !== comparing)
    var dateArray = txtDate.split('/');
    month = dateArray[0];
    day = dateArray[1];
    year = dateArray[2];

    // test year range
    if (year < 1000 || year > 3000)
        return false;

    var objDate = new Date(year, month - 1, day);

    if (objDate.getFullYear() != year || objDate.getMonth() + 1 != month && objDate.getDate() != day)
        return false;

    // valid
    return true;
}

function isWithinInt16Range(number) {
    if (number >= -32768 && number <= 32767)
        return true;

    return false;
}

function isWithinInt32Range(number) {
    if (number >= -2147483648 && number <= 2147483647)
        return true;

    return false;
}

function isWithinInt64Range(number) {
    if (Number.isSafeInteger(parseInt(number)))
        return true;

    return false;
}

function isWithinMoneyRange(number) {
    if (number >= -9223372036854775808 && number <= 922337036854775807)
        return true;

    return false;
}

function isWithinSmallMoneyRange(number) {
    if (number >= -214748.3648 && number <= 214748.3647)
        return true;

    return false;
}