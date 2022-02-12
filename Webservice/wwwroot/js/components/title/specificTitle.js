define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titleDetails = ko.observableArray([]);
        let rating = ko.observable();
        let charactersInTitle = ko.observableArray([]);
        let rolesInTitle = ko.observableArray([]);
        let alternateLocalizations = ko.observableArray([]);
        let id = sessionStorage.getItem("requestedTID");
        
        let rate = () => {
            let rating_details = {
                User_Id: sessionStorage.getItem("id"),
                Title_Id: id,
                RatingOfTitle: rating()
            };
            ds.rate(rating_details);
            alert("Rating saved.");
        };

        let bookmark = () => {
            let bookmark_details = {
                UserID: sessionStorage.getItem("id"),
                TitleID: id,
                TitleNote: "placeholder"
            };
            ds.createTitleBookmark(bookmark_details);
            alert("Title bookmarked.");
        };
        
        let getTitle = () => {
            ds.getTitleDetails(id, data => {
                console.log(data);
                titleDetails(data);
            });
        }
        getTitle();

        let getCharactersInTitle = () => {
            ds.getCharsFromTitle(id, data => {
                console.log(data);
                charactersInTitle(data);
            });
        }
        getCharactersInTitle();

        let getRolesInTitle = () => {
            ds.getRolesFromTitle(id, data => {
                console.log(data);
                rolesInTitle(data);
            });
        }
        getRolesInTitle();
        
        let getTitleLocalizations = () => {
            ds.getTitleLocalizations(id, data => {
                console.log(data);
                alternateLocalizations(data);
            });
        }
        getTitleLocalizations();
        
        return {
            charactersInTitle,
            rolesInTitle,
            getRolesInTitle,
            getCharactersInTitle,
            alternateLocalizations,
            getTitleLocalizations,
            rating,
            rate,
            bookmark,
            getTitle,
            titleDetails
        }
    };
});