namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAttributesAddedToModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adverts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Adverts", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Levels", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Technologies", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Technologies", "Type", c => c.String());
            AlterColumn("dbo.Levels", "Type", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
            AlterColumn("dbo.Adverts", "Description", c => c.String());
            AlterColumn("dbo.Adverts", "Title", c => c.String());
        }
    }
}
