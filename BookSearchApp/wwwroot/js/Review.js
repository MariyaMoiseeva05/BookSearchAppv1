$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
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
                  /*  <div class="post-image">
                        <a href="Review.html"><img src="../images/default_book.jpeg" alt=""></a>
                                    </div>
                        <div class="down-content">
                            <a href="Review.html"><h4 id="book-title">Название книги<em id="book-author">Автор книги</em></h4></a>
                            <ul class="post-info">
                                <li><a href="#">Оценка</a></li>
                                <li><a href="#">Пользователь, написавший рецензию</a></li>
                            </ul>
                            <p id="review-content">Рецензия Bushwick fam PBRB master cleanse post-ironic. Craft ethical forage four loko fam fanny cronut pork belly waistcoat cloud bread helvetica food truck readymade ethical affogato migas vinyl.</p>
                        </div>*/
                    html += '<div class="col-12">';
                    html += "<div class=\"post-image\"><a href=\"Review.html\"><img src=" + review[i].Book.ImageLink + "></a></div>";
                    html += "<div class=\"down-content\">";
                    html += '<a href="review.html?id=' + review[i].RewiewId + '"><h4>' + review[i].Book.Title + '</h4 >';
                    for (var a in review[i].Book.Authors) {
                        html += '<em>' + review[i].Book.Authors[a].Author.Full_name + '</em></a>';
                    }
                    html += "<ul class=\"post - info\">";
                    html += '<li><a href=\"#\">' + review[i].Rating + '</a></li>';
                    html += '<li><a href=\"#\">' + review[i].User.Login + '</a></li>';
                    html += "</ul>";
                    html += "<p>" + review[i].Text + "</p>";
                    html += "<a href=\"review.html?id=' + review[i].RewiewId + '\">"+ "перейти к рецензии" +"</a>";
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
