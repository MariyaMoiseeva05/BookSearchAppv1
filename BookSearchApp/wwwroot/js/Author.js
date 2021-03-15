document.addEventListener("DOMContentLoaded", function (event) {
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
}


function createAuthor() {
    var full_name = $('#author-Full_name').val();
    var pseudonym = $('#author-Pseudonym').val();
    var date_of_birth = $('#author-Date_of_Birth').val();
    var date_of_death = $('#author-Date_of_Death').val();
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
    console.log(data);
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
    console.log(data);
    $.ajax({
        url: '/api/Authors',
        type: 'POST',
        contentType: false,
        contentData: false,
        /*data: JSON.stringify({
            title = title,
            description = description,
            story = story,
            edition = edition,
            publication_date = publication_date,
            screenings = screenings,
            author = author,
            genre = genre,
            type_of_literature = type_of_literature
        }),*/
        data: data,
        success: function (data) {
            getAuthorAll();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("У вас недостаточно прав для выполнения этого действия");
        }
    });
}