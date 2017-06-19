$(document).ready(function ($) {


    $("#autButton").click(function (event) {
        event.preventDefault();

        $('#myAuthModal').modal('show');
        return false;
    });


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
