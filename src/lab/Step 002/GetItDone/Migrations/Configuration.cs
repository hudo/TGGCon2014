using GetItDone.Domain;

namespace GetItDone.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GetItDone.Data.TicketsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GetItDone.Data.TicketsContext context)
        {
            var support = new CustomerSupport();

            var user = new User("demo", "demo");
            user.AddToRole(support);

            context.Users.AddOrUpdate(x => x.LastName, user);

            var ticket = new Ticket("test ticket", TicketPriority.Medium, user);
            ticket.AddNote(user, "some note");

            context.Tickets.AddOrUpdate(x=>x.Title, ticket);
        }
    }
}
