namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthorToTheatrePlays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheatrePlays", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheatrePlays", "Author");
        }
    }
}
