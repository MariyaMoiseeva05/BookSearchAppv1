
$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

document.addEventListener("DOMContentLoaded", function (event) {
    getAuthor();
});


function getAuthor() {
        $.ajax({
            url: "/api/Authors",
            type: "GET",
            dataType: "HTML",
            success: function (data) {
            let authors = JSON.parse(data);
                let html = "";
                if (authors) {
                    for (var i in authors) {
                        html += "<div class=\"col-md-3 masonry-item\">";
                        html += "<div class=\"standard-post without-sidebar-post\">";
                        html += "<div class=\"post-image\"><img src=" + (authors[i].ImageLink ? authors[i].ImageLink :"/images/author-default.jpg") + "></div>";
                        html += "<div class=\"down-content\">";
                        html += '<a href="author.html?id=' + authors[i].AuthorId + '"><h4>' + authors[i].Full_name + '</h4 ></a>';
                        html += "<ul class =\"post-info\">";
                        html += '<li><a href="author.html?id=' + authors[i].AuthorId + '">Подробнее об авторе</a></li>';
                        html += "</ul>";
                        html += "</div>";
                        html += "</div>";
                        html += "</div>";
                    }
                }
            $('#authorDiv').html(html);

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }

    });
}

function createAuthor() {
    var full_name = $('#author-Full_name').val();
    var pseudonym = $('#author-Pseudonym').val();
    var date_of_birth = $('#author_Date_of_Birth').val();
    var date_of_death = $('#author_Date_of_Death').val();
    var place_of_birth = $('#author-Place_of_Birth').val();
    var place_of_death = $('#author-Place_of_Death').val();
    var citizenship = $('#author-Citizenship').val();
    var occupation = $('#author-Occupation').val();
    var years_of_creativity = $('#author-Years_of_creativity').val();
    var language_of_works = $('#author-Language_of_works').val();
    var debut = $('#author-Debut').val();
    var details = $('#author-Details').val();
    var awards = $('#author-Awards').val();
    var prizes = $('#author-Prizes').val();
    let fs = document.getElementById("addImage").files; //получение файла из формы
    var data = new FormData();
    if (fs.length > 0) {
        data.append("ImageLink", fs[0]);
    }
    data.append("Full_name", full_name);
    data.append("Pseudonym", pseudonym);
    data.append("Date_of_Birth", date_of_birth);
    data.append("Date_of_Death", date_of_death);
    data.append("Place_of_Birth", place_of_birth);
    data.append("Place_of_Death", place_of_death);
    data.append("Citizenship", citizenship);
    data.append("Occupation", occupation);
    data.append("Years_of_creativity", years_of_creativity);
    data.append("Language_of_works", language_of_works);
    data.append("Debut", debut);
    data.append("Details", details);
    data.append("Awards", awards);
    data.append("Prizes", prizes);
    $.ajax({
        url: '/api/Authors',
        type: 'POST',
        contentType: false,
        processData: false,
        data: data,
        success: function (data) {
            alert("Автор добавлен!");
            getAuthor();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("У вас недостаточно прав для выполнения этого действия");
        }
    });
}

    //загрузка данных об одном авторе
    function viewAuthor(id) {
        return $.ajax({
            url: "/api/Authors/" + id,
            type: "GET",
            dataType: "HTML",
        }).done(function (data) {
            return data; // Прокинем данные дальше, наружу
        }).fail(function (xhr, ajaxOptions, thrownError) {
            let error = JSON.parse(xhr.responseText);
            console.log(error)
        });
    }

    //удаление автора
   function deleteAuthor(id) {
        $.ajax({
            url: author.url + '/' + id,
            type: 'DELETE',
            dataType: 'HTML',
            success: function () {
                author.viewAuthor(id);
            },
            statusCode: {
                401: function () {
                    $(author.errorBlockId).html('У вас недостаточно прав для выполнения данного действия');
                }
            }
        });
    }


    /*viewProject: function (id) {
        $.ajax({
            url: author.url + '/' + id,
            type: 'GET',
            dataType: 'HTML',
            success: function (data) {
                let author = JSON.parse(data);
                let html = "";
                var formatter = new Intl.DateTimeFormat("ru");
                $('#view_modal_label').html(author.full_name);
                $('#update-btn').attr("onclick", "modals.updatingFormModal(" + author.id + ")");

                */
                      

/*document.addEventListener("DOMContentLoaded", function (event) {
    getAuthor();
    getAuthorAll();
});



function getAuthor() {
    $.ajax({
        url: "/api/Authors",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let author = JSON.parse(data);
            let html = "";
            var formatter = new Intl.DateTimeFormat("ru"); 
            if (author) {
                for (var i in author) {
                    html += "<div class=\"col-md-4 masonry-item\">";
                    html += "<div class=\"standard-post without-sidebar-post\">";
                    html += "<div class=\"post-image\"><img src=" + author[i].imageLink + "></div>";
                    html += "<div class=\"down-content\">";
                    html += "<h4>" + author[i].Full_name + "</h4>";
                    html += "<ul class =\"post-info\">";
                    html += "<li><a href=#>Подробнее об авторе</a></li>";
                    html += "</ul>";
                    html += "<h6><em>" + author[i].Pseudonym + "</em></h6>";
                    html += "<p> Дата рождения: " + formatter.format(new Date(Date.parse(author[i].Date_of_Birth))) + "</p>"; 
                   // html += "<p> Дата смерти: " + formatter.format(new Date(Date.parse(author[i].Date_of_Death))) + "</p>";
                    html += "<p class=\"lead\">" + author[i].Place_of_Birth + "</p>";
                    html += "<p class=\"lead\">" + author[i].Place_of_Death + "</p>";
                    html += "<p class=\"lead\">" + author[i].Occupation + "</p>";

                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                }
            }
            $('#authorDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function getAuthorAll() {
    $.ajax({
        url: "/api/Authors",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let author = JSON.parse(data);
            let html = "";
            // var formatter = new Intl.DateTimeFormat("ru"); //формат даты
            // var formatter = new Intl.ToString("D", CultureInfo.CreateSpecificCulture("ru"));
            if (author) {
                for (var i in author) {
                    html += "<div class=\"col-md-4 masonry-item\">";
                    html += "<div class=\"standard-post without-sidebar-post\">";
                    html += "<div class=\"post-image\"><img src=" + author[i].imageLink + "></div>";
                    html += "<div class=\"down-content\">";
                    html += "<h4>" + author[i].Full_name + "</h4>";
                    html += "<ul class =\"post-info\">";
                    html += "<li><a href=#>Подробнее об авторе</a></li>";
                    html += "</ul>";
                    html += "<h6><em>" + author[i].Pseudonym + "</em></h6>";
                    html += "<p> Дата рождения: " + author[i].Date_of_Birth + "</p>"; //formatter.format(new Date(DateTime.parse(
                    html += "<p> Дата смерти: " + author[i].Date_of_Death + "</p>";
                    html += "<p class=\"lead\">" + author[i].Place_of_Birth + "</p>";
                    html += "<p class=\"lead\">" + author[i].Place_of_Death + "</p>";
                    html += "<p class=\"lead\">" + author[i].Occupation + "</p>";
                    html += "<p class=\"lead\">" + author[i].Citizenship + "</p>";
                    html += "<p class=\"lead\">" + author[i].Years_of_creativity + "</p>";
                    html += "<p class=\"lead\">" + author[i].Language_of_works + "</p>";
                    html += "<p class=\"lead\">" + author[i].Debut + "</p>";
                    html += "<p class=\"lead\">" + author[i].Details + "</p>";
                    html += "<p class=\"lead\">" + author[i].Awards + "</p>";
                    html += "<p class=\"lead\">" + author[i].Prizes + "</p>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                }
            }
            $('#authorGetAll').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}*/


