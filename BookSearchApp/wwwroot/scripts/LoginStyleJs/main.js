$(function() {

    $('.btn-link[aria-expanded="true"]').closest('.accordion-item').addClass('active');
  $('.collapse').on('show.bs.collapse', function () {
	  $(this).closest('.accordion-item').addClass('active');
	});

  $('.collapse').on('hidden.bs.collapse', function () {
	  $(this).closest('.accordion-item').removeClass('active');
	});

});


const uri = "/api/Account/Register";
function Register() {
    // Считывание данных с формы
    var name = $("#name").val();
    var surname = $("#surname").val();
    var sex = $("#sex").val();
    var login = $("#login").val();
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
        login:login,
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
            htmlError += '<li>' + response.error[i] + '</li>';
        }
        $("#formErrorRegister").html(htmlError);
    }
    // Очистка полей паролей
    $("#password").va('');
    $("#passwordConfirm").val('');
}
// Обработка клика по кнопке регистрации
document.querySelector("#btnRegister").addEventListener("click", Register);

function logIn() {
    var email, password = "";
    // Считывание данных с формы
    email = document.getElementById("Email").value;
    password = document.getElementById("Password").value;

    var request = new XMLHttpRequest();
    request.open("POST", "/api/Account/Login");
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.onreadystatechange = function () {
        // Очистка контейнера вывода сообщений
        document.getElementById("msgLogin").innerHTML = "";
        var mydiv = document.getElementById('formErrorLogin');
        while (mydiv.firstChild) {
            mydiv.removeChild(mydiv.firstChild);
        }
        // Обработка ответа от сервера
        if (request.responseText !== "") {
            var msg = '';
            common.init();
            msg = JSON.parse(request.responseText);
            document.getElementById("msgLogin").innerHTML = msg.message;
            // Вывод сообщений об ошибках
            if (typeof msg.error !== "undefined" && msg.error.length > 0) {
                for (var i = 0; i < msg.error.length; i++) {
                    var ul = document.getElementsByTagName("ul");
                    var li = document.createElement("li");
                    li.appendChild(document.createTextNode(msg.error[i]));
                    ul[1].appendChild(li);
                }
            }
            document.getElementById("Password").value = "";
        }
    };
    // Запрос на сервер
    request.send(JSON.stringify({
        email: email,
        password: password
    }));
}
function logOff() {
    var request = new XMLHttpRequest();
    request.open("POST", "api/account/logoff");
    request.onload = function () {
        var msg = JSON.parse(this.responseText);
        document.getElementById("msgLogin").innerHTML = "";
        var mydiv = document.getElementById('formErrorLogin');
        while (mydiv.firstChild) {
            mydiv.removeChild(mydiv.firstChild);
        }
        document.getElementById("msgLogin").innerHTML = msg;
        location.reload();
    };
    request.setRequestHeader("Content-Type",
        "application/json;charset=UTF-8");
    request.send();
    localStorage.removeItem('jcart');
}
// Обработка кликов по кнопкам
document.getElementById("btnLogin").addEventListener("click", logIn);
document.getElementById("logoffBtn").addEventListener("click", logOff);