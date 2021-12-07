require.config({
    baseUrl: 'js',
    shim: {
        knockout: {
            deps: ["bootstrap"]
        }
    },
    paths: {
        jquery: "lib/jquery/jquery-3.6.0",
        knockout: "lib/knockout/knockout-3.5.1",
        dataService: "services/dataService",
        text: "lib/requirejs/text",
        bootstrap: "lib/bootstrap/bootstrap.bundle.min",
        postman: "services/postman"
    }
});

// component registration
require(['knockout'], (ko) => {
    ko.components.register("Frontpage", {
        viewModel: { require: "components/Frontpage/frontpage" },
        template: { require: "text!components/Frontpage/Frontpage.html" }
    });
});

require(['knockout', 'viewmodel'], function (ko, vm) {
    ko.applyBindings(vm);
});