using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuth.Models;
using JWTAuth.Policies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuth.Controllers;

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
    private readonly string _securitykey;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _securitykey = configuration["JWTSecurityKey"];
    }

    [HttpGet(Name = "GetWeatherForecast")]
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
    public string Login([FromQuery] string userName)
    {
        var user = Users.Single(x => x.UserName == userName);
        var claims = user.Role.Select(x => new Claim(ClaimTypes.Role, x)).ToList(); //Выдаем пользователю роль под видом клейма
        claims.Add(new Claim(ClaimTypes.Name, userName));

        var claimIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
        var userClaimsPrincipal = new ClaimsPrincipal(claimIdentity);

        var tokenDescr = new SecurityTokenDescriptor()
        {
            Expires = DateTime.Now.AddDays(7),
            Subject = claimIdentity,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_securitykey)), 
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token =  tokenHandler.CreateToken(tokenDescr);
        return tokenHandler.WriteToken(token);
    }
}
