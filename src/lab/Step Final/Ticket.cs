using System;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public TicketStatus Status { get; set; }
}

public enum TicketStatus
{
    New,
    InProgress,
    Done
}