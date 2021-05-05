$(document).ready(function () {
    user.loadData();
});

var user = {
    // адрес апи
    url: "/api/Users",
    //id таблицы со всеми пользователям
    tableId: "#table-content",
    // id таблицы со сведениями о пользователе
    viewTableId: "#view_modal_table",
    //загрузка данных
    loadData: function () {
        $.ajax({
            url: user.url,
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                let users = JSON.parse(data);
                let html = "";  //текст вставки
                var formatter = new Intl.DateTimeFormat("ru"); //формат даты
                if (users) {
                    for (var i in users) {
                        html += "<tr data-id=\"" + users[i].id + "\">";
                        html += "<th scope=\"row\">" + (+i + +1) + "</th>";
                        html += "<td>" + users[i].email + "</td>";
                        html += "<td>" + users[i].Name + "</td>";
                        html += "<td>" + users[i].Surname + "</td>";
                        html += "<td>" + users[i].Sex + "</td>";
                        html += "<td>" + users[i].Interest + "</td>";
                        html += "<td>" + users[i].Favorite_books + "</td>";
                        html += "<td>" + users[i].Country + "</td>";
                        html += "<td>" + users[i].Place + "</td>";
                        html += "<td>" + users[i].Date_of_Birth + "</td>";
                        html += "<td>" + users[i].About_me + "</td>";
                        html += "<td class=\"img-user\">" + users[i].ImageLink + "</td>";

                        html += "<td><button type=\"button\" onclick=\"user.viewUser('" + users[i].UserId + "')\" data-toggle=\"modal\" data-target=\"#view_modal\" class=\"btn btn-outline-secondary\"><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button></td>";
                        html += "</tr>";
                    }
                }
                $(user.tableId).html(html); //добавление строк в таблицу с полученными значениями
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },
    // загрузка данных пользователя
    viewUser: function (id) {
        $.ajax({
            url: user.url + '/' + id,
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                let users = JSON.parse(data);
                let html = "";
                $('#view_modal_label').html(users.name);
                $('#update-btn').attr("onclick", "user.createUpdateForm('" + users.UserId + "')");
                $('#save-updates-btn').attr("onclick", "user.updateUser('" + users.UserId + "')");

                html += "<tr><th>Логин</th><td id='user-login'>" + users.Login + "</td ></tr >";
                html += "<tr><th>Имя</th><td id='user-name'>" + users.Name + "</td ></tr >";
                html += "<tr><th>Фамилия</th><td id='user-surname'>" + users.Surname + "</td ></tr >";
                html += "<tr><th>Email</th><td id ='user-email'>" + users.Email + "</td ></tr >";
                html += "<tr><th>Пол</th><td id='user-sex'>" + users.Sex + "</td></tr>";
                html += "<tr><th>Увлечения</th><td id='user-interest'>" + users.Interest + "</td></tr>";
                html += "<tr><th>Любимые книги</th><td id='user-favorite_books'>" + users.Favorite_books + "</td></tr>";
                html += "<tr><th>Страна проживания</th><td id='user-country'>" + users.Country + "</td></tr>";
                html += "<tr><th>Место жительства</th><td id='user-place'>" + users.Place + "</td></tr>";
                html += "<tr><th>Дата рождения</th><td id='user-date_of_birth'>" + users.Date_of_Birth + "</td></tr>";
                html += "<tr><th>О себе</th><td id='user-about_me'>" + users.About_me + "</td></tr>";
                html += "<tr><th>Изображение профиля</th><td id='user-image_link'>" + users.ImageLink + "</td></tr>";
               
                $('#view_modal_table').html(html);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },
    // создание полей для изменения данных
    createUpdateForm: function (id) {
        $('#user-login').html("<input class='form-control' type='text' id='inp-user-login' value='" + $('#user-login').html() + "'>");
        $('#user-name').html("<input class='form-control' type='text' id='inp-user-name' value='" + $('#user-name').html() + "'>");
        $('#user-surname').html("<input class='form-control' type='text' id='inp-user-surname' value='" + $('#user-surname').html() + "'>");
        $('#user-email').html("<input class='form-control' type='text' id='inp-user-email' value='" + $('#user-email').html() + "' >");
        $('#user-sex').html("<input class='form-control' type='text' id='inp-user-sex' value='" + $('#user-sex').html() + "'>");
        $('#user-interest').html("<input class='form-control' type='text' id='inp-user-interest' value='" + $('#user-interest').html() + "'>");
        $('#user-favorite_books').html("<input class='form-control' type='text' id='inp-user-favorite_books' value='" + $('#user-favorite_books').html() + "'>");
        $('#user-country').html("<input class='form-control' type='text' id='inp-user-country' value='" + $('#user-country').html() + "'>");
        $('#user-place').html("<input class='form-control' type='text' id='inp-user-place' value='" + $('#user-place').html() + "'>");
        $('#user-date_of_birth').html("<input class='form-control' type='text' id='inp-user-date_of_birth' value='" + $('#user-date_of_birth').html() + "' >");
        $('#user-about_me').html("<input class='form-control' type='text' id='inp-user-about_me' value='" + $('#user-about_me').html() + "' >");
        $('#user-image_link').html("<input class='form-control' type='text' id='inp-user-image_link' value='" + $('#user-image_link').html() + "' >");
        $('#update-btn').hide();
        $('#save-updates-btn').show();
    },
    updateUser: function (id) {
        let login = $('#inp-user-login').val();
        let name = $('#inp-user-name').val();
        let surname = $('#inp-user-surname').val();
        let email = $('#inp-user-email').val();
        let sex = $("#inp-user-sex").val() == "1" ? "true" : "false";
        let interest = $('#inp-user-interest').val();
        let favorite_books = $('#inp-user-favorite_books').val();
        let country = $('#inp-user-country').val();
        let place = $('#inp-user-place').val();
        let date_of_birth = $('#inp-user-date_of_birth').val();
        let about_me = $('#inp-user-about_me').val();
        let fs = document.getElementById("#inp-user-image_link").files; //получение файла из формы
        var data = new FormData();
        if (fs.length > 0) {
            data.append("ImageLink", fs[0]);
        }
        try {
            if (login == "" || name == "" || surname == "" || email == "" || sex == "" || interest == "" || favorite_books == "" || country == "" ||
                place == "" || date_of_birth == "" || about_me == "")
                throw new Error("Имеются незаполненные поля!");
            $.ajax({
                url: user.url + '/' + id,
                type: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify({
                    Login: login,
                    Surname: surname,
                    Name: name,
                    Email: email,
                    Sex: sex,
                    Interest: interest,
                    Favorite_books: favorite_books,
                    Country: country,
                    Place: place,
                    Date_of_birth: date_of_birth,
                    About_me: about_me
                }),
                success: function () {
                    user.viewUser(id);
                    $('#update-btn').show();
                    $('#save-updates-btn').hide();
                    user.loadData();
                },
                error: function (xhr, thrownError) {
                    alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
                }
            });
        }
        catch (e) {
            alert(e.message);
        }
    }
};