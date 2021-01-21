document.addEventListener("DOMContentLoaded", function (event) {
    getBook();
});

function getBook() {
    $.ajax({
        url: "/api/book",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let book = JSON.parse(data);
            let html = "";
            if (book) {
                for (var i in book) {
                    html += "<div class=\"card-white col-12 col-md-6 col-lg-3\">";
                    html += "<div class=\"card-body\">";
                    html += "<div class='img-container'><img class=\"card-img\" src=" + book[i].imageLink + "></div>";
                    html += '<strong> <h4>' + book[i].title + '</h4> </strong>';
                    html += '<strong> <h2>' + book[i].author + '</h4> </strong>';
                    html += '<p> Тип литературы:' + book[i].typeLit + '</p>';
                    html += '<p> Жанр' + book[i].genre + '</p>';
                    html += '<p> Описание: ' + book[i].description + '</p>';
                    html += '<p Сюжет:>' + book[i].story + ' </p>';
                    html += '<p> Тираж' + book[i].edition + '</p>';
                    html += '<p> Дата выхода в свет' + book[i].date + '</p>';
                   // html += '<button type="button" class="mt-2 btn btn-primary btn-block innerBtn"   data-toggle="modal" data-target="#myModal2" onclick="Getdbook(' + book[i].bookId + ');"> Редактировать </button>';
                   // html += '<button type="button" class="btn btn-btn-link btn-block innerBtn" onclick="deleteBook(' + book[i].bookId + ');"> Удалить </button>';
                    html += '</div>';
                    html += "</div>";
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
    var author = $('#chooseAuthor').val();
    var typeLit = $('#chooseTypeLit').val();
    var genre = $('#chooseGenre').val();
    var description = $('#createDescription').val();
    var story = $('#createStory').val();
    var edition = $('#createEdition').val();
    var date = $('#create_Date').val();
    let fs = document.getElementById("addImage").files; //получение файла из формы
    var data = new FormData();
    if (fs.length > 0) {
        data.append("ImageLink", fs[0]);
    }
    console.log(data);
    data.append("Title", title);
    data.append("Author", author);
    data.append("Type_of_literature", typeLit);
    data.append("Genre", genre);
    data.append("Description", description);
    data.append("Story", story);
    data.append("Edition", edition);
    data.append("Publication_date", date);
    console.log(data);
    $.ajax({
        url: '/api/book',
        type: 'POST',
        contentType: false,
        processData: false,
        data: data,
        success: function (data) {
            getBook();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("У вас недостаточно прав для выполнения этого действия");
        }
    });
}
