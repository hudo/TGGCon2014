var getItDone = {};

(function () {
    getItDone.app = angular.module("app", ["ngRoute", "ngResource"]);

    getItDone.app.config(["$routeProvider", function($routeProvider) {
        $routeProvider.when("/", {
                templateUrl: "/app/views/dashboard.html",
                controller: "dashboardController"
            }).otherwise({
                redirectTo: "/"
            });;
        }
    ]);

    window.log = console.log;
}());