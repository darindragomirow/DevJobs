namespace DevJobs.Data.Migrations
{
    using DevJobs.Models;
    using DevJobs.Models.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DevJobs.Data.MsSqlDbContext>
    {

        private const string AdministratorUserName = "info@devjobs.bg";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;

        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedUsers(context);
            this.SeedSampleData(context);

            base.Seed(context);
        }

        private void SeedUsers(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedSampleData(MsSqlDbContext context)
        {
            if (!context.Adverts.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var advert = new Advert()
                    {
                        Title = "Advert " + i,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet lobortis nibh. Nullam bibendum, tortor quis porttitor fringilla, eros risus consequat orci, at scelerisque mauris dolor sit amet nulla. Vivamus turpis lorem, pellentesque eget enim ut, semper faucibus tortor. Aenean malesuada laoreet lorem.",
                        CreatedOn = DateTime.Now,
                    };

                    context.Adverts.Add(advert);
                }
            }

            if (!context.Cities.Any())
            {
                City city1 = new City() { Name = "Plovdiv" };
                City city2 = new City() { Name = "Sofiq" };
                City city3 = new City() { Name = "Burgas" };

                context.Cities.Add(city1);
                context.Cities.Add(city2);
                context.Cities.Add(city3);

            }


            if (!context.Countries.Any())
            {
                Country country1 = new Country() { Name = "Bulgaria" };
                Country country2 = new Country() { Name = "Foreign Country" };

                context.Countries.Add(country1);
                context.Countries.Add(country2);
            }

            if (!context.Companies.Any())
            {
                Company company1 = new Company() { Name = "SAP" };
                Company company2 = new Company() { Name = "Progress" };
                Company company3 = new Company() { Name = "Telerik" };
                Company company4 = new Company() { Name = "Accedia" };
                Company company5 = new Company() { Name = "eCommera" };


                context.Companies.Add(company1);
                context.Companies.Add(company2);
                context.Companies.Add(company3);
                context.Companies.Add(company4);
                context.Companies.Add(company5);
            }

            if (!context.Technologies.Any())
            {
                Technology technology1 = new Technology() { Type = "ASP.NET Developer" };
                Technology technology2 = new Technology() { Type = "Java Developer" };
                Technology technology3 = new Technology() { Type = "Quality Assurance" };
                Technology technology4 = new Technology() { Type = "Front-end Developer" };
                Technology technology5 = new Technology() { Type = "SQL Developer" };

                context.Technologies.Add(technology1);
                context.Technologies.Add(technology2);
                context.Technologies.Add(technology3);
                context.Technologies.Add(technology4);
                context.Technologies.Add(technology5);
            }

            if (!context.Levels.Any())
            {
                Level level1 = new Level() { Type = "Junior" };
                Level level2 = new Level() { Type = "Regular" };
                Level level3 = new Level() { Type = "Senior" };

                context.Levels.Add(level1);
                context.Levels.Add(level2);
                context.Levels.Add(level3);
            }
        }
    }
}
