using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class CookieService
{
    public static void AddCustomCookieAuthentication(this IServiceCollection builder)
    {
        builder.AddAuthentication().AddCookie(options =>
        {
            options.LoginPath = "/Authorization/Authorization";
            options.AccessDeniedPath = "/Authorization/Authorization";
            options.ExpireTimeSpan = TimeSpan.FromDays(10); 
            options.SlidingExpiration = true;        
        });
    }
}