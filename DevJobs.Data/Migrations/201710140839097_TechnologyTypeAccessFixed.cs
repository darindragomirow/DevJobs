namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TechnologyTypeAccessFixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Technologies", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Technologies", "Type");
        }
    }
}
