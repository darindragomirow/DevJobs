namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalPropertiesAddedToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.Adverts", "Level_Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "Level_Type");
            DropColumn("dbo.Adverts", "Salary");
        }
    }
}
