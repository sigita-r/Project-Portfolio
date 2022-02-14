define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let query = sessionStorage.getItem("requestedSearchQuery");
        let uid = sessionStorage.getItem("id");
        let searchMatch = ko.observableArray([]);
        

        let performSearch = () => {
            let query_details = {
                userID: uid,
                titleString: query
            };
            ds.performSearch(query_details, data => {
                console.log(data)
                searchMatch(data);
            });
        }
        performSearch();
        

        return {
            query,
            searchMatch,
            performSearch
        }
    };
});