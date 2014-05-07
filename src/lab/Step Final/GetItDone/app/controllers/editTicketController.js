(function() {
    var editTicketController = function ($scope, $routeParams, $location, ticketService, enums) {

        $scope.enums = enums;

        $scope.model = {
            selectedStatus: $scope.enums.ticketStatuses[0],
            selectedPriority: $scope.enums.ticketPriorities[0],
            error: ""
        };

        ticketService.get({ id: $routeParams.ticketId }).$promise.then(function (data) {
            $scope.model.ticket = data;

            $scope.model.selectedStatus = $scope.enums.ticketStatuses[data.ticketStatus];
            $scope.model.selectedPriority = $scope.enums.ticketPriorities[data.ticketPriority];
        });

        $scope.isOpen = function() {
            return $scope.model.selectedStatus.id == 1;
        };

        $scope.isNew = function() {
            return $scope.model.selectedStatus.id == 0;
        };

        $scope.isClosed = function() {
            return $scope.model.selectedStatus.id == 2;
        };

        $scope.saveTicket = function() {
            console.log($scope.model.ticket);
            $scope.model.ticket.ticketStatus = $scope.model.selectedStatus.id;
            $scope.model.ticket.ticketPriority = $scope.model.selectedPriority.id;

            $scope.model.ticket.$update(function success() {
                $scope.model.error = "saved.";
            }, function error(response) {
                $scope.model.error = response.data.exceptionMessage;
            });
        };

        $scope.openTicket = function () {
            $scope.model.selectedStatus = $scope.enums.ticketStatuses[1];
        };

        $scope.closeTicket = function() {
            $scope.model.selectedStatus = $scope.enums.ticketStatuses[2];
        };

        $scope.goToDashboard = function() {
            $location.path("/");
        };
    };

    getItDone.app.controller("editTicketController", ["$scope", "$routeParams", "$location", "ticketService", "enums", editTicketController]);
})();