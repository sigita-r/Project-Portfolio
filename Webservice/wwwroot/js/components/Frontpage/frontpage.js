define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let charsFromTitle = ko.observableArray([]);

        let getCharsFromTitle = () => {
            console.log("getCharsFromTitle");
            ds.getCharsFromTitle(data => {
                console.log(data);
                charsFromTitle(data);
            });
            currentView("Frontpage");
        }

        return {
            charsFromTitle,
            getCharsFromTitle
        };
    };
});