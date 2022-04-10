using EventiaWebapp.Data;
using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<DbInitializer>();
builder.Services.AddScoped<EventsHandler>();
builder.Services.AddScoped<OrganizerHandler>();

//builder.Services.AddSingleton<EventHandler>();

builder.Services.AddDbContext<EventiaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EventiaDbContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EventiaDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    /*var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EventiaDbContext>();  */
    var database = scope.ServiceProvider
        .GetRequiredService<DbInitializer>();

    if (app.Environment.IsProduction())
    {
        await database.CreateIfNotExist();
    }

    if (app.Environment.IsDevelopment())
    {
        await database.CreateAndSeedIfNotExist();
    }
    // DbInitializer.Initialize(context);
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "events",
    pattern: "event/events/",
    new { controller = "Event", action = "Events" });

app.MapControllerRoute(
    name: "events",
    pattern: "event/myevents/",
    new { controller = "Event", action = "MyEvents" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Event}/{action=index}");
app.MapRazorPages();


app.Run();
