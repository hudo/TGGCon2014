using System.Data.Entity;
using GetItDone.Domain;
using GetItDone.Infrastructure;

namespace GetItDone.Data
{
    public class TicketsContext : DbContext
    {
        public IDbSet<Ticket> Tickets { get; set; }
        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketNote>()
                .HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);
                
            modelBuilder.Entity<Ticket>()
                .ToTable("Tickets")
                .HasMany<Ticket, TicketNote>("_notes");

            modelBuilder.Entity<Ticket>()
                .HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);

            base.OnModelCreating(modelBuilder);
        }
    }
}