using System.Security.Claims;
using AspAuth.Models;
using AspAuth.Policies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public static List<WeatherUser> Users = new List<WeatherUser>()
    {
        new WeatherUser()
        {
            UserName = "ales",
            Password = "admin",
            Role = new List<string>(new[] { "admin", "user" })
        }
    };

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }


    [HttpGet("get-weather-forecast")]
    [Authorize(Policy = NamePolicy.Policy)]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet("login")]
    public async Task Login([FromQuery] string userName)
    {
        var user = Users.Single(x => x.UserName == userName);
        var claims = user.Role.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        claims.Add(new Claim(ClaimTypes.Name, userName));

        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var userClaimsPrincipal = new ClaimsPrincipal(claimIdentity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userClaimsPrincipal);
    }
}