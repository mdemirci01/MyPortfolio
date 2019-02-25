namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTechnologyModule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "TechnologyId", c => c.Guid());
            CreateIndex("dbo.Projects", "TechnologyId");
            AddForeignKey("dbo.Projects", "TechnologyId", "dbo.Technologies", "Id");
            DropColumn("dbo.Projects", "Technology");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Technology", c => c.String(nullable: false, maxLength: 500));
            DropForeignKey("dbo.Projects", "TechnologyId", "dbo.Technologies");
            DropIndex("dbo.Projects", new[] { "TechnologyId" });
            DropColumn("dbo.Projects", "TechnologyId");
            DropTable("dbo.Technologies");
        }
    }
}
