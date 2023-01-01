namespace AspAuth.Models;

public class WeatherUser
{
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public List<string> Role { get; set; }
}