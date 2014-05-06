(function () {
    var dashboardController = function ($scope, $location, ticketService, enums) {

        $scope.newTicket = { name: "" };

        $scope.enums = enums;

        $scope.model = {
            //tickets: ticketService.query()
            tickets: [ { title: "First", createdBy: "Tom", ticketStatus: 0, ticketPriority: 1}]
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

    getItDone.app.controller("dashboardController", ["$scope", "$location", "ticketService", "enums", dashboardController]);
})();