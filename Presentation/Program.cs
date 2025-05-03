using DataAcces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>();

builder.Services.AddCustomCookieAuthentication();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting(); 

app.UseAuthentication(); 

app.UseAuthorization();

app.UseCookiePolicy();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authorization}/{action=Authorization}/{id?}"
);


app.Run();