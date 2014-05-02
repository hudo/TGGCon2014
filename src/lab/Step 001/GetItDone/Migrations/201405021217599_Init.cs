namespace GetItDone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        Closed = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        TicketPriority = c.Int(nullable: false),
                        TicketStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.TicketNotes",
                c => new
                    {
                        TicketNoteId = c.Int(nullable: false, identity: true),
                        CreatedById = c.Int(nullable: false),
                        Created = c.DateTime(),
                        Content = c.String(),
                        TicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketNoteId)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.CreatedById)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.TicketNotes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNotes", "CreatedById", "dbo.Users");
            DropIndex("dbo.TicketNotes", new[] { "TicketId" });
            DropIndex("dbo.TicketNotes", new[] { "CreatedById" });
            DropIndex("dbo.Tickets", new[] { "CreatedById" });
            DropTable("dbo.Users");
            DropTable("dbo.TicketNotes");
            DropTable("dbo.Tickets");
        }
    }
}
