define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
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