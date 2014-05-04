using System;

namespace GetItDone.Domain
{
    public class TicketNote
    {
        public TicketNote(Ticket ticket, User createdBy, string content)
        {
            CreatedById = createdBy.UserId;
            CreatedBy = createdBy;
            Ticket = ticket;
            TicketId = ticket.TicketId;
            Content = content;
            Created = DateTime.Now;
        }

        protected TicketNote()
        {
            
        }

        public int TicketNoteId { get; private set; }
        public int CreatedById { get; private set; }
        public virtual User CreatedBy { get; protected set; }
        public DateTime Created { get; protected set; }
        public string Content { get; set; }

        public int TicketId { get; protected set; }
        public virtual Ticket Ticket { get; protected set; }
    }
}