namespace SaclaApplication.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SaclaApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SaclaApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SaclaApplication.Models.ApplicationDbContext context)
        {
            //Create Default Roles
            RoleStore<IdentityRole> roleStore =
                new RoleStore<IdentityRole>(context);

            RoleManager<IdentityRole> roleManager =
                new RoleManager<IdentityRole>(roleStore);

            IdentityRole adminRole = new IdentityRole { Name = "Admin" };
            IdentityRole EmployeeRole = new IdentityRole { Name = "Author" };

            if (!roleManager.RoleExists(adminRole.Name))
                roleManager.Create(adminRole);

            if (!roleManager.RoleExists(EmployeeRole.Name))
                roleManager.Create(EmployeeRole);

            //Initialize default admin user
            ApplicationUser adminUser = new ApplicationUser
            {
                UserName = "admin@ctucareer.co.za",
                Email = "admin@ctucareer.co.za"
            };

            UserStore<ApplicationUser> userStore =
                new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(userStore);

            var results = userManager.Create(adminUser, "!Admin1");

            if (results.Succeeded)
                userManager.AddToRole(adminUser.Id, adminRole.Name);

            //Initialize tables in the contexts
            base.Seed(context);
        }
    }
}
