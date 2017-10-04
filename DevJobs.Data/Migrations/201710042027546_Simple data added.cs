namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Simpledataadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "ModifiedOn", c => c.DateTime());
            CreateIndex("dbo.Adverts", "User_Id");
            CreateIndex("dbo.AspNetUsers", "IsDeleted");
            AddForeignKey("dbo.Adverts", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adverts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "IsDeleted" });
            DropIndex("dbo.Adverts", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "ModifiedOn");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "DeletedOn");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.Adverts", "User_Id");
        }
    }
}
