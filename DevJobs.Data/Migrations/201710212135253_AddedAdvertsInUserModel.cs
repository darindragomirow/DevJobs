namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdvertsInUserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adverts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Adverts", new[] { "User_Id" });
            CreateTable(
                "dbo.UserAdverts",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Advert_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Advert_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Adverts", t => t.Advert_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Advert_Id);
            
            DropColumn("dbo.Adverts", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.UserAdverts", "Advert_Id", "dbo.Adverts");
            DropForeignKey("dbo.UserAdverts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserAdverts", new[] { "Advert_Id" });
            DropIndex("dbo.UserAdverts", new[] { "User_Id" });
            DropTable("dbo.UserAdverts");
            CreateIndex("dbo.Adverts", "User_Id");
            AddForeignKey("dbo.Adverts", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
