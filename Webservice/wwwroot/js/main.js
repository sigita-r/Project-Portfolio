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

require(["jquery", "bootstrap"], function($) {
    $(function(){
        $('#loginTriggerButton').show();
    });
});