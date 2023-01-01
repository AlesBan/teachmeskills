using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication3.Models;

namespace WebApplication3.ActionFilters;

public class WeatherAuthorizationAttribute : Attribute, IAsyncActionFilter
{
    private string[] allowedRoles ;

    public WeatherAuthorizationAttribute(string roles)
    {
        allowedRoles = roles.Split(",");
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.HttpContext.Items.TryGetValue("user-auth", out var authenticatedUser))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }

        var user = authenticatedUser as WeatherUser;
        if (user != null && user.Role.Any(x => allowedRoles.Contains(x)))
        {
            await next();
        }
        context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
    }
}