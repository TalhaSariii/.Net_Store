using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructe.Extensions
{
    public static class  WebApplicationExtension
    {
        public static void ConfifureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context=app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }            
        }
    }
    
}