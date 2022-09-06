namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInfoClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        TicketsGiven = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TheatrePlayInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TheatrePlayId = c.Int(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        TicketsGiven = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TheatrePlayInfoes");
            DropTable("dbo.MovieInfoes");
        }
    }
}
