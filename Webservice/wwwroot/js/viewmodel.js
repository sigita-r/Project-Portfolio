define(["knockout", "postman"], function (ko, postman) {
    let personalityInTitle = [
        { title: "List", component: "list-categories" },

    ];

    let amount = ko.observable(123.4567);

    let currentView = ko.observable('Frontpage');

    let changeContent = menuItem => {
        console.log(menuItem);
        currentView(menuItem.component)
    };

    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });

    return {
        currentView,
        changeContent,
        isActive,
        amount
    }
});