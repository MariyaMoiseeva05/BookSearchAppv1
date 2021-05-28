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

$(document).ready(function () {
    //review.init();
});

var review = {
    getReview: function () {
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
                        html += '<li><a href=\"#\"><strong>Оценка книги: </strong>' + review[i].Rating + '</a></li>';
                        html += '<li><p><strong>Рецензия написана пользователем: </strong><a id=\"login-review\" href=\"#\">' + review[i].User.Login + '</a></p></li>';
                        html += "</ul>";
                        html += '<a href="review.html?id=' + review[i].RewiewId + '"><h4>' + review[i].Title + '</h4></a>';
                        html += "<div class=\"text hide\"><p>" + review[i].Text + "</p></div>";
                        html += '<a class=\"content_toggle\" href=\"review.html?id=' + review[i].RewiewId + '\">' + "Перейти к рецензии" + '</a>';
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
    },

    getBookReview: function () {
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
                        html += "</div>";
                        html += "</div>";
                        html += "</div>";
                        html += "<br>";
                        // html += '<button type="button" class="mt-2 btn btn-primary btn-block innerBtn"   data-toggle="modal" data-target="#myModal2" onclick="Getdbook(' + book[i].bookId + ');"> Редактировать </button>';
                        // html += '<button type="button" class="btn btn-btn-link btn-block innerBtn" onclick="deleteBook(' + book[i].bookId + ');"> Удалить </button>';

                    }
                }
                $('#BookReviewDiv').html(html);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });

    },

    getRating: function () {
        let rating = document.getElementById('sum-rating');
        let allrating = document.getElementById('all-rating');

        let ratingmini = document.querySelectorAll('.rating-mini');
        let numbers = [];

        function updateResults() {
            rating.value = sumArr(numbers);
            allrating.value = numbers.join(', ');
        }

        function sumArr(arr) {
            let x = 0;
            for (let i = 0; i < arr.length; i++) {
                x += +arr[i]; // (*2)
            }
            return x;

        }

        for (let i = 0; i < ratingmini.length; i++) {
            numbers.push(ratingmini[i].value);
            ratingmini[i].addEventListener('input', function () {
                numbers[i] = this.value;
                updateResults();
            });
        }
        updateResults();
    },
   /* getBook: function () {
        $.ajax({
            url: "/api/Books",
            type: "GET",
            dataType: "HTML",
            success: function (data) {
                let book = JSON.parse(data);
                let html = "";  //текст вставки
                if (book) {
                    for (var i in book) {
                        html += '<a href="book.html?id=' + book[i].BookID + '"><h4>' + book[i].Title + '</h4 ></a>';
                        html += "<br>";
                        html += "<div class=\"row\">";
                        html += "<div class=\"col-lg-3\"><img src=" + book[i].ImageLink + " id=\"review-img\"></div>";
                        html += "</div>";
                        html += "<div class=\"col-lg-8\">";
                        for (var j in book[i].Author) {
                            html += "<a href=\"#\"><h4>" + book[i].Author[j].Author.Full_name + "</h4></a>";
                        }
                        for (var g in book[i].Genre_Books) {
                            html += "<a href=\"#\"><p>Жанр книги: " + book[i].Genre_Books[g].Genre.NameGenre + "</p></a>";
                        }
                        html += "</div>";
                        html += "</div>";
                    }
                }
                $('#book-reviewDiv').html(html);

            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },
    */
    createReview: function () {
        let user_id = sessionStorage.getItem('userid');
        if (user_id == "" || undefined) {
            alert("Вы не авторизованы");
            location.replace('/');
            return false;
        }
        let reviewContent = $('#create-review-content').val();
        if (reviewContent == "") {
            alert('Поле "Текст вашей рецензии" обязательно к заполнению!');
            return false;
        }
        let reviewTitle = $('#create-review-name').val();
        let bookID = $("#book-id").val();
        let ratingBook = $('#create-review-rating').val();
        let typeReview = $('#create-review-type').val() == "1" ? "true" : "false";
        $.ajax({
            url: '/api/Review',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                Title: reviewTitle,
                Text: reviewContent,
                Type: typeReview,
                Rating: ratingBook,
                BookID: bookID,
                UserID: user_id,
            }),
            success: function (data) {
                console.log(data);
                alert("Рецензия успешно добавлена!");
                location.replace("/html/Review.html");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },

    viewReview: function (id) {
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
    },

    viewBook: function (id) {
        return $.ajax({
            url: "/api/Books/" + id,
            type: "GET",
            dataType: "HTML",
        }).done(function (data) {
            return data; // Прокинем данные дальше, наружу
        }).fail(function (xhr, ajaxOptions, thrownError) {
            let error = JSON.parse(xhr.responseText);
            console.log(error)
        });
    },

    init: function () {
        review.getReview();
        review.getBookReview();
    }
};