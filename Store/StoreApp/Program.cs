
using StoreApp.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
        .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryResitration();
builder.Services.ConfigureServiceResitration();
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
        endpoints.MapAreaControllerRoute(
               name: "Admin",
               areaName: "Admin",
               pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );

        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

        endpoints.MapRazorPages();

        endpoints.MapControllers();

});

app.ConfifureAndCheckMigration();
app.ConfifureLocalization();
app.ConfigureDefaultAdminUser();

app.Run();
