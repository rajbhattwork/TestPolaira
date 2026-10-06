using Test3.Api.Models;

namespace Test3.Api.Services;

/// <inheritdoc />
public sealed class WeatherService : IWeatherService
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    /// <inheritdoc />
    public IEnumerable<WeatherForecast> GetForecast(int days = 5) =>
        Enumerable.Range(1, days).Select(i => new WeatherForecast(
            Date: DateOnly.FromDateTime(DateTime.UtcNow.AddDays(i)),
            TemperatureC: Random.Shared.Next(-20, 55),
            Summary: Summaries[Random.Shared.Next(Summaries.Length)]));
}
