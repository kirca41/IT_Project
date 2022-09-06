namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTicketModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        ReservationCount = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Info_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieInfoes", t => t.Info_Id)
                .Index(t => t.Info_Id);
            
            CreateTable(
                "dbo.MovieTicketPurchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        TicketsCount = c.Int(nullable: false),
                        Info_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieInfoes", t => t.Info_Id)
                .Index(t => t.Info_Id);
            
            CreateTable(
                "dbo.TheatrePlayReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        ReservationCount = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Info_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TheatrePlayInfoes", t => t.Info_Id)
                .Index(t => t.Info_Id);
            
            CreateTable(
                "dbo.TheatrePlayTicketPurchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        TicketsCount = c.Int(nullable: false),
                        Info_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TheatrePlayInfoes", t => t.Info_Id)
                .Index(t => t.Info_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TheatrePlayTicketPurchases", "Info_Id", "dbo.TheatrePlayInfoes");
            DropForeignKey("dbo.TheatrePlayReservations", "Info_Id", "dbo.TheatrePlayInfoes");
            DropForeignKey("dbo.MovieTicketPurchases", "Info_Id", "dbo.MovieInfoes");
            DropForeignKey("dbo.MovieReservations", "Info_Id", "dbo.MovieInfoes");
            DropIndex("dbo.TheatrePlayTicketPurchases", new[] { "Info_Id" });
            DropIndex("dbo.TheatrePlayReservations", new[] { "Info_Id" });
            DropIndex("dbo.MovieTicketPurchases", new[] { "Info_Id" });
            DropIndex("dbo.MovieReservations", new[] { "Info_Id" });
            DropTable("dbo.TheatrePlayTicketPurchases");
            DropTable("dbo.TheatrePlayReservations");
            DropTable("dbo.MovieTicketPurchases");
            DropTable("dbo.MovieReservations");
        }
    }
}
