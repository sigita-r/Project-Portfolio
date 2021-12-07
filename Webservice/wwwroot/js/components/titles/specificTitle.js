const { data } = require("jquery");

define(['knockout', 'dataService', 'postman'], function (ko, dataService, postman) {
    return function (params) {
        // let currentComponent = ko.observable("");

        let currentView = ko.observable();
        let titleName = ko.observable();
        let selectedTitleId = ko.observable();
        let charactersFromTitles = ko.observableArray([]);

        dataService.GetCharactersFromTitle(selectedTitleId, data => {
            console.log(data);
            charactersFromTitles(data)
        }

        return {
            currentView,
            titleName,
            selectedTitleId,
            charactersFromTitles
        }
    };
});