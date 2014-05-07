using System;

namespace GetItDone.Domain
{
    public class TicketNote
    {
        public TicketNote()
        {
            
        }

        public int TicketNoteId { get; set; }
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}