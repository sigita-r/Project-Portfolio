define(['knockout', 'dataService', 'postman', 'jquery'], function (ko, ds, postman, $) {
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

define(['jquery'], function ($) {
    $('*[id^="cardCarousel"]').each(function() {
        if (window.matchMedia("(min-width: 768px)").matches) {
            let carouselWidth = $(".carousel-inner")[0].scrollWidth;
            let cardWidth = $(".carousel-item").width();
            let scrollPosition = 0;
            $("#" + $(this) + " .carousel-control-next").on("click", function () {
                if (scrollPosition < carouselWidth - cardWidth * 4) {
                    scrollPosition += cardWidth;
                    this(".carousel-inner").animate(
                        { scrollLeft: scrollPosition },
                        600
                    );
                }
            });
            this(".carousel-control-prev").on("click", function () {
                if (scrollPosition > 0) {
                    scrollPosition -= cardWidth;
                    this(".carousel-inner").animate(
                        { scrollLeft: scrollPosition },
                        600
                    );
                }
            });
        } else {
            $(this).addClass("slide");
        }
    });
});