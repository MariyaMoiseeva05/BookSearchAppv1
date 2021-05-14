
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
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function updateAuthor(id) {
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
    $.ajax({
        url: '/api/Authors/'+id,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify({
            Full_name: full_name,
            Pseudonym: pseudonym,
            Date_of_Birth: date_of_birth,
            Date_of_Death: date_of_death,
            Place_of_Birth: place_of_birth,
            Place_of_Death: place_of_death,
            Citizenship: citizenship,
            Occupation: occupation,
            Years_of_creativity: years_of_creativity,
            Language_of_works: language_of_works,
            Debut: debut,
            Details: details,
            Awards: awards,
            Prizes: prizes,
            ImageLink: fs
        }),
        success: function (data) {
            getAuthor();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function insertAuthor(id) {
    $.ajax({
        url: '/api/Authors/' + id,
        type: 'GET',
        dataType: 'HTML',
        success: function (data) {
            let a = JSON.parse(data);
            $('#author-Full_name').val(a.Full_name);
            $('#author-Pseudonym').val(a.Pseudonym);
            $('#author_Date_of_Birth').val(a.Date_of_Birth);
            $('#author_Date_of_Death').val(a.Date_of_Death);
            $('#author-Place_of_Birth').val(a.Place_of_Birth);
            $('#author-Place_of_Death').val(a.Place_of_Death);
            $('#author-Citizenship').val(a.Citizenship);
            $('#author-Occupation').val(a.Occupation);
            $('#author-Years_of_creativity').val(a.Years_of_creativity);
            $('#author-Language_of_works').val(a.Language_of_works);
            $('#author-Debut').val(a.Debut);
            $('#author-Details').val(a.Details);
            $('#author-Awards').val(a.Awards);
            $('#author-Prizes').val(a.Prizes);
            let fs = document.getElementById("addImage").files; //получение файла из формы
            var data = new FormData();
            if (fs.length > 0) {
                data.append("ImageLink", fs[0]);
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
    $('#save-btn').attr("onclick", "author.updateAuthor(" + id + ")");
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




