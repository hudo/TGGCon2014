(function() {

    var enums = {
        ticketStatuses: [{ name: "New", id: "0" }, { name: "In Progress", id: "1" }, { name: "Closed", id: "2" }],
        ticketPriorities: [{ name: "Low", id: "0" }, { name: "Medium", id: "1" }, { name: "High", id: "2" }]
    };

    getItDone.app.constant("enums", enums);
}());