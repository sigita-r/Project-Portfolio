define(["knockout", "postman", 'dataService'], function (ko, postman, ds) {
    let usernameSignup = ko.observable();
    let passwordSignup = ko.observable();
    let emailSignup = ko.observable();
    let dobSignup = ko.observable();
    let usernameLogin = ko.observable();
    let passwordLogin = ko.observable();

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

    let register = () => {
        let user = {
            Username: usernameSignup(),
            Password: passwordSignup(),
            Email: emailSignup(),
            DateOfBirth: dobSignup()
        };

        ds.register(user, data => {
            console.log(data);
        });
        alert("If you have entered valid data, the registration was successful - you may now try to log in.");
        location.reload();
    };

    let login = () => {
        let user = {
            Username: usernameLogin(),
            Password: passwordLogin()
        };

        ds.login(user, data => {
            console.log(data);
            sessionStorage.setItem("username", data.username);
            sessionStorage.setItem("token", data.token);
            sessionStorage.setItem("id", JSON.parse(atob(data.token.split('.')[1])).id);
        });
        alert("If you have entered correct data, you will now be logged in.");
        location.reload();
    };

    let logout = () => {
        sessionStorage.removeItem("username");
        sessionStorage.removeItem("token");
        sessionStorage.removeItem("id");
        postman.publish("changeView", "Frontpage");
        location.reload();
    };

    return {
        currentView,
        changeContent,
        isActive,
        usernameSignup,
        passwordSignup,
        emailSignup,
        dobSignup,
        usernameLogin,
        passwordLogin,
        register,
        login,
        logout
    }
});