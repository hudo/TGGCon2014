using System;
using GetItDone.Infrastructure;

namespace GetItDone.Domain
{
    public class TicketNote
    {
        public TicketNote(int createdBy, string content)
        {
            CreatedById = createdBy;
            Content = content;
            Created = DateTime.Now;
        }

        private TicketNote()
        {
            
        }

        public int TicketNoteId { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string Content { get; set; }

        public int TicketId { get; private set; }
        public Ticket Ticket { get; private set; }
    }
}