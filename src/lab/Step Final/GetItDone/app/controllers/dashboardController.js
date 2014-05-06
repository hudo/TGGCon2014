(function () {
    var dashboardController = function ($scope, $location, ticketService) {
        $scope.model = {
            tickets: ticketService.getAllTickets()
        };

        $scope.createNewTicket = function () {
            
        }

        $scope.openTicket = function(ticketId) {
            $location.path("/edit/" + ticketId);
        }
    };

    getItDone.app.controller("dashboardController", ["$scope", "$location", "ticketService", dashboardController]);
})();