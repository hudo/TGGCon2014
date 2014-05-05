var getItDone = {};

(function () {
    getItDone.app = angular.module("app", ["ngRoute", "ngResource", "ngSanitize"]);

    getItDone.app.config(["$routeProvider", function($routeProvider) {
            $routeProvider.when("/new", {
                templateUrl: "/app/views/createTicket.html",
                controller: "ticketController"
            }).when("/edit/:articleId", {
                templateUrl: "/app/views/createTicket.html",
                controller: "ticketController"
            }).when("/dashboard", {
                templateUrl: "/app/views/dashboard.html",
                controller: "dashboardController"
            }).otherwise({
                redirectTo: '/dashboard'
            });;
        }
    ]);
}());