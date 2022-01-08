define(['knockout', 'dataService', 'postman', 'jquery'], function (ko, ds, postman, $) {
    console.log($('*[id^="cardCarousel"]')); /* I don't understand why this returns an empty array. Maybe it fires before the DOM is loaded, but I don't know how to prevent it from doing that... Will try to figure it out later. */
    $('*[id^="cardCarousel"]').each(function() {
        if (window.matchMedia("(min-width: 768px)").matches) {
            let carouselWidth = $("#" + this + "Inner").scrollWidth;
            let cardWidth = $(".carousel-item").width();
            let scrollPosition = 0;
            $("#" + this + "Next").on("click", function () {
                if (scrollPosition < carouselWidth - cardWidth * 4) {
                    scrollPosition += cardWidth;
                    $("#" + this + "Inner").animate(
                        { scrollLeft: scrollPosition },
                        600
                    );
                }
            });
            $("#" + this + "Prev").on("click", function () {
                if (scrollPosition > 0) {
                    scrollPosition -= cardWidth;
                    $("#" + this + "Inner").animate(
                        { scrollLeft: scrollPosition },
                        600
                    );
                }
            });
        } else {
            $(this).addClass("slide");
        }
    });
    
    return function (params) {
        let charsFromTitle = ko.observableArray([]);

        let getCharsFromTitle = () => {
            console.log("getCharsFromTitle");
            ds.getCharsFromTitle(2, data => {
                console.log(data);
                charsFromTitle(data);
            });
            //         currentView("Frontpage");
        }
        getCharsFromTitle();

        return {
            charsFromTitle,
            getCharsFromTitle
        };
    };
});