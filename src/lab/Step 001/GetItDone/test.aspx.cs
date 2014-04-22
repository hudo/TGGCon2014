using System;
using GetItDone.Data;
using GetItDone.Domain;

namespace GetItDone
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ticketsContext = new TicketsContext();

            var user = new User();
            user.FirstName = "ime";
            user.Roles.Add(new CustomerSupport());

            ticketsContext.Users.Add(user);

            var ticket = new Ticket();
            ticket.Created = DateTime.Now;
            ticketsContext.Tickets.Add(ticket);
            ticket.AddTicket(user,"blabla");

            ticketsContext.SaveChanges();
        }
    }
}