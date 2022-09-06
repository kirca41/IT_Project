namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.TheatrePlays", "Director", c => c.String(nullable: false));
            AlterColumn("dbo.TheatrePlays", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.TheatrePlays", "Cast", c => c.String(nullable: false));
            AlterColumn("dbo.TheatrePlays", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.TheatrePlays", "Poster", c => c.Binary(nullable: false));
            AlterColumn("dbo.TheatrePlays", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.TheatrePlays", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TheatrePlays", "Description", c => c.String());
            AlterColumn("dbo.TheatrePlays", "Title", c => c.String());
            AlterColumn("dbo.TheatrePlays", "Poster", c => c.Binary());
            AlterColumn("dbo.TheatrePlays", "Genre", c => c.String());
            AlterColumn("dbo.TheatrePlays", "Cast", c => c.String());
            AlterColumn("dbo.TheatrePlays", "Author", c => c.String());
            AlterColumn("dbo.TheatrePlays", "Director", c => c.String());
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
