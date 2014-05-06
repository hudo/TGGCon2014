var getItDone = {};

(function () {
    getItDone.app = angular.module("app", ["ngRoute"]);

    getItDone.app.config(["$routeProvider", function($routeProvider) {
        $routeProvider.when("/", {
                templateUrl: "/app/views/dashboard.html",
                controller: "dashboardController"
            }).when("/edit/:ticketId", {
                templateUrl: "/app/views/editTicket.html",
                controller: "editTicketController"
            }).otherwise({
                redirectTo: "/"
            });;
        }
    ]);
}());