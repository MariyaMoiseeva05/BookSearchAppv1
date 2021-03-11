$(document).ready(function () {
    $('.toast1').toast('show');
    $("#drag").draggable();
});



const uri = "/api/Account/Register";
function Register() {
    // Считывание данных с формы
    var login = $("#login").val();
    var name = $("#name").val();
    var surname = $("#surname").val();
    var sex = $("#sex").val() == "1" ? "true" : "false";
    var email = $("#email").val();
    var password = $("#password").val();
    var passwordConfirm = $("#passwordConfirm").val();
    let request = new XMLHttpRequest();
    request.open("POST", uri);
    request.setRequestHeader("Accepts",
        "application/json;charset=UTF-8");
    request.setRequestHeader("Content-Type",
        "application/json;charset=UTF-8");
    // Обработка ответа
    request.onload = function () {
        ParseResponse(this);
    };
    // Запрос на сервер
    request.send(JSON.stringify({
        name: name,
        surname: surname,
        sex: sex,
        login: login,
        email: email,
        password: password,
        passwordConfirm: passwordConfirm
    }));
}
// Разбор ответа
function ParseResponse(e) {

    // Очистка контейнера вывода сообщений
    $("#msgLogin").html("");
    $("#formErrorLogin").html('');
    // Обработка ответа от сервера
    let response = JSON.parse(e.responseText);
    $("#msgRegister").html(response.message);
    // Вывод сообщений об ошибках
    if (response.error.length > 0) {
        let htmlError = "";
        for (var i = 0; i < response.error.length; i++) {
            htmlError += "<li>" + response.error[i] + '</li>';
        }
        $("#formErrorRegister").html(htmlError);
    }
    // Очистка полей паролей
    $("#password").val('');
    $("#passwordConfirm").val('');
}
// Обработка клика по кнопке регистрации
document.querySelector("#btnRegister").addEventListener("click", Register);

