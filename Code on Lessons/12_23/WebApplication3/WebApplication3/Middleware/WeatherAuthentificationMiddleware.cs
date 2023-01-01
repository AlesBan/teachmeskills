using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3.Middleware;

public class WeatherAuthentificationMiddleware : IMiddleware
{
    private readonly IDataProtectionProvider _provider;

    public WeatherAuthentificationMiddleware(IDataProtectionProvider provider)
    {
        _provider = provider;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Query.TryGetValue("auth", out var key))
        {
            var protector = _provider.CreateProtector("weather-auth");
            var deencreptedKey = protector.Unprotect(key);

            var actualUser = JsonConvert.DeserializeObject<WeatherUser>(deencreptedKey);
            WeatherForecastController.Users.SingleOrDefault(x => x.UserName == actualUser.UserName);
            context.Items.Add("user-auth", actualUser); 
        }

        await next(context);
    }
}