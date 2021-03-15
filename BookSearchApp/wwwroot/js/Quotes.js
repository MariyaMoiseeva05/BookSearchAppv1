document.addEventListener("DOMContentLoaded", function (event) {
    getQuote();
});

const likeBtn = document.getElementById("likeBtn");

let like = true,
    likeCount = document.querySelector('.likes').innerHTML;

likeBtn.addEventListener('click', () => {
    likeCount = like ? ++likeCount : --likeCount;
    like = !like;
    document.querySelector('.likes').innerHTML = likeCount;
});


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
                    html += '<p><cite>' + quote[i].Full_name + '</cite></p>';
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