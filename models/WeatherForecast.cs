namespace TodoApi;


public class WeatherForecast
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary => TemperatureC > 35 ? "Hot" : "cold";

    public string? City { get; set; }


    public string? brief {
        get
        {
        return $"The weather in {City} on {Date} is {Summary} with a temperature of {TemperatureC}C";
        }

        set
        {
            brief = value;
        }
    }
}


