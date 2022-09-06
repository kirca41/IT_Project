namespace IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Director", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Cast", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Cast", c => c.String());
            AlterColumn("dbo.Movies", "Director", c => c.String());
        }
    }
}
