namespace Test3.Api.Models;

/// <summary>A single weather forecast entry.</summary>
public record WeatherForecast(
    DateOnly Date,
    int TemperatureC,
    string? Summary)
{
    /// <summary>Temperature in Fahrenheit, derived from Celsius.</summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
