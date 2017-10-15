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
                company1.Rating = 2;
                company1.Description = "As the market leader in enterprise application software, SAP is at the center of today’s business and technology revolution. SAP helps you streamline your processes, giving you the ability to use live data to predict customer trends – live and in the moment. Across your entire business. When you run live, you run simple with SAP.";
                Company company2 = new Company() { Name = "Progress" };
                company2.Rating = 4;
                company2.Description = "Progress has always delivered the platform and tools that organizations need to develop and deploy mission-critical business applications.  As the types of devices and types of interfaces on which applications run proliferate, the number of systems that need to be connected rises, and the amount of data that needs to be harnessed continues to skyrocket, organizations are looking for a modern platform that will enable them to quickly and easily develop and deliver tomorrow’s applications.";
                Company company3 = new Company() { Name = "Telerik" };
                company3.Rating = 5;
                company3.Description = "Progress is committed to giving developers the tools they need to harness and master the technological evolution shaping our society and the world. From innovative approaches to native, web and hybrid development, to time-saving tooling and testing products, developers rely on the quality and dependability of Progress to create transformative experiences";
                Company company4 = new Company() { Name = "Accedia" };
                company4.Rating = 3;
                company4.Description = "Accedia is a Professional IT Services company specializing in consulting, software development outsourcing and complex end-to-end solutions for both SMEs and large enterprises. Our customer base includes leading financial institutions and banks, Fortune 100 IT corporations, multinational telecoms, large logistics and utilities companies, as well as innovative technology startups.";
                Company company5 = new Company() { Name = "eCommera" };
                company5.Rating = 4;
                company5.Description = "eCommera, Linked by Isobar, is a commerce specialist that combines strategic, technology and operational support to deliver rapid growth for global brands and retailers. We are passionate about retail and that permeates everything that we do - whether we are helping clients like Jimmy Choo develop an international strategy, working with Clarins to launch sites in over 25 markets, or putting our heads together with the team at Asda-Walmart to realise their next innovation.";
                Company company6 = new Company() { Name = "VMWare" };
                company6.Rating = 3;
                company6.Description = "Accelerate your digital transformation through a software-defined approach to business and IT. The trusted platform provider of choice for more than 500,000 customers globally, VMware is the pioneer in virtualization and an innovator in cloud and business mobility. A proven leader, we allow you to run, manage, connect and secure applications across clouds and devices in a common operating environment, so you get both freedom and control.";
                Company company7 = new Company() { Name = "Telus" };
                company7.Rating = 1;
                company7.Description = "TELUS International Europe is a premium multilingual contact center, BPO (business process outsourcing) and ITO (information technology outsourcing) provider, delivering high quality services since 2004. The company has 3,500 team members across seven delivery centers located in: Sofia and Plovdiv (Bulgaria); Bucharest and Craiova (Romania), as well as offices in Manchester and Cannock (England). TELUS International Europe offers contact center solutions, ITO and innovative customer service support for global customers in over 35+ languages. TELUS International Europe is a proud member of the TELUS International family.";



                context.Companies.Add(company1);
                context.Companies.Add(company2);
                context.Companies.Add(company3);
                context.Companies.Add(company4);
                context.Companies.Add(company5);
                context.Companies.Add(company6);
                context.Companies.Add(company7);
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
