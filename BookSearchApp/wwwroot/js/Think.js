
$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

document.addEventListener("DOMContentLoaded", function (event) {
    getThink();
});

function getThink() {
    $.ajax({
        url: "/api/Thinks",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let think = JSON.parse(data);
            let html = "";
            var formatter = new Intl.DateTimeFormat("ru");
            if (think) {
                for (var i in think) {
                    html += "<div class=\"down - content\" id=\"down-content-think\">";
                    html += "<div class=\"meta-category\">";
                    html += "<span id=\"span-think\">Мои мысли</span>";
                    html += "</div>";
                    html += "<a href=\"single-standard-post.html\"><h4>" + think[i].Title + "</h4></a>";
                    html += "<ul class=\"post-info\">";
                    html += "<li> <a href=\"#\">" + + formatter.format(new Date(Date.parse(think[i].Date_of_creation))) + "</a></li>";
                    for (var j in think[i].User) {
                        html += "<li><a href=\"#\">" + think[i].User[j].Login + "</a></li>";
                    }
                    html += "</ul>";
                    html += "<p class = lead>" + think[i].Content + "</p>";
                    html += "<button type= button class=btn btn-danger ml-2 mr-2 onclick='deleteThink(" + think[i].ThinkId + ");'>Удалить</button>";
                    html += "<button type=button class=btn btn-primary ml-2 mr-2 data-toggle=modal data-target=#updateThink onclick='editThink(" + think[i].ThinkId + ");'>Редактировать</button>";
                    html += "</div>";
                }
            }
            $('#thinkDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function createThink() {

}

function viewThink(id) {
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
}