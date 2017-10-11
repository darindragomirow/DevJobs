namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Adverts", "Level_Id", c => c.Guid());
            AddColumn("dbo.Adverts", "Technology_Id", c => c.Guid());
            CreateIndex("dbo.Adverts", "Level_Id");
            CreateIndex("dbo.Adverts", "Technology_Id");
            AddForeignKey("dbo.Adverts", "Level_Id", "dbo.Levels", "Id");
            AddForeignKey("dbo.Adverts", "Technology_Id", "dbo.Technologies", "Id");
            DropColumn("dbo.Adverts", "Level_Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "Level_Type", c => c.String());
            DropForeignKey("dbo.Adverts", "Technology_Id", "dbo.Technologies");
            DropForeignKey("dbo.Adverts", "Level_Id", "dbo.Levels");
            DropIndex("dbo.Technologies", new[] { "IsDeleted" });
            DropIndex("dbo.Levels", new[] { "IsDeleted" });
            DropIndex("dbo.Adverts", new[] { "Technology_Id" });
            DropIndex("dbo.Adverts", new[] { "Level_Id" });
            DropColumn("dbo.Adverts", "Technology_Id");
            DropColumn("dbo.Adverts", "Level_Id");
            DropTable("dbo.Technologies");
            DropTable("dbo.Levels");
        }
    }
}
