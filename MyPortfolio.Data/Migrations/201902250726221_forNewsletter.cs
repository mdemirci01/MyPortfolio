namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forNewsletter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 100),
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
            DropTable("dbo.Newsletters");
        }
    }
}
