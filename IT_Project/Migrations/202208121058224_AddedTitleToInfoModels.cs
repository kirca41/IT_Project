namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitleToInfoModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieInfoes", "Title", c => c.String());
            AddColumn("dbo.TheatrePlayInfoes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheatrePlayInfoes", "Title");
            DropColumn("dbo.MovieInfoes", "Title");
        }
    }
}
