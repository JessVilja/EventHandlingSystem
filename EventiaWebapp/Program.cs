using EventiaWebapp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<DbInitializer>();

//builder.Services.AddSingleton<EventHandler>();

    builder.Services.AddDbContext<EventiaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EventiaDbContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EventiaDbContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DbInitializer>();
    await context.Initialize();
    // DbInitializer.Initialize(context);
}
app.UseRouting();


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



app.Run();
