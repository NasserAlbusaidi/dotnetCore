using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly String[] Cities = new[]
    {
        "New York", "London", "Paris", "Berlin", "Madrid", "Rome", "Barcelona", "Budapest", "Vienna", "Warsaw"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {

            Id = index,
            Date = DateTime.Now.AddDays(index),
            City =  Cities[Random.Shared.Next(Cities.Length)],
            TemperatureC = Random.Shared.Next(-20, 55),
            // brief = brief
           
        })
        .ToArray();
    }


    [HttpGet("{id}", Name = "GetWeatherForecastById")]
    public WeatherForecast Get(int id)
    {
        return new WeatherForecast
        {
            Id = id,
            Date = DateTime.Now.AddDays(id),
            City = Cities[Random.Shared.Next(Cities.Length)],
            TemperatureC = Random.Shared.Next(-20, 55),
            
        };
    }

    [HttpPost(Name = "CreateWeatherForecast")]
    public IActionResult Create([FromBody] WeatherForecast weatherForecast)
    {
        if (weatherForecast.Id == 0)
        {
            return StatusCode(401,  new { message = "WeatherForecast Id is required" });
        }

        

       return StatusCode(201,  new { 
        message = "WeatherForecast created successfully",
        weatherForecast
        });
    

    }

    //delete 

    [HttpDelete("{id}", Name = "DeleteWeatherForecast")]

    public IActionResult Delete(int id)
    {
        if (id == 0)
        {
            return StatusCode(401, new { message = "WeatherForecast Id is required" });
        }

        return StatusCode(200, new
        {
            message = "WeatherForecast deleted successfully",
            id,
            
        });
    }
}
