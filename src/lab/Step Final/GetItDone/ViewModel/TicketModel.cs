﻿using System;
using System.Collections.Generic;
using GetItDone.Domain;

namespace GetItDone.ViewModel
{
    public class TicketModel
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public string CreatedBy { get; set; }
    }

    public class NoteModel
    {
        public int TicketNoteId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
    }
}