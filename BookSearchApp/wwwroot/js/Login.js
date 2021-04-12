$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

function logIn() {
    var login = $('#Login').val();
    var password = $('#Password').val();
    var remember_me = $("#remember_me").prop("checked");
    console.log(remember_me);
    $.ajax({
        url: '/api/Account/Login',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            Login: login,
            Password: password,
            RememberMe: remember_me
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
function logOff() {
    $.ajax({
        url: 'api/Account/Logoff',
        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            var msg = JSON.parse(data);
            document.getElementById("msgLogin").innerHTML = "";
            var mydiv = document.getElementById('formErrorLogin');
            while (mydiv.firstChild) {
                mydiv.removeChild(mydiv.firstChild);
            }
            document.getElementById("msgLogin").innerHTML = msg;
            location.reload();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });


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
/*document.getElementById("btnLogin").addEventListener("click", logIn);
document.getElementById("logoffBtn").addEventListener("click", logOff);*/