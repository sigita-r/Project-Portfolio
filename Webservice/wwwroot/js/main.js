require.config({
    baseUrl: 'js',
    shim: {
        bootstrap: {
            deps: ["jquery"]
        }
    },
    paths: {
        jquery: "lib/jquery/jquery-3.6.0",
        knockout: "lib/knockout/knockout-3.5.1",
        dataService: "services/dataService",
        text: "lib/requirejs/text",
        bootstrap: "lib/bootstrap/bootstrap"
    }
});

// component registration
require(['knockout'], (ko) => {
    ko.components.register("Frontpage", {
        viewModel: { require: "components/Frontpage/frontpage" },
        template: { require: "text!components/Frontpage/Frontpage.html" }
    });
});

require(["jquery", "bootstrap"], function ($) {
    $(function () {
        $('#loginTriggerButton').show();
    });
});