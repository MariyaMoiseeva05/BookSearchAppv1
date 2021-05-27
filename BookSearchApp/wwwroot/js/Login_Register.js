$(document).ready(function () {
    common.init();
});

var common = {
    user_type: "", //тип пользователя
    //получение текущего пользователя
    getCurrentUser: function () {
        $.ajax({
            url: '/api/Account/isAuthenticated',
            type: 'POST',
            contentType: 'application/json',
            statusCode: {
                401: function (data) {
                    alert('У вас не хватает прав для выполнения данного действия');

                },
                200: function (data) {
                    $("#msgLogin").html(data.message);
                    if (data.role !== undefined) {
                        sessionStorage.setItem('role', data.role[0]);
                        sessionStorage.setItem('userid', data.id);
                    }
                    if (data.isAuthenticated == 0) {
                        $("#logoffBtn").hide();
                        sessionStorage.setItem('role', 'guest');
                        sessionStorage.setItem('userid', '');
                    }
                    else {
                        let x = window.location;
                        if (x.pathname == "/Login.html") {
                            $(location).attr('href', "/html");
                        }
                        $("#btnLogin").hide();
                        $("#ifnotregister").hide();
                        $("#fogotpassword").hide();
                        $("#btngroup").hide();
                    }
                }
            }
        });
    },
    //выход из аккаунта
    logoff: function () {
        $.ajax({
            url: '/api/account/logoff',
            type: 'POST',
            contentType: 'application/json',
            success: function (data) {

                if (data.error !== undefined) {
                    if (data.error.length > 0) {
                        let html = ""
                        data.error.forEach(element => html += "<li>" + element + "</li>");
                        $("#formErrorLogin").html(html);
                    }
                }
                else {
                    alert(data.message);
                    $(location).attr('href', "/html/Login.html");
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },
    customizePage: function () {
        if (sessionStorage.getItem('role') == 'admin') {
            $('.admin-show').show();
        }
        if (sessionStorage.getItem('role') == 'user') {
            $('.emp-show').show();
        }
    },
    
    //начальная инициализаци страницы
    init: function () {
        common.getCurrentUser();
        common.customizePage();
    }
};
$('.close').on('click', function () { modals.closeAllModals(); })
