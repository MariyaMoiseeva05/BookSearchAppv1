$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

function logIn() {
    var login = $('#Login').val();
    var password = $('#Password').val();

    $.ajax({
        url: '/api/Account/Login',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            Login: login,
            Password: password,
        }),
        success: function (data) {

            $('#msgLogin').html('');
            $('#msgLogin').html(data.message);
            if (data.error !== undefined) {
                if (data.error.length > 0) {
                    let html = ""
                    data.error.forEach(element => html += "<li>" + element + "</li>");
                    $("#formErrorLogin").html(html);
                    $('#password').val("");
                }
            }
            else {
                alert(data.message);
                $(location).attr('href', "/html");
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

