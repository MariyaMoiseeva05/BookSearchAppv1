$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

document.addEventListener("DOMContentLoaded", function (event) {
    getType();
    getGenre();
});

function getType() {
    $.ajax({
        url: "/api/Books",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let book = JSON.parse(data);
            let html = "";
            if (book) {
                for (var i in book) {
                    for (var t in book[i].Type_of_literature) {
                        html += '<h4 id=\"titleType"\>' + book[i].Type_of_literature[t].TypeLit.Name_Type + '</h4>';
                    }
                        for (var g in book[i].Genre_Books) {
                            html += '<div id=\"divGenre\"><a id=\"aGenre\" href = "genre.html?id=' + book[i].Genre_Books[g].Genre.GenreId + '" >' + book[i].Genre_Books[g].Genre.NameGenre + '</a></div>';
                        }
                        /*html += "<dt>";
                        html += '<a href=\"#accordion1\" class=\"accordion-title accordionTitle js-accordionTrigger\" aria-expanded=\"false\" aria-controls="type.html?id=' + book[i].Type_of_literature[t].TypeLit.Type_of_literatureId + '">' + book[i].Type_of_literature[t].TypeLit.Name_Type + '</a>';
                        html += "</dt>";
                        html += '<dd aria-hidden=\"true\" class=\"accordion-content accordionItem is-collapsed\" id="type.html?id=' + book[i].Type_of_literature[t].TypeLit.Type_of_literatureId + '">';
                        html += "<div class=\"col-lg-6\">";
                        for (var g in book[i].Genre_Books) {
                            html += '<p><a href = "genre.html?id=' + book[i].Genre_Books[g].Genre.GenreId + '" >' + book[i].Genre_Books[g].Genre.NameGenre + '</a></p>';
                        }
                        html += "</div>";
                        html += "</dd>";*/

                    }
                }
            $('#typeDiv').html(html);
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
            let genre = JSON.parse(data);
            let html = "";
            if (genre) {
                for (var i in genre) {
                    html += '<p><a href = "genre.html?id=' + genre[i].GenreId + '" >' + genre[i].NameGenre + '</a></p>';
                }
            }
            $('#genreDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

//var formatter = new Intl.DateTimeFormat("ru"); 
function getBookGenre() {
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
                    for (var g in book[i].Genre_Books) {
                        html += '<a>' + book[i].Genre_Books[g].Genre.NameGenre + '</a>';
                    }
                    html += "<div class=\"col-md-3 masonry-item\">";
                    html += "<div class=\"standard-post without-sidebar-post\">";
                    html += "<div class=\"post-image\"><img src=" + book[i].ImageLink + " id=\"bookGetImage\"></div>";
                    html += "<div class=\"down-content\">";
                    html += '<a href="book.html?id=' + book[i].BookID + '"><h4>' + book[i].Title + '</h4 ></a>';
                    html += "<ul class=\"post - info\">";
                    for (var j in book[i].Author) {
                        html += "<li><a href=\"#\">" + book[i].Author[j].Author.Full_name + "</a></li>";
                    }
                    html += "</ul>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";


                }
            }
            $('#bookDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

$("#titleType").next().hide();
$("#titleType").click(function () {
    $(this).next().slideToggle();
    $("#titleType").not(this).next().stop(true, true).slideUp();
});

//accordion

/*(function () {
    var d = document,
        accordionToggles = d.querySelectorAll('.js-accordionTrigger'),
        setAria,
        setAccordionAria,
        switchAccordion,
        touchSupported = ('ontouchstart' in window),
        pointerSupported = ('pointerdown' in window);

    skipClickDelay = function (e) {
        e.preventDefault();
        e.target.click();
    }

    setAriaAttr = function (el, ariaType, newProperty) {
        el.setAttribute(ariaType, newProperty);
    };
    setAccordionAria = function (el1, el2, expanded) {
        switch (expanded) {
            case "true":
                setAriaAttr(el1, 'aria-expanded', 'true');
                setAriaAttr(el2, 'aria-hidden', 'false');
                break;
            case "false":
                setAriaAttr(el1, 'aria-expanded', 'false');
                setAriaAttr(el2, 'aria-hidden', 'true');
                break;
            default:
                break;
        }
    };
    //function
    switchAccordion = function (e) {
        console.log("triggered");
        e.preventDefault();
        var thisAnswer = e.target.parentNode.nextElementSibling;
        var thisQuestion = e.target;
        if (thisAnswer.classList.contains('is-collapsed')) {
            setAccordionAria(thisQuestion, thisAnswer, 'true');
        } else {
            setAccordionAria(thisQuestion, thisAnswer, 'false');
        }
        thisQuestion.classList.toggle('is-collapsed');
        thisQuestion.classList.toggle('is-expanded');
        thisAnswer.classList.toggle('is-collapsed');
        thisAnswer.classList.toggle('is-expanded');

        thisAnswer.classList.toggle('animateIn');
    };
    for (var i = 0, len = accordionToggles.length; i < len; i++) {
        if (touchSupported) {
            accordionToggles[i].addEventListener('touchstart', skipClickDelay, false);
        }
        if (pointerSupported) {
            accordionToggles[i].addEventListener('pointerdown', skipClickDelay, false);
        }
        accordionToggles[i].addEventListener('click', switchAccordion, false);
    }
})();*/