namespace DevJobs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeysToModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Adverts", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Adverts", name: "Company_Id", newName: "CompanyId");
            RenameColumn(table: "dbo.Adverts", name: "Country_Id", newName: "CountryId");
            RenameColumn(table: "dbo.Adverts", name: "Level_Id", newName: "LevelId");
            RenameColumn(table: "dbo.Adverts", name: "Technology_Id", newName: "TechnologyId");
            RenameColumn(table: "dbo.Companies", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Companies", name: "Country_Id", newName: "CountryId");
            RenameIndex(table: "dbo.Adverts", name: "IX_City_Id", newName: "IX_CityId");
            RenameIndex(table: "dbo.Adverts", name: "IX_Country_Id", newName: "IX_CountryId");
            RenameIndex(table: "dbo.Adverts", name: "IX_Company_Id", newName: "IX_CompanyId");
            RenameIndex(table: "dbo.Adverts", name: "IX_Technology_Id", newName: "IX_TechnologyId");
            RenameIndex(table: "dbo.Adverts", name: "IX_Level_Id", newName: "IX_LevelId");
            RenameIndex(table: "dbo.Companies", name: "IX_Country_Id", newName: "IX_CountryId");
            RenameIndex(table: "dbo.Companies", name: "IX_City_Id", newName: "IX_CityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Companies", name: "IX_CityId", newName: "IX_City_Id");
            RenameIndex(table: "dbo.Companies", name: "IX_CountryId", newName: "IX_Country_Id");
            RenameIndex(table: "dbo.Adverts", name: "IX_LevelId", newName: "IX_Level_Id");
            RenameIndex(table: "dbo.Adverts", name: "IX_TechnologyId", newName: "IX_Technology_Id");
            RenameIndex(table: "dbo.Adverts", name: "IX_CompanyId", newName: "IX_Company_Id");
            RenameIndex(table: "dbo.Adverts", name: "IX_CountryId", newName: "IX_Country_Id");
            RenameIndex(table: "dbo.Adverts", name: "IX_CityId", newName: "IX_City_Id");
            RenameColumn(table: "dbo.Companies", name: "CountryId", newName: "Country_Id");
            RenameColumn(table: "dbo.Companies", name: "CityId", newName: "City_Id");
            RenameColumn(table: "dbo.Adverts", name: "TechnologyId", newName: "Technology_Id");
            RenameColumn(table: "dbo.Adverts", name: "LevelId", newName: "Level_Id");
            RenameColumn(table: "dbo.Adverts", name: "CountryId", newName: "Country_Id");
            RenameColumn(table: "dbo.Adverts", name: "CompanyId", newName: "Company_Id");
            RenameColumn(table: "dbo.Adverts", name: "CityId", newName: "City_Id");
        }
    }
}
