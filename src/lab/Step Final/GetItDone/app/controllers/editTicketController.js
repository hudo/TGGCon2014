(function() {
    var editTicketController = function ($scope, $routeParams, $location, ticketService, enums) {

        $scope.enums = enums;

        $scope.model = {
            selectedStatus: $scope.enums.ticketStatuses[0],
            selectedPriority: $scope.enums.ticketPriorities[0]
        }

        ticketService.get({ id: $routeParams.ticketId }).$promise.then(function (data) {
            $scope.model.ticket = data;

            $scope.model.selectedStatus = $scope.enums.ticketStatuses[data.ticketStatus];
            $scope.model.selectedPriority = $scope.enums.ticketPriorities[data.ticketPriority];
        });

        $scope.isOpen = function() {
            return $scope.model.selectedStatus.id == 1;
        }

        $scope.isNew = function () {
            return $scope.model.selectedStatus.id == 0;
        }

        $scope.isClosed = function () {
            return $scope.model.selectedStatus.id == 2;
        }

        $scope.saveTicket = function() {
            $scope.model.ticket.ticketStatus = $scope.selectedStatus.id;
            $scope.model.ticket.ticketPriority = $scope.selectedPriority.id;

            $scope.model.ticket.$update();
        }

        $scope.openTicket = function () {
            $scope.model.selectedStatus = $scope.enums.ticketStatuses[1];
        }

        $scope.closeTicket = function () {
            $scope.model.selectedStatus = $scope.enums.ticketStatuses[2];
        }

        $scope.goToDashboard = function() {
            $location.path("/");
        }
    };

    getItDone.app.controller("editTicketController", ["$scope", "$routeParams", "$location", "ticketService", "enums", editTicketController]);
})();