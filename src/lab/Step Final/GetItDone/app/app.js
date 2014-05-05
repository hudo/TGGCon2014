var getItDone = {};

(function () {
    getItDone.app = angular.module("app", ["ngRoute"]);

    getItDone.app.config(["$routeProvider", function($routeProvider) {
        $routeProvider.when("/", {
                templateUrl: "/app/views/dashboard.html",
                controller: "dashboardController"
            }).when("/new", {
                templateUrl: "/app/views/createTicket.html",
                controller: "ticketController"
            }).otherwise({
                redirectTo: '/'
            });;
        }
    ]);
}());