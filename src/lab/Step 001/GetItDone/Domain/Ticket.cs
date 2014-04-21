using System;
using System.Collections.Generic;

namespace GetItDone.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public ICollection<TicketNote> TicketNotes { get; private set; }
    }
}