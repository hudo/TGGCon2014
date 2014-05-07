using System;
using System.Collections.Generic;

namespace GetItDone.Domain
{
    public class Ticket
    {
        public Ticket()
        {
         
        }

       
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; set; }

        public virtual ICollection<TicketNote> TicketNotes { get; set; }
    }
}