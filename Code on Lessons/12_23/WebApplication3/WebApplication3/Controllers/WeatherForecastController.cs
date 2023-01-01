using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.ActionFilters;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public static List<WeatherUser> Users = new List<WeatherUser>()
    {
        new WeatherUser()
        {
            UserName = "admin",
            Password = "admin",
            Role = new List<string>(new[] { "admin", "user" })
        }
    };

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IDataProtectionProvider _provider;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IDataProtectionProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }


    [HttpGet(Name = "GetWeatherForecast")]
    [WeatherAuthorization("suoerad")]
    public ActionResult<IEnumerable<WeatherForecast>> Get([FromQuery] string auth)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet("users")]
    //Only admin users
    public ActionResult<IEnumerable<WeatherUser>> GetUsers([FromQuery] string auth)
    {
        if (auth != null)
        {
            return Unauthorized();
        }

        WeatherUser user;
        try
        {
            user = Authentificate(auth);
        }
        catch (Exception e)
        {
            return Unauthorized();
        }

        if (user != null && user.Role.Contains("admin"))
        {
            return Users;
        }

        return Unauthorized();
    }

    [HttpPost("rigister")]
    public IActionResult Register([FromQuery] string Name, [FromQuery] string pwd)
    {
        if (Users.Any(x => x.UserName == Name))
        {
            return BadRequest();
        }

        var userInfo = new WeatherUser()
        {
            UserName = Name,
            Password = pwd,
            Role = new List<string>(new[] { "user" })
        };
        Users.Add(userInfo);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromQuery] string UserName, [FromQuery] string pwd)
    {
        var userInfo = Users.SingleOrDefault(x => x.UserName == UserName && x.Password == pwd);
        if (userInfo != null)
        {
            var key = JsonConvert.SerializeObject(userInfo);
            var protector = _provider.CreateProtector("weather-auth");
            var encreptedKey = protector.Protect(key);
            return encreptedKey;
        }

        return Unauthorized();
    }

    private WeatherUser Authentificate(string key)
    {
        var protector = _provider.CreateProtector("weather-auth");
        var deencreptedKey = protector.Unprotect(key);
        return JsonConvert.DeserializeObject<WeatherUser>(deencreptedKey);
    }
}