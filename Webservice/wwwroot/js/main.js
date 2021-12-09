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

    ko.bindingHandlers.currency = {
        update: function (element, valueAccessor, allBindings) {
            // First get the latest data that we're bound to
            var value = valueAccessor();

            // Next, whether or not the supplied model property is observable, get its current value
            var valueUnwrapped = ko.unwrap(value);

            element.innerText = "$" + Number(valueUnwrapped).toFixed(2);
        }
    };
});

require(['knockout', 'viewmodel'], function (ko, vm) {
    ko.applyBindings(vm);
});