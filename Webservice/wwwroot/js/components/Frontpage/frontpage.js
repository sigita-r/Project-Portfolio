define(['knockout', 'dataService', 'postman', 'jquery'], function (ko, ds, postman, $) {
    return function (params) {
        let carouselControls = () => {
            $('*[id^="cardCarousel"]').each(function () {
                if (window.matchMedia("(min-width: 768px)").matches) {
                    let carouselWidth = $("#inner_" + this.id)[0].scrollWidth;
                    let cardWidth = $(".carousel-item").width();
                    let scrollPosition = 0;
                    $("#next_" + this.id).on("click", function () {
                        if (scrollPosition < carouselWidth - cardWidth * 4) {
                            scrollPosition += cardWidth;
                            $("#inner_" + this.id).animate(
                                {scrollLeft: scrollPosition},
                                600
                            );
                        }
                    });
                    $("#prev_" + this.id).on("click", function () {
                        if (scrollPosition > 0) {
                            scrollPosition -= cardWidth;
                            $("#inner_" + this.id).animate(
                                {scrollLeft: scrollPosition},
                                600
                            );
                        }
                    });
                } else {
                    $(this).addClass("slide");
                }
            });
        };
        
        let charsFromTitle = ko.observableArray([]);
        let newTitles = ko.observableArray([]);

        let getCharsFromTitle = () => {
            console.log("getCharsFromTitle");
            ds.getCharsFromTitle(2, data => {
                console.log(data);
                charsFromTitle(data);
            });
            //         currentView("Frontpage");
        }
        getCharsFromTitle();
        
        let getNewTitles = () => {
            console.log("getNewTitles");
            ds.getNewTitles(data => {
                console.log(data);
                newTitles(data);
            });
        }
        getNewTitles();

        return {
            carouselControls,
            charsFromTitle,
            getCharsFromTitle,
            newTitles,
            getNewTitles
        };
    };
});