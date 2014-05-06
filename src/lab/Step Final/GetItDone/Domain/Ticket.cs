using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetItDone.Domain
{
    public class Ticket
    {
        private readonly Dictionary<TicketStatus, TicketStatus[]> _stateTransitionRules = new Dictionary<TicketStatus, TicketStatus[]>()
        {
            {TicketStatus.New,  new []{ TicketStatus.InProgress, TicketStatus.Closed }},
            {TicketStatus.InProgress,  new []{ TicketStatus.Closed }},
            {TicketStatus.Closed, new TicketStatus[]{} }
        }; 

        protected Ticket()
        {
            _notes = new Collection<TicketNote>();
        }

        public Ticket(string title, TicketPriority priority, User createdBy)
        {
            if(!createdBy.Is<CustomerSupport>())
                throw new Exception("This user is not customer support!");

            CreatedBy = createdBy;

            Title = title;
            TicketPriority = priority;
            _notes = new Collection<TicketNote>();

            TicketStatus = TicketStatus.New;
            Created = DateTime.Now;
        }

        public int TicketId { get; protected set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; protected set; }
        public int CreatedById { get; protected set; }
        public virtual User CreatedBy { get; protected set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; protected set; }

        protected virtual ICollection<TicketNote> _notes { get; set; }

        public IEnumerable<TicketNote> TicketNotes
        {
            get
            {
                return _notes.ToList();
            }
        }

        public void AddNote(User user, string content)
        {
            _notes.Add(new TicketNote(this, user, content));
        }

        public void ChangeStatus(TicketStatus newStatus)
        {
            if (_stateTransitionRules[this.TicketStatus].Contains(newStatus))
            {
                this.TicketStatus = newStatus;

                if (newStatus == TicketStatus.Closed)
                {
                    Closed = DateTime.Now;
                }
            }
            else
            {
                throw new Exception("Can't change status from " + this.TicketStatus + " to " + newStatus);
            }
        }
    }
}