namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedModelsforeignkeys : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adverts", "CityId");
            DropColumn("dbo.Adverts", "CountryId");
            DropColumn("dbo.Adverts", "CompanyId");
            DropColumn("dbo.Companies", "CountryId");
            DropColumn("dbo.Companies", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "CityId", c => c.Int());
            AddColumn("dbo.Companies", "CountryId", c => c.Int());
            AddColumn("dbo.Adverts", "CompanyId", c => c.Int());
            AddColumn("dbo.Adverts", "CountryId", c => c.Int());
            AddColumn("dbo.Adverts", "CityId", c => c.Int());
        }
    }
}
