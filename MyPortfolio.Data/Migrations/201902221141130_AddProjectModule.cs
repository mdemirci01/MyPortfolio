namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectModule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ShortDescription = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                        Technology = c.String(nullable: false, maxLength: 500),
                        Photo = c.String(maxLength: 200),
                        Year = c.Int(nullable: false),
                        GithubLink = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
