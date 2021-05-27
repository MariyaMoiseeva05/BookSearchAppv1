$(document).ready(function () {
    quote.init();
});

/*const likeBtn = document.getElementById("likeBtn");

let like = true,
    likeCount = document.querySelector('.likes').innerHTML();

likeBtn.addEventListener('click', () => {
    likeCount = like ? ++likeCount : --likeCount;
    like = !like;
    document.querySelector('.likes').html(html) = likeCount;
});

document.addEventListener("DOMContentLoaded", function () {
    var scrollbar = document.body.clientWidth - window.innerWidth + 'px';
    console.log(scrollbar);
    document.querySelector('[href="#addQuote"]').addEventListener('click', function () {
        document.body.style.overflow = 'hidden';
        document.querySelector('#addQuote').style.marginLeft = scrollbar;
    });
    document.querySelector('[href="#close"]').addEventListener('click', function () {
        document.body.style.overflow = 'visible';
        document.querySelector('#addQuote').style.marginLeft = '0px';
    });
});
*/




var quote = {
    getQuote: function () {
        $.ajax({
            url: "/api/Quotes",
            type: "GET",
            dataType: "HTML",
            success: function (data) {
                let quote = JSON.parse(data);
                let html = "";
                if (quote) {
                    for (var i in quote) {
                        html += "<div class = \"standard-posts\">";
                        html += "<div class = \"row\">";
                        html += "<div class = \"col lg-12\">";
                        html += "<div class = \"standard-post\">";
                        html += "<div class = \"down-content\">";
                        html += "<div class = \"row\">";
                        html += "<blockquote>";
                        html += '<h4><em><b>' + quote[i].Content + '</b></em></h4>';
                        html += "<div>";
                        for (var b in quote[i].Book) {
                            html += '<h5><b>' + quote[i].Book.Title + '</b></h5><br>';
                            for (var a in quote[i].Book[b].Author) {
                                html += '<h5><b>' + quote[i].Book[b].Author[a].Author.Full_name + '</b></h5>';
                            }
                        }
                        html += "</div>";
                        html += "<div class = \"row justify-content-md-center\">";
                        html += "<div class = \"col col-lg-2\"></div>";
                        html += "<div class = \"col-md-auto\">";
                        html += '<div class=\"normal-white-button\" id=\"likeBtn\"><i class=\"fa fa-thumbs-o-up fa-2\" aria-hidden="true"></i></div>';
                        html += "</div>";
                        html += "<div class = \"col col-lg-3\">";
                        html += '<div class=\"likes\">' + quote[i].Like + '</div>';
                        html += "</div>";
                        html += "</div>";
                        html += "</blockquote>";
                        html += "</div>";
                        html += "</div>";
                        html += "</div>";
                        html += "</div>";
                        html += "</div>";
                    }
                }
                $('#quoteDiv').html(html);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },

    //Загрузка данных о книгах
    getBook: function () {
        $.ajax({
            url: "/api/Books",
            type: "GET",
            dataType: "HTML",
            success: function (data) {
                let books = JSON.parse(data);
                let html = "";  //текст вставки
                if (books) {
                    for (var i in books) {
                        for (var a in books[i].Author) {
                            html += "<option value ='" + books[i].BookID + "'>Название: " + books[i].Title + " , автор:  " + books[i].Author[a].Author.Full_name + "</option>";
                        }
                    }
                }
                $('#bookDiv').html(html);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
},
//Загрузка данных об авторах
    getAuthor: function() {
    $.ajax({
        url: "/api/Authors",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let authors = JSON.parse(data);
            let html = "";  //текст вставки
            if (authors) {
                for (var i in authors) {
                    html += "<option value ='" + authors[i].AuthorID + "'>" + authors[i].Full_name + "</option>";
                }
            }
            $('#authorDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });

},


    /*function getUser() {
        $.ajax({
            url: "/api/Users",
            type: "GET",
            dataType: "HTML",
            success: function (data) {
                    let users = JSON.parse(data);
                    let html = "";  //текст вставки
                    if (users) {
                        for (var i in users) {
                            html += users[i].UserId;
                        }
                }
                    $('#user_id').html(html);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }*/



    createQuote: function () {
        let user_id = sessionStorage.getItem('userid');
        if (user_id == "" || undefined) {
            alert("Вы не авторизованы");
            location.replace('/');
            return false;
        }
        let contentQuote = $('#quote-Content').val();
        if (contentQuote == "") {
            alert('Поле Цитата обязательно к заполнению!');
            return false;
        }
        let bookQuote = $('#bookDiv').val();
        $.ajax({
            url: '/api/Quotes',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                BookID: bookQuote,
                UserID: user_id,
                Content: contentQuote,
            }),

            success: function (data) {
                console.log(data);
                alert("Цитата успешно добавлена!");
                location.replace("/html/Quotes.html");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    },

    viewQuote: function (id) {
        return $.ajax({
            url: "/api/Quotes/" + id,
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
        quote.getQuote();
        quote.getAuthor();
        quote.getBook();
    }
};
