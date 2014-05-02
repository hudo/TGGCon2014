﻿using System;
using System.Collections.Generic;
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

        private Ticket()
        {
            
        }

        public Ticket(string title, TicketPriority priority, User createdBy)
        {
            if(!createdBy.Is<CustomerSupport>())
                throw new Exception("This user is not customer support!");

            Title = title;
            TicketPriority = priority;
            _notes = new List<TicketNote>();
        }

        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public virtual User CreatedBy { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; private set; }

        protected virtual ICollection<TicketNote> _notes { get; set; }
        public IEnumerable<TicketNote> TicketNotes
        {
            get { return _notes; }
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
            }
            else
            {
                throw new Exception("Can't change status from " + this.TicketStatus + " to " + newStatus);
            }
        }
        
    }
}