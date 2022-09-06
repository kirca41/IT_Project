namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFieldTicketModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieReservations", "UserEmail", c => c.String());
            AddColumn("dbo.MovieTicketPurchases", "UserEmail", c => c.String());
            AddColumn("dbo.TheatrePlayReservations", "UserEmail", c => c.String());
            AddColumn("dbo.TheatrePlayTicketPurchases", "UserEmail", c => c.String());
            DropColumn("dbo.MovieReservations", "UserId");
            DropColumn("dbo.MovieTicketPurchases", "UserId");
            DropColumn("dbo.TheatrePlayReservations", "UserId");
            DropColumn("dbo.TheatrePlayTicketPurchases", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TheatrePlayTicketPurchases", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.TheatrePlayReservations", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.MovieTicketPurchases", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.MovieReservations", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.TheatrePlayTicketPurchases", "UserEmail");
            DropColumn("dbo.TheatrePlayReservations", "UserEmail");
            DropColumn("dbo.MovieTicketPurchases", "UserEmail");
            DropColumn("dbo.MovieReservations", "UserEmail");
        }
    }
}
