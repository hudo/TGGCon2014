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
                        TicketPriority = c.Int(nullable: false),
                        TicketStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId);
            
            CreateTable(
                "dbo.TicketNote",
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
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketNote", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNote", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.TicketNote", new[] { "TicketId" });
            DropIndex("dbo.TicketNote", new[] { "CreatedById" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.TicketNote");
            DropTable("dbo.Tickets");
        }
    }
}
