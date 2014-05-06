(function() {
    var editTicketController = function ($scope, $routeParams, ticketService) {
        $scope.model = ticketService.getTicket($routeParams.ticketId);
    };

    getItDone.app.controller("editTicketController", ["$scope", "$routeParams", "ticketService", editTicketController]);
})();