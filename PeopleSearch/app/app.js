var app;
(function (app) {
    // The main module - responsible for loading the entire application
    var main = angular.module("PeopleSearch", ["ngRoute"]);
    main.config(routeConfig);
    routeConfig.$inject = ["$routeProvider"];
    function routeConfig($routeProvider) {
        $routeProvider
            .when("/search", {
            templateUrl: "app/templates/search.html",
            controller: "SearchController as vm"
        })
            .when("/add", {
            templateUrl: "app/templates/add.html",
            controller: "AddController as vm"
        })
            .otherwise("/search");
    }
})(app || (app = {}));
//# sourceMappingURL=app.js.map