$(document).ready(function () {
});
$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

function Register() {
    // Считывание данных с формы
    var login = $("#login").val();
    var name = $("#name").val();
    var surname = $("#surname").val();
    var sex = $("#sex").val() == "1" ? "true" : "false";
    var email = $("#email").val();
    var password = $("#password").val();
    var passwordConfirm = $("#passwordConfirm").val();

    $.ajax({
        url: '/api/Account/Register',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
        name: name,
        surname: surname,
        sex: sex,
        login: login,
        email: email,
        password: password,
        passwordConfirm: passwordConfirm
        }),
        success: function (data) {

            $('#msg').html('');
            $('#msg').html(data.message);
            if (data.error !== undefined) {
                if (data.error.length > 0) {
                    let html = ""
                    data.error.forEach(element => html += "<li>" + element + "</li>");
                    $("#formError").html(html);
                    $('#password').val("");
                    $('#passwordConfirm').val("");
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

