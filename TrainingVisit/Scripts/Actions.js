//Load Data in Table when documents is ready
$(document).ready(function () {
    loadTrainig();
});

// load All Trainig
function loadTrainig() {
    $.ajax({
        url: "/Home/AllTrainig",
        type: "GET",
        success: function (result) {
            $('#tbody').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function
function AddTrainig() {
    //clearTextBox();
    var res = validate();
    if (res == false) {
        return false;
    }
    var traObj = {
        idTraining: $('#idTraining').val(),
        NameTraining: $('#NameTraining').val(),
        DescrTraining: $('#DescrTraining').val()
    };

    $.ajax({
        url: "/Home/AddTrainig",
        data: JSON.stringify(traObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadTrainig();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Trainig ID
function getbyID(id) {
    //clearTextBox();
    $('#NameTraining').css('border-color', 'lightgrey');
    $('#DescrTraining').css('border-color', 'lightgrey');
    //clearTextBox();
    $.ajax({
        url: "/Home/getbyID/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idTraining').val(result.idTraining);
            $('#NameTraining').val(result.NameTraining);
            $('#DescrTraining').val(result.DescrTraining);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating Trainig's record
function Update() {
    //clearTextBox();
    var res = validate();
    if (res == false) {
        return false;
    }
    var traObj = {
        idTraining: $('#idTraining').val(),
        NameTraining: $('#NameTraining').val(),
        DescrTraining: $('#DescrTraining').val()
    };
    $.ajax({
        url: "/Home/EditTrainig",
        data: JSON.stringify(traObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadTrainig();
            $('#myModal').modal('hide');
            $('#idTraining').val("");
            $('#NameTraining').val("");
            $('#DescrTraining').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting Trainig's record
function Delele(ID) {
    //clearTextBox();
    var ans = confirm("Are you sure you want to delete?");
    if (ans) {

        $.ajax({
            url: "/Home/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadTrainig();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for getting the Data Based upon Trainig ID
function getByUser(id) {
    //clearTextBox();
    $('#NameUser').css('border-color', 'lightgrey');
    $('#Surname').css('border-color', 'lightgrey');
    $('#UserBirthdate').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Home/getbyUser/" + id,
        typr: "GET",
        success: function (result) {
            $('#tbodyUser').html(result);
            $('#UserForTrainig').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function GetLatestTrainings(id) {
   // clearTextBox();
    $('#NameUser').css('border-color', 'lightgrey');
    $('#Surname').css('border-color', 'lightgrey');
    $('#UserBirthdate').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Home/GetLatestTrainings/" + id,
        typr: "GET",
        success: function (result) {
            $('#GetLatestTrainings').html(result);
            $('#UserForTrainig').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//Function for clearing the textboxes
function clearTextBox() {
    $('#idTraining').val("");
    $('#NameTraining').val("");
    $('#DescrTraining').val("");
    $('#NameUser').val("");
    $('#Surname').val("");
    $('#UserBirthdate').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#NameTraining').css('border-color', 'lightgrey');
    $('#DescrTraining').css('border-color', 'lightgrey');
}

//Valdidation
function validate() {
    var isValid = true;
    if ($('#NameTraining').val().trim() == "") {
        $('#NameTraining').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameTraining').css('border-color', 'lightgrey');
    }
    if ($('#DescrTraining').val().trim() == "") {
        $('#DescrTraining').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DescrTraining').css('border-color', 'lightgrey');
    }
    return isValid;
}