namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdFieldTicketModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieReservations", "Info_Id", "dbo.MovieInfoes");
            DropForeignKey("dbo.MovieTicketPurchases", "Info_Id", "dbo.MovieInfoes");
            DropForeignKey("dbo.TheatrePlayReservations", "Info_Id", "dbo.TheatrePlayInfoes");
            DropForeignKey("dbo.TheatrePlayTicketPurchases", "Info_Id", "dbo.TheatrePlayInfoes");
            DropIndex("dbo.MovieReservations", new[] { "Info_Id" });
            DropIndex("dbo.MovieTicketPurchases", new[] { "Info_Id" });
            DropIndex("dbo.TheatrePlayReservations", new[] { "Info_Id" });
            DropIndex("dbo.TheatrePlayTicketPurchases", new[] { "Info_Id" });
            RenameColumn(table: "dbo.MovieReservations", name: "Info_Id", newName: "MovieInfoId");
            RenameColumn(table: "dbo.MovieTicketPurchases", name: "Info_Id", newName: "MovieInfoId");
            RenameColumn(table: "dbo.TheatrePlayReservations", name: "Info_Id", newName: "TheatrePlayInfoId");
            RenameColumn(table: "dbo.TheatrePlayTicketPurchases", name: "Info_Id", newName: "TheatrePlayInfoId");
            AlterColumn("dbo.MovieReservations", "MovieInfoId", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieTicketPurchases", "MovieInfoId", c => c.Int(nullable: false));
            AlterColumn("dbo.TheatrePlayReservations", "TheatrePlayInfoId", c => c.Int(nullable: false));
            AlterColumn("dbo.TheatrePlayTicketPurchases", "TheatrePlayInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieReservations", "MovieInfoId");
            CreateIndex("dbo.MovieTicketPurchases", "MovieInfoId");
            CreateIndex("dbo.TheatrePlayReservations", "TheatrePlayInfoId");
            CreateIndex("dbo.TheatrePlayTicketPurchases", "TheatrePlayInfoId");
            AddForeignKey("dbo.MovieReservations", "MovieInfoId", "dbo.MovieInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieTicketPurchases", "MovieInfoId", "dbo.MovieInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TheatrePlayReservations", "TheatrePlayInfoId", "dbo.TheatrePlayInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TheatrePlayTicketPurchases", "TheatrePlayInfoId", "dbo.TheatrePlayInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TheatrePlayTicketPurchases", "TheatrePlayInfoId", "dbo.TheatrePlayInfoes");
            DropForeignKey("dbo.TheatrePlayReservations", "TheatrePlayInfoId", "dbo.TheatrePlayInfoes");
            DropForeignKey("dbo.MovieTicketPurchases", "MovieInfoId", "dbo.MovieInfoes");
            DropForeignKey("dbo.MovieReservations", "MovieInfoId", "dbo.MovieInfoes");
            DropIndex("dbo.TheatrePlayTicketPurchases", new[] { "TheatrePlayInfoId" });
            DropIndex("dbo.TheatrePlayReservations", new[] { "TheatrePlayInfoId" });
            DropIndex("dbo.MovieTicketPurchases", new[] { "MovieInfoId" });
            DropIndex("dbo.MovieReservations", new[] { "MovieInfoId" });
            AlterColumn("dbo.TheatrePlayTicketPurchases", "TheatrePlayInfoId", c => c.Int());
            AlterColumn("dbo.TheatrePlayReservations", "TheatrePlayInfoId", c => c.Int());
            AlterColumn("dbo.MovieTicketPurchases", "MovieInfoId", c => c.Int());
            AlterColumn("dbo.MovieReservations", "MovieInfoId", c => c.Int());
            RenameColumn(table: "dbo.TheatrePlayTicketPurchases", name: "TheatrePlayInfoId", newName: "Info_Id");
            RenameColumn(table: "dbo.TheatrePlayReservations", name: "TheatrePlayInfoId", newName: "Info_Id");
            RenameColumn(table: "dbo.MovieTicketPurchases", name: "MovieInfoId", newName: "Info_Id");
            RenameColumn(table: "dbo.MovieReservations", name: "MovieInfoId", newName: "Info_Id");
            CreateIndex("dbo.TheatrePlayTicketPurchases", "Info_Id");
            CreateIndex("dbo.TheatrePlayReservations", "Info_Id");
            CreateIndex("dbo.MovieTicketPurchases", "Info_Id");
            CreateIndex("dbo.MovieReservations", "Info_Id");
            AddForeignKey("dbo.TheatrePlayTicketPurchases", "Info_Id", "dbo.TheatrePlayInfoes", "Id");
            AddForeignKey("dbo.TheatrePlayReservations", "Info_Id", "dbo.TheatrePlayInfoes", "Id");
            AddForeignKey("dbo.MovieTicketPurchases", "Info_Id", "dbo.MovieInfoes", "Id");
            AddForeignKey("dbo.MovieReservations", "Info_Id", "dbo.MovieInfoes", "Id");
        }
    }
}
