(function () {
    var dashboardController = function ($scope, $location, ticketService) {

        $scope.newTicket = { name: "" };

        $scope.model = {
            tickets: ticketService.query()
        };

        $scope.createNewTicket = function () {
            ticketService.save({ title: $scope.newTicket.name },function (result, headers) {
                var ticketid = headers("location").split("/")[3];
                $location.path("/edit/" + ticketid);
            });
        }

        $scope.openTicket = function(ticketId) {
            $location.path("/edit/" + ticketId);
        }

        $scope.hasName = function() {
            return $scope.newTicket.name==0;
        }
    };

    getItDone.app.controller("dashboardController", ["$scope", "$location", "ticketService", dashboardController]);
})();