(function() {
    var ticketController = function($scope) {
        $scope.model = { greeting: "Hello Ticket" };
    };

    getItDone.app.controller("ticketController", ["$scope", ticketController]);
})();