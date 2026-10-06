using Microsoft.AspNetCore.Mvc;
using Test3.Api.Models;
using Test3.Api.Services;

namespace Test3.Api.Controllers;

/// <summary>Weather forecast endpoints.</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class WeatherForecastController(IWeatherService weatherService) : ControllerBase
{
    /// <summary>Returns weather forecasts for the next N days.</summary>
    /// <param name="days">Number of forecast days (1–14). Defaults to 5.</param>
    /// <returns>A list of <see cref="WeatherForecast"/> objects.</returns>
    /// <response code="200">Forecasts returned successfully.</response>
    /// <response code="400">Invalid <paramref name="days"/> value.</response>
    [HttpGet]
    [ProducesResponseType<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<WeatherForecast>> Get([FromQuery] int days = 5)
    {
        if (days is < 1 or > 14)
            return BadRequest("days must be between 1 and 14.");

        return Ok(weatherService.GetForecast(days));
    }
}
