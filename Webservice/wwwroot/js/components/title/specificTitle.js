const { data } = require("jquery");

define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        // let currentComponent = ko.observable("");

        let currentView = ko.observable();
        let titleName = ko.observable();
        let selectedTitleId = ko.observable();
        let getCharactersFromTitle = ko.observableArray([]);

        let getCharactersFromTitle = () => {
            console.log("getCharsFromTitle");
            ds.getCharsFromTitle(2, data => {
                console.log(data);
                charsFromTitle(data);
            });
            //         currentView("Frontpage");
        }
        getCharsFromTitle();

        return {
            currentView,
            titleName,
            selectedTitleId,
            charactersFromTitle,
            getCharactersFromTitle
        }
    };
});