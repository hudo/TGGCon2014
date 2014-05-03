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
                        Created = c.DateTime(nullable: false),
                        Content = c.String(),
                        TicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketNoteId)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: false)
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
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.TicketNotes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNotes", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.TicketNotes", new[] { "TicketId" });
            DropIndex("dbo.TicketNotes", new[] { "CreatedById" });
            DropIndex("dbo.Tickets", new[] { "CreatedById" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.TicketNotes");
            DropTable("dbo.Tickets");
        }
    }
}
