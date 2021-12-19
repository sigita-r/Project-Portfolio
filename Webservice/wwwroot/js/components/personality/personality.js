define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let personality = ko.observable();

        let getPersonality = () => {
            console.log("perosnalities");
            ds.getPersonality(2, data => {
                console.log(data);
                personality(data);
            });
        }

        getPersonality();

        return {
            personality,
            getPersonality
        };
    };
});