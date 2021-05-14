
$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

document.addEventListener("DOMContentLoaded", function (event) {
    getThink();
});

function getThink() {
    $.ajax({
        url: "/api/Thinks",
        type: "GET",
        dataType: "HTML",
        success: function (data) {
            let think = JSON.parse(data);
            let html = "";
            var formatter = new Intl.DateTimeFormat("ru");
            if (think) {
                for (var i in think) {
                    html += "<div class=\"down - content\" id=\"down-content-think\">";
                    html += "<div class=\"meta-category\">";
                    html += "<span id=\"span-think\">Мои мысли</span>";
                    html += "</div>";
                    html += "<a href=\"single-standard-post.html\"><h4>" + think[i].Title + "</h4></a>";
                    html += "<ul class=\"post-info\">";
                    html += "<li> <a href=\"#\">" +  formatter.format(new Date(Date.parse(think[i].Date_of_creation))) + "</a></li>";
                    for (var j in think[i].User) {
                        html += "<li><a href=\"#\">" + think[i].User[j].Login + "</a></li>";
                    }
                    html += "</ul>";
                    html += "<p class = lead>" + think[i].Content + "</p>";
                    html += "<button type= button class=btn btn-danger ml-2 mr-2 onclick='deleteThink(" + think[i].ThinkId + ");'>Удалить</button>";
                    html += "<button type=button class=btn btn-primary ml-2 mr-2 data-toggle=modal data-target=#updateThink onclick='editThink(" + think[i].ThinkId + ");'>Редактировать</button>";
                    html += "</div>";
                }
            }
            $('#thinkDiv').html(html);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
        }
    });
}

function createThink() {
    var title = $('#create-think-title').val();
    var text = $('#create-think-content').val();
    var date = $('#create-think-date').val();
    var data = new FormData();
    data.append("Title", title);
    data.append("Content", text);
    data.append("Date_of_creation", date);

    $.ajax({
        url: '/api/Thinks',
        type: 'POST',
        contentType: false,
        processData: false,
        data: data,
        success: function (data) {
            alert("Ваши мысли успешно сохранены!");
            getThink();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("У вас недостаточно прав для выполнения этого действия");
        }
    });
}

function viewThink(id) {
    return $.ajax({
        url: "/api/Thinks/" + id,
        type: "GET",
        dataType: "HTML",
    }).done(function (data) {
        return data; // Прокинем данные дальше, наружу
    }).fail(function (xhr, ajaxOptions, thrownError) {
        let error = JSON.parse(xhr.responseText);
        console.log(error)
    });
}

(function () {
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
})();