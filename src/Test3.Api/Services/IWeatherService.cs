using Test3.Api.Models;

namespace Test3.Api.Services;

/// <summary>Provides weather forecast data.</summary>
public interface IWeatherService
{
    /// <summary>Returns a list of weather forecasts for the next <paramref name="days"/> days.</summary>
    IEnumerable<WeatherForecast> GetForecast(int days = 5);
}
