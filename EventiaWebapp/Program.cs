var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

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
