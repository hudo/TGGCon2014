(function() {
    var dashboardController = function($scope, $location) {
        $scope.model = { greeting: "Hello Dashboard" };

        $scope.newTicket = function() {
            $location.path("/new");
        }
    };

    getItDone.app.controller("dashboardController", ["$scope", "$location", dashboardController]);
})();