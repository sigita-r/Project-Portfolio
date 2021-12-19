define(["knockout", "postman"], function (ko, postman) {

    let menuItems = [
        { title: "Personality", component: "personality" },
        { title: "Frontpage", component: "Frontpage" }

    ];

    let amount = ko.observable(123999212123.4567);

    //let currentView = ko.observable('Frontpage');

    let currentView = ko.observable(menuItems[0].component);

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
        menuItems,
        changeContent,
        isActive,
        amount
    }
});