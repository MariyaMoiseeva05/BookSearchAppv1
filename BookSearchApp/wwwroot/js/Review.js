$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

$(document).ready(function () {
    $('.content_toggle').click(function () {
        $('.text').toggleClass('hide');
        if ($('.text').hasClass('hide')) {
            $('.content_toggle').html('Перейти к рецензии');
        } 
        return false;
    });
});

document.addEventListener("DOMContentLoaded", function (event) {
    getReview();
    /*getBook();
    getAuthor();
    getGenre();*/
});

function getReview() {
    $.ajax({
        url: "/api/Review",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let review = JSON.parse(data);
            let html = "";
            if (review) {
                for (var i in review) {
                    html += '<div class="col-12">';
                    html += "<div class=\"post-image\"><a href=\"Review.html\"><img id=\"img-post-review\" src=" + review[i].Book.ImageLink + "></a></div>";
                    html += "<div class=\"down-content\" id=\"down-content-review\">";
                    html += '<a href="book.html?id=' + review[i].Book.BookID + '"><h4>' + review[i].Book.Title + '</h4></a>';
                    for (var a in review[i].Book.Authors) {
                        html += '<a href="author.html?id=' + review[i].Book.Authors[a].Author.AuthorId + '"><h4><em>' + review[i].Book.Authors[a].Author.Full_name + '</h4></em></a>';
                    }
                    html += "<ul class=\"post - info\">";
                    html += '<li><a href=\"#\">' + review[i].Rating + '</a></li>';
                    html += '<li><p><strong>Рецензия написана пользователем: </strong><a id=\"login-review\" href=\"#\">' + review[i].User.Login + '</a></p></li>';
                    html += "</ul>";
                    html += '<a href="review.html?id=' + review[i].RewiewId + '"><h4>' + review[i].Title + '</h4>';
                    html += "<div class=\"text hide\"><p>" + review[i].Text + "</p></div>";
                    html += "<a class=\"content_toggle\" href=\"review.html?id=' + review[i].RewiewId + '\">"+ "Перейти к рецензии" +"</a>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";
                    // html += '<button type="button" class="mt-2 btn btn-primary btn-block innerBtn"   data-toggle="modal" data-target="#myModal2" onclick="Getdbook(' + book[i].bookId + ');"> Редактировать </button>';
                    // html += '<button type="button" class="btn btn-btn-link btn-block innerBtn" onclick="deleteBook(' + book[i].bookId + ');"> Удалить </button>';

                }
            }
            $('#reviewDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function getUser() {
    $.ajax({
        url: "/api/Users" + sessionStorage.getItem('UserId'),
        type: "GET",
        dataType: "HTML",
        statusCode: {
            200: function (data) {
                let users = JSON.parse(data);
                let html = "";  //текст вставки
                for (i in users) {
                    html += users[i].UserId;
                }
                $('#user_id').html(html);
            },
            401: function (data) {
                alert('У вас не хватает прав для выполнения данного действия');
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.responseText);
        }
    });
}


function createReview() {
    var reviewTitle = $('#create-review-name').val();
    var reviewContent = $('#create-review-content').val();
    var book = $('#book-title').val();
    var user = $('#user_id').val();
    data.append("Title", reviewTitle);
    data.append("Text", reviewContent);
    data.append("BookID", book);
    data.append("UserId", user);
    $.ajax({
        url: '/api/Review',
        type: 'POST',
        contentType: false,
        processData: false,
        data: data,
        success: function (data) {
            alert("Рецензия добавлена!");
            getReview();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function viewReview(id) {
    return $.ajax({
        url: "/api/Review/" + id,
        type: "GET",
        dataType: "HTML",
    }).done(function (data) {
        return data; // Прокинем данные дальше, наружу
    }).fail(function (xhr, ajaxOptions, thrownError) {
        let error = JSON.parse(xhr.responseText);
        console.log(error)
    });
}