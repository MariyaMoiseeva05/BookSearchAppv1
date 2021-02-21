document.addEventListener("DOMContentLoaded", function (event) {
    getBook();
});

var options = { year: 'numeric', month: 'long', day: 'numeric'};
var formatter = new Intl.DateTimeFormat("ru", options); //формат даты
function getBook() {
    $.ajax({
        url: "/api/Books",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let book = JSON.parse(data);
            let html = "";
            if (book) {
                for (var i in book) {
                    html += " <div class=\"standard - posts\">";
                    html += "<div class=\"row masonry - layout normal - col - gap\">";
                    html += "<div class=\"col - lg - 4 masonry - item travel\">";
                    html += "<div class=\"standard - post without - sidebar - post\">";
                    html += "<div class=\"post-image\">";
                    html += "<a href=\"#\"><img src=" + book[i].ImageLink + "></a></div>";
                    html += "<div class=\down - content\">";
                    for (j in book[i].Authors) {
                        html += "<a href=\"#\"><h4><em>" + book[i].Authors[j].Full_name + "</em></h4></a>";
                    }
                    html += "<ul class=\"post - info\">";
                    html += " <li><p class=\"lead\">" + book[i].Edition + "</p>";
                    html += "<li><p class=\"lead\">" + formatter.format(new Date(Date. parse(book[i].Publication_date))) + "</p>";
                    html += "</ul>";
                    html += "<p class =\"lead\">" + book[i].Description + "</p>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                   // html += '<button type="button" class="mt-2 btn btn-primary btn-block innerBtn"   data-toggle="modal" data-target="#myModal2" onclick="Getdbook(' + book[i].bookId + ');"> Редактировать </button>';
                   // html += '<button type="button" class="btn btn-btn-link btn-block innerBtn" onclick="deleteBook(' + book[i].bookId + ');"> Удалить </button>';
                  
                }
            }
            $('#bookDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function createBook() {
    var title = $('#createTitle').val();
    var description = $('#createDescription').val();
    let fs = document.getElementById("addImage").files; //получение файла из формы
    var data = new FormData();
    if (fs.length > 0) {
        data.append("ImageLink", fs[0]);
    }
    console.log(data);
    data.append("Title", title);
    data.append("Description", description);
    console.log(data);
    $.ajax({
        url: '/api/Books',
        type: 'POST',
        contentType: false,
        processData: false,
        data: data
    });
}