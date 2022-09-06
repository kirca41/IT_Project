namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredFromPoster : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Poster", c => c.Binary());
            AlterColumn("dbo.TheatrePlays", "Poster", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TheatrePlays", "Poster", c => c.Binary(nullable: false));
            AlterColumn("dbo.Movies", "Poster", c => c.Binary(nullable: false));
        }
    }
}
