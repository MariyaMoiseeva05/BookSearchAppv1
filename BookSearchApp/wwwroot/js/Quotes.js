document.addEventListener("DOMContentLoaded", function (event) {
    getQuote();
    getBook();
});

const likeBtn = document.getElementById("likeBtn");

let like = true,
    likeCount = document.querySelector('.likes').innerHTML;

likeBtn.addEventListener('click', () => {
    likeCount = like ? ++likeCount : --likeCount;
    like = !like;
    document.querySelector('.likes').innerHTML = likeCount;
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



//Загрузка данных о книгах
function getBook() {
    $.ajax({
        url: "/api/Books",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let books = JSON.parse(data);
            let html = "";  //текст вставки
            if (books) {
                for (var i in books) {
                    html += "<option value ='" + books[i].BookID + "'>" + books[i].Title + "</option>";
                }
            }
            $('#bookDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}
//Загрузка данных об авторах
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
                    html += "<option value ='" + authors[i].AuthorID + "'>" + authors[i].Full_name + "</option>";
                }
            }
            $('#authorDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });

}


function getQuote() {
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
}
