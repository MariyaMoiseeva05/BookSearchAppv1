$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

document.addEventListener("DOMContentLoaded", function (event) {
    getBook();
    getAuthor();
    getGenre();
    getType();
});

//var formatter = new Intl.DateTimeFormat("ru"); 
function getBook() {
    $.ajax({
        url: "/api/Books",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let book = JSON.parse(data);
            let html = "";
            var formatter = new Intl.DateTimeFormat("ru"); 
            if (book) {
                for (var i in book) {
                    html += "<div class=\"col-md-3 masonry-item\">";
                    html += "<div class=\"standard-post without-sidebar-post\">";
                    html += "<div class=\"post-image\"><img src=" + book[i].ImageLink + " id=\"bookGetImage\"></div>";
                    html += "<div class=\"down-content\">";
                    html += '<a href="book.html?id=' + book[i].BookID+'"><h4>' + book[i].Title + '</h4 ></a>';
                    html += "<ul class=\"post - info\">";
                    for (var j in book[i].Author) {
                            html += "<li><a href=\"#\">" + book[i].Author[j].Author.Full_name + "</a></li>";
                    }
                    html += "</ul>";
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



function getAuthor() {
    $.ajax({
        url: "/api/Authors",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let authors = JSON.parse(data);
            let html = "";  //текст вставки
            if (authors) {
                for (var i in authors) {
                    html += "<option value ='" + authors[i].AuthorId + "'>" + authors[i].Full_name + "</option>";
                }
            }
            $('#authorDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });

}

function getGenre() {
    $.ajax({
        url: "/api/Genres",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let genres = JSON.parse(data);
            let html = "";  //текст вставки
            if (genres) {
                for (var i in genres) {
                    html += "<option value ='" + genres[i].GenreId + "'>" + genres[i].NameGenre + "</option>";
                }
            }
            $('#genreDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });

}

function getType() {
    $.ajax({
        url: "/api/Types",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let types = JSON.parse(data);
            let html = "";  //текст вставки
            if (types) {
                for (var i in types) {
                    html += "<option value ='" + types[i].Type_of_literatureId + "'>" + types[i].Name_Type + "</option>";
                }
            }
            $('#typeDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });

}

//Получение рецензий на книгу

/*function getReview() {
    $.ajax({
        url: "/api/Review",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let types = JSON.parse(data);
            let html = "";  //текст вставки
            if (review) {
                for (var i in review) {
                   
                }
            }
            $('#reviewDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });

}*/


function createBook() {
    var title = $('#book-bookTitle').val();
    var description = $('#book-bookDescription').val();
    var story = $('#book-bookStory').val();
    var edition = $('#book-bookEdition').val();
    var publication_date = $("#book-bookDate_of_publication").val();
    var screenings = $('#book-bookScreenings').val();
    var author = $('#authorDiv').val();
    var genre = $('#genreDiv').val();
    var type_of_literature = $('#typeDiv').val();
    let fs = document.getElementById("addImage").files; //получение файла из формы
    var data = new FormData();
    if (fs.length > 0) {
        data.append("ImageLink", fs[0]);
    }
    data.append("Title", title);
    data.append("Description", description);
    data.append("Story", story);
    data.append("Edition", edition);
    data.append("Publication_date", publication_date);
    data.append("Screenings", screenings);
    data.append("Author", author);
    data.append("Genre", genre);
    data.append("Type_of_literature", type_of_literature);
    $.ajax({
        url: '/api/Books',
        type: 'POST',
        contentType: false,
        processData: false,
        data: data,
        success: function (data) {
            alert("Книга добавлена!");
            getBook();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("У вас недостаточно прав для выполнения этого действия");
        }
    });
}
function viewBook(id) {
   return $.ajax({
        url: "/api/Books/"+id,
        type: "GET",
        dataType: "HTML",
    }).done(function (data) {
        return data; // Прокинем данные дальше, наружу
    }).fail(function (xhr, ajaxOptions, thrownError) {
        let error = JSON.parse(xhr.responseText);
        console.log(error)
    });
}