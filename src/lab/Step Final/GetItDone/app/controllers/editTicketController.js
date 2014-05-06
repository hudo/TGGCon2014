(function() {
    var editTicketController = function ($scope, $routeParams, ticketService) {

        $scope.statuses = [{ name: "New", id: "0" }, { name: "In Progress", id: "1" }, { name: "Closed", id: "2" }];
        $scope.priorities = [{ name: "Low", id: "0" }, { name: "Medium", id: "1" }, { name: "High", id: "2" }];
        $scope.selectedStatus = $scope.statuses[0];

        ticketService.get({ id: $routeParams.ticketId }).$promise.then(function (data) {
            $scope.model = data;

            // preselect status
            $scope.selectedStatus = $scope.statuses[data.ticketStatus];
            $scope.selectedPriority = $scope.priorities[data.ticketPriority];
        });

        $scope.isOpen = function() {
            return $scope.selectedStatus.id == 1;
        }

        $scope.isNew = function () {
            return $scope.selectedStatus.id == 0;
        }

        $scope.isClosed = function () {
            return $scope.selectedStatus.id == 2;
        }

        $scope.saveTicket = function() {
            $scope.model.ticketStatus = $scope.selectedStatus.id;
            $scope.model.ticketPriority = $scope.selectedPriority.id;

            $scope.model.$update();
        }

        $scope.open = function () {
            $scope.selectedStatus = $scope.statuses[1];
        }
        $scope.close = function () {
            $scope.selectedStatus = $scope.statuses[2];
        }
    };

    getItDone.app.controller("editTicketController", ["$scope", "$routeParams", "ticketService", editTicketController]);
})();