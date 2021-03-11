

document.addEventListener("DOMContentLoaded", function (event) {
    getBook();
});




var formatter = new Intl.DateTimeFormat("ru"); 
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
                    html += "<div class=\"post-image\">";
                    html += "<a href=\"#\"><img src=" + book[i].ImageLink + "></a>";
                    html += "</div >";
                    html += "<div class=\"down - content\">";
                    html += "<a href=\"#\"><h4>" + book[i].Title + "</h4 ></a>";
                    html += "<ul class=\"post - info\">";
                    html += "<li><a href=\"#\">" + formatter.format(new Date(Date.parse(book[i].Publication_date))) + "</a></li>";
                    html += "<li><a href=\"#\">" + book[i].Edition + "</a></li>";
                    html += "</ul>";
                    html += "<p>" + book[i].Description + "</p>";
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

function getAuthor() {
    const uri = "/api/Authors/";
    let items = null;
    var b, z = "";
    var request = new XMLHttpRequest();
    request.open("GET", uri, false);
    request.onload = function () {
        items = JSON.parse(request.responseText);
        for (b in items) {
            z += "<option value ='" + items[b].AuthorID + "'>Автор" + items[b].Full_name + "</option>";
        }
        document.getElementById("authorDiv").innerHTML = z;
    };
    request.setRequestHeader("Accepts", "application/json;charset=UTF-8");
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    request.send();

}

function getGenre() {
    const uri = "/api/Genres/";
    let items = null;
    var c, w = "";
    var request = new XMLHttpRequest();
    request.open("GET", uri, false);
    request.onload = function () {
        items = JSON.parse(request.responseText);
        for (c in items) {
            c += "<option value ='" + items[c].GenreID + "'>Жанр" + items[c].NameGenre + "</option>";
        }
        document.getElementById("genreDiv").innerHTML = w;
    };
    request.setRequestHeader("Accepts", "application/json;charset=UTF-8");
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    request.send();

}

function getType() {
    const uri = "/api/Genres/";
    let items = null;
    var d, y = "";
    var request = new XMLHttpRequest();
    request.open("GET", uri, false);
    request.onload = function () {
        items = JSON.parse(request.responseText);
        for (d in items) {
            d += "<option value ='" + items[d].Type_of_literatureID + "'>Тип литературы" + items[c].Name_Type + "</option>";
        }
        document.getElementById("genreDiv").innerHTML = y;
    };
    request.setRequestHeader("Accepts", "application/json;charset=UTF-8");
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    request.send();

}

function createBook() {
    var title = $('#book-bookTitle').val();
    var description = $('#book-bookDescription').val();
    var story = $('#book-bookStory').val();
    var edition = $('#book-bookEdition').val();
    var publication_date = $('#book-bookPublicationDate').val();
    var screenings = $('#book-bookScreenings').val();
    var author = $('#authorDiv').val();
    var genre = $('#genreDiv').val();
    var type_of_literature = $('#typeDiv').val();

    let fs = document.getElementById("addImage").files; //получение файла из формы
    var data = new FormData();
    if (fs.length > 0) {
        data.append("ImageLink", fs[0]);
    }
    console.log(data);
    $.ajax({
        url: '/api/Books',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            Title = title,
            Description = description,
            Story = story,
            Edition = edition,
            Publication_date = publication_date,
            Screenings = screenings,
            Author = author,
            Genre = genre,
            Type_of_literature = type_of_literature
        }),
        success: function (data) {
            loadData();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}