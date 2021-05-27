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
    var interest = $("#inp-user-interest").val();
    var favorite_books = $("#inp-user-favorite_books").val();
    var country = $("#inp-user-country").val();
    var place = $("#inp-user-place").val();
    var date_of_birth = $("#inp-user-date_of_birth").val();
    var about_me = $("#inp-user-about_me").val();
    var image = $("#inp-user-image_link").files;

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
            passwordConfirm: passwordConfirm,
            interest: interest,
            favorite_books: favorite_books,
            country: country,
            place: place,
            date_of_birth: date_of_birth,
            about_me: about_me,
            image: image
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
                $(location).attr('href', "/html/user-pages/user_home.html");
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

