using System.Data.Entity;
using GetItDone.Domain;

namespace GetItDone.Data
{
    public class TicketsContext : DbContext
    {
        public IDbSet<Ticket> Tickets { get; set; }
        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .Map(x=>x.MapLeftKey("UserId").MapRightKey("RoleId").ToTable("UserUserRoles"));

            modelBuilder.Entity<TicketNote>().ToTable("TicketNote");
               
            base.OnModelCreating(modelBuilder);
        }
    }
}