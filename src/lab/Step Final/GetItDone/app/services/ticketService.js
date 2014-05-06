(function () {

    var ticketService = function() {
        return {
            getAllTickets: function () {
                return [
                    { Id: 1, Title: "First ticket", SupportedUser: "Tom", Status: "New", Priority: "Medium" },
                    { Id: 2, Title: "Second ticket", SupportedUser: "Bob", Status: "New", Priority: "High" },
                    { Id: 3, Title: "Third ticket", SupportedUser: "Jane", Status: "In Progress", Priority: "Low" }
                ];
            },

            getTicket: function(ticketId) {
                return this.getAllTickets()[ticketId - 1];
            }
        };
    };

    getItDone.app.factory("ticketService", ticketService);
}());