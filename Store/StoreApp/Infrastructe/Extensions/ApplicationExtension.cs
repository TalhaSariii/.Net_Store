using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructe.Extensions
{
    public static class WebApplicationExtension
    {
        public static void ConfifureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }


        public static void ConfifureLocalization(this WebApplication app)

        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }

        public static async void  ConfigureDefaultAdminUser(this IApplicationBuilder app )
        {
            const string adminUser="Admin";
            const string adminPassword="Admin@1234";

            UserManager<IdentityUser> userManager=app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();


            RoleManager<IdentityRole> roleManager=app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user=await userManager.FindByNameAsync(adminUser); 
            if(user is null)
            {
                user=new IdentityUser()
                {
                    Email="talha@gmail.com",
                    PhoneNumber="544",
                    UserName=adminUser,
                };
                var result=await userManager.CreateAsync(user,adminPassword);

                if(!result.Succeeded)
                    throw new Exception("Admin not created");

                var roleResult=await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r=>r.Name)
                        .ToList()
                );

                if(!roleResult.Succeeded)
                    throw new Exception("Problem n  ");
            }
        }
    }

}
