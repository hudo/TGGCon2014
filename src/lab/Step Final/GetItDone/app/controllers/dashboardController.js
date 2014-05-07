(function () {
    var dashboardController = function ($scope, $location, ticketService, enums) {

        $scope.enums = enums;

        $scope.model = {
            tickets: ticketService.query(),
            newTicketName: ""
        };

        $scope.createNewTicket = function() {
            ticketService.save({ title: $scope.model.newTicketName }, function(result, headers) {
                var ticketid = headers("location").split("/")[3];
                $location.path("/edit/" + ticketid);
            });
        };

        $scope.openTicket = function(ticketId) {
            $location.path("/edit/" + ticketId);
        };

        $scope.canCreateNewTicket = function() {
            return $scope.model.newTicketName != "";
        };
    };

    getItDone.app.controller("dashboardController", ["$scope", "$location", "ticketService", "enums", dashboardController]);
})();