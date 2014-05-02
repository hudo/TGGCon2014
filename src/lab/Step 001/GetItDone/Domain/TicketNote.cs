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

        private TicketNote()
        {
            
        }

        public int TicketNoteId { get; set; }
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string Content { get; set; }

        public int TicketId { get; private set; }
        public virtual Ticket Ticket { get; private set; }
    }
}