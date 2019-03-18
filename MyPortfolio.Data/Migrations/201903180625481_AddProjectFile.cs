namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectFiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        ProjectId = c.Guid(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectFiles", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectFiles", new[] { "ProjectId" });
            DropTable("dbo.ProjectFiles");
        }
    }
}
