using System;
using System.Collections.Generic;

namespace GetItDone.Domain
{
    public class Ticket
    {
        public Ticket()
        {
            _notes = new List<TicketNote>();
        }

        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; set; }

        protected ICollection<TicketNote> _notes { get; set; }
        public IEnumerable<TicketNote> TicketNotes
        {
            get { return _notes; }
        }

        public void AddTicket(User user, string content)
        {
            _notes.Add(new TicketNote(user.UserId, content));
        }
        
    }
}