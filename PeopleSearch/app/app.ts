module app {
    // The main module - responsible for loading the entire application
    var main = angular.module("PeopleSearch", ["ngRoute", "app.services", "app.directives"]);
    main.config(routeConfig);

    routeConfig.$inject = ["$routeProvider"];
    function routeConfig($routeProvider: ng.route.IRouteProvider) {
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
}