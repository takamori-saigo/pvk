using DataAcces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authorization}/{action=Authorization}/{id?}"
);

app.UseStaticFiles();
app.Run();