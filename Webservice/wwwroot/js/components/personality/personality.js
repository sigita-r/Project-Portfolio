define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let personality = ko.observable();

        let getPersonality = () => {
            console.log("personalities:");
            ds.getPersonality(2, personality);
            //         currentView("Frontpage");
        }

        getPersonality();

        return {
            personality,
            getPersonality
        };
    };
});