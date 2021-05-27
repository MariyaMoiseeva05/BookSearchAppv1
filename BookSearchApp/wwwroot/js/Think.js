
$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

$(document).ready(function () {
    think.init();
});

var think = {
    getThink: function () {
        $.ajax({
            url: "/api/Thinks",
            type: "GET",
            dataType: "HTML",
            success: function (data) {
                let think = JSON.parse(data);
                let html = "";
                if (think) {
                    for (var i in think) {
                        html += '<div class=\"down-content\" id=\"down-content-think\">';
                        html += "<div class=\"meta-category\">";
                        html += "<span id=\"span-think\">Мои мысли</span>";
                        html += "</div>";
                        html += "<a href=\"single-standard-post.html\"><h4>" + think[i].Title + "</h4></a>";
                        html += "<ul class=\"post-info\">";
                        html += "<li><a href=\"#\">" + think[i].Date_of_creation + "</a></li>";
                        for (var j in think[i].User) {
                            html += "<li><a href=\"#\">" + think[i].User[j].Login + "</a></li>";
                        }
                        html += "</ul>";
                        html += "<p class = lead>" + think[i].Content + "</p>";
                        html += "<button id=\"btnDel\" type= button class=btn btn-danger ml-2 mr-2 onclick='think.deleteThink(" + think[i].ThinkId + ");'>Удалить</button>";
                        html += "<button id=\"btnUpdate\" type=button class=btn btn-primary ml-2 mr-2 data-toggle=modal data-target=#updateThink onclick='think.editThink(" + think[i].ThinkId + ");'>Редактировать</button>";
                        html += "</div>";
                        $('#view_modal_table').html(html);
                    }
                }
                $('#thinkDiv').html(html);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },

    createThink: function () {
        let user_id = sessionStorage.getItem('userid');
        let title = $('#create-think-title').val();
        let text = $('#create-think-content').val();
        let date = $('#create-think-date').val();

        $.ajax({
            url: '/api/Thinks',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                UserId: user_id,
                Content: text,
                Title: title,
                Date_of_creation: date,
            }),
            success: function (data) {
                console.log(data);
                alert("Ваши мысли успешно записаны!");
                location.replace("/html/Think.html");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },

    viewThink: function (id) {
        return $.ajax({
            url: "/api/Thinks/" + id,
            type: "GET",
            dataType: "HTML",
        }).done(function (data) {
            return data; // Прокинем данные дальше, наружу
        }).fail(function (xhr, ajaxOptions, thrownError) {
            let error = JSON.parse(xhr.responseText);
            console.log(error)
        });
    },

    updateThink: function (id) {
        var user_id = sessionStorage.getItem('userid');
        var title = $('#create-think-title').val();
        var text = $('#create-think-content').val();
        var date = $('#create-think-date').val();
        $.ajax({
            url: '/api/Thinks/' + id,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify({
                UserId: user_id,
                Content: text,
                Title: title,
                Date_of_creation: date,
            }),
            success: function (data) {
                think.getThink();
                modals.clearFormModal();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },

    insertDataForm: function(id) {
        $.ajax({
            url: '/api/Thinks/' + id,
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                let p = JSON.parse(data);
                $('#create-think-title').val(p.Title);
                $('#create-think-content').val(p.Content);
                $('#create-think-date').val(p.Date_of_creation);
                $(sessionStorage.getItem('userid')).val(p.UserId);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });

        $('#save-btn').attr("onclick", "think.updateThink(" + id + ")");
    },

    deleteThink: function (id) {
        $.ajax({
            url: "/api/Thinks/" + id,
            type: 'DELETE',
            dataType: 'HTML',
            success: function () {
                think.viewThink(id);
            },
            statusCode: {
                401: function () {
                        alert("У вас недостаточно прав для выполнения этого действия");
                }
            }
        });
    },

    init: function () {
        think.getThink();
    }
}

