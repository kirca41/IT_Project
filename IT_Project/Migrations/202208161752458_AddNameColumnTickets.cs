namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnTickets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieTicketPurchases", "CreditCardFullName", c => c.String(nullable: false));
            AddColumn("dbo.TheatrePlayTicketPurchases", "CreditCardFullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheatrePlayTicketPurchases", "CreditCardFullName");
            DropColumn("dbo.MovieTicketPurchases", "CreditCardFullName");
        }
    }
}
