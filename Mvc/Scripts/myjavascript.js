$(document).ready(function ($) {


    $("#autButton").click(function (event) {
        event.preventDefault();
        //$.post("/Account/GetAutPartial", null, function (response) {

        //     $('#authPart').empty();
        //     $('#regPart').empty();
        //     $('#authPart').prepend(response);
        //     $('#myAuthModal').modal('show');
        //});
        $('#myAuthModal').modal('show');
        return false;
    });

    //$("#regButton").click(function (event) {

    //    event.preventDefault();
    //    $.post("/Account/GetRegPartial", null, function (response) {
           
    //        $('#regPart').empty();
    //        $('#authPart').empty();
    //        $("#regPart").prepend(response);
    //        $("#myRegModal").modal('show');
    //    });
    //    return false;
    //});

    $('#auth').submit(function (event) {
        
        event.preventDefault();

        loginButton
        var $btn = $('#loginButton').button('loading')

        var data = $(this).serialize();
        var url = $(this).attr('action');
       
        $.post(url, data, function (response) {
            if(response != "") {
                $("#myAuthModal").modal('hide');
                $('#authPart').empty();
                $('#authReg').empty().prepend(response);
            }
            else {
                alert("Incorrect login or password.");
            }
        });
        $btn.button('reset')
        return false;
    });

    $('.userDel').submit(function (event) {

        event.preventDefault();

        var yes = confirm("Delete user?");
        if (yes) {

            var $btn = $('#loginButton').button('loading')

            var data = $(this).serialize();
            var url = $(this).attr('action');
            
            $.post(url, data, function (response) {
               
                $('#users').empty().prepend(response);
            });
            $btn.button('reset')
        }
        return false;
    });

    //$('#reg').submit(function (event) {
    //    alert("adsa");
    //    event.preventDefault();
    //    var data = $(this).serialize();
    //    var url = $(this).attr('action');


    //    $.post(url, data, function (response) {
    //        $("#myRegModal").modal('hide');
    //        $('#regPart').empty();
    //        $('#authReg').empty().prepend(response);
    //    });
    //    return false;
    //});

    $('#logoutForm').submit(function (event) {
        alert("adsa");
        event.preventDefault();
        var data = $(this).serialize();
        var url = $(this).attr('action');


        $.post(url, data, function (response) {
            
            $('#authReg').empty().prepend(response);
        });

        return false;
    });

});
