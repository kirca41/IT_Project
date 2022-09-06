namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPosterFieldToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Poster", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Poster");
        }
    }
}
