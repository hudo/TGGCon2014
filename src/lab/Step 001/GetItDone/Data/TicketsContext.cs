using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq.Expressions;
using System.Reflection;
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
                .ToTable("TicketNote")
                .HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);
                
            modelBuilder.Entity<Ticket>().Ignore(x => x.TicketNotes);
            modelBuilder.Entity<Ticket>().HasMany<Ticket, TicketNote>("_notes");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}