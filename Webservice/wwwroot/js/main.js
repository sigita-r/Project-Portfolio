require.config({
    baseUrl: 'js',
    shim: {
        knockout: {
            deps: ["bootstrap", "jquery"]
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

    ko.components.register("specificTitle", {
        viewModel: { require: "components/title/specificTitle" },
        template: { require: "text!components/specificTitle/specificTitle.html" }
    });

    //ko.bindinghandlers.currency = {
    //    update: function (element, valueaccessor, allbindings) {
    //        // first get the latest data that we're bound to
    //        var value = valueaccessor();

    //        // next, whether or not the supplied model property is observable, get its current value
    //        var valueunwrapped = ko.unwrap(value);

    //        element.innertext = "$" + number(valueunwrapped).tofixed(2);
    //    }
    //};
});

require(['knockout', 'viewmodel'], function (ko, vm) {
    ko.applyBindings(vm);
});