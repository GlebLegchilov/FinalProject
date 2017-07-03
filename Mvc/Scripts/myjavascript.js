$(document).ready(function ($) {


    $("#autButton").click(function (event) {
        event.preventDefault();

        $('#myAuthModal').modal('show');
        return false;
    });


    $('#auth').submit(function (event) {
        
        event.preventDefault();

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


    //$("#regButton").click(function (event) {
    //    event.preventDefault();

    //    $('#myRegModal').modal('show');
    //    return false;
    //});

    //$('#reg').submit(function (event) {

    //    event.preventDefault();

    //    var $btn = $('#loginButton').button('loading')

    //    var data = $(this).serialize();
    //    var url = $(this).attr('action');
    //    alert("zc");
    //    $.post(url, data, function (response) {
    //        if (response != "") {

               
    //            $("#myRegModal").modal('hide');
    //            $('#regPart').empty();
    //            $('#authReg').empty().prepend(response);
    //        }
    //        else {
    //            alert("Incorrect login or password.");
    //        }
    //    });
    //    $btn.button('reset')
    //    return false;
    //});

    $('.userDel').submit(function (event) {

        event.preventDefault();
        var yes = confirm("Delete user?");
        if (yes) {

            var $btn = $('#loginButton').button('loading')

            var data = $(this).serialize();
            var url = $(this).attr('action');
            
            $.post(url, data, function (response) {
                
                $('#users').empty().prepend(response);
            })
            .fail(function() {
                alert( "error" );
            });

            
            $btn.button('reset')
        }
        return false;
    });



    $('.addLot').submit(function (event) {

        event.preventDefault();
       
        alert(this.LotId);
       

        var data = $(this).serialize();
        var url = $(this).attr('action');

        $.post(url, data, function (response) {

            $('#lotsToAdd').empty().prepend(response);
            alert(data);
            $('#LotId').val(data);
        })
        .fail(function () {
            alert("error");
        });


       
        
        return false;
    });


    $('.myLotDel').submit(function (event) {

        event.preventDefault();
        var yes = confirm("Delete lot?");
        if (yes) {

            var data = $(this).serialize();
            var url = $(this).attr('action');

            $.post(url, data, function (response) {

                $('#myAddLots').empty().prepend(response);
            })
            .fail(function () {
                alert("error");
            });

        }
    });

    $('.purchLotDel').submit(function (event) {

        event.preventDefault();
        var yes = confirm("Delete lot?");
        if (yes) {

            var data = $(this).serialize();
            var url = $(this).attr('action');

            $.post(url, data, function (response) {

                $('#myPurchLots').empty().prepend(response);
            })
            .fail(function () {
                alert("error");
            });

        }
    });


});
