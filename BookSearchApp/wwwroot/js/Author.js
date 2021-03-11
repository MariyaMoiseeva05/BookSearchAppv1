document.addEventListener("DOMContentLoaded", function (event) {
    getAuthor();
});

var formatter = new Intl.DateTimeFormat("ru"); 

function getAuthor() {
    $.ajax({
        url: "/api/Authors",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let author = JSON.parse(data);
            let html = "";
            if (author) {
                for (var i in author) {
                    html += "<div class=\"author-image\"><img src=" + author[i].imageLink + "></div>";
                    html += "<div class=\"right-content\">";
                    html += "<h6>" + author[i].Full_name + "</h6>";
                    html += "<h7>" + author[i].Pseudonym + "</h7>";
                    html += "<p> Дата рождения" + formatter.format(new Date(Date.parse(author[i].Date_of_Birth))) + "</p>";
                    html += "<p> Дата смерти" + formatter.format(new Date(Date.parse(author[i].Date_of_Death))) + "</p>";
                    html += "<p>" + author[i].Place_of_Birth + "</p>";
                    html += "<p>" + author[i].Place_of_Death + "</p>";
                    html += "<p>" + author[i].Citizenship + "</p>";
                    html += "<p>" + author[i].Occupation + "</p>";
                    html += "<p>" + author[i].Years_of_creativity + "</p>";
                    html += "<p>" + author[i].Language_of_works + "</p>";
                    html += "<p>" + author[i].Debut + "</p>";
                    html += "<p>" + author[i].Prizes + "</p>";
                    html += "<p>" + author[i].Awards + "</p>";
                    html += "<p>" + author[i].Details + "</p>";
                    // html += '<button type="button" class="mt-2 btn btn-primary btn-block innerBtn"   data-toggle="modal" data-target="#myModal2" onclick="Getdbook(' + book[i].bookId + ');"> Редактировать </button>';
                    // html += '<button type="button" class="btn btn-btn-link btn-block innerBtn" onclick="deleteBook(' + book[i].bookId + ');"> Удалить </button>';
                    html += '</div>';
                }
            }
            $('#authorDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

/*function createBook() {
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
}*/