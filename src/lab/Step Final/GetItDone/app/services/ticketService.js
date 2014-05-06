(function () {

    var ticketService = function ($resource) {
        return $resource("/api/tickets/:id", { id: "@ticketId" }, { "update": { method: "PUT" } });
    };

    getItDone.app.factory("ticketService", ticketService);
}());