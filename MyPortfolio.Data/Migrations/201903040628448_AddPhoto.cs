namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Photo");
        }
    }
}
