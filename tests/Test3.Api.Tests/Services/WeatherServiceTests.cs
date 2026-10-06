using Test3.Api.Services;

namespace Test3.Api.Tests.Services;

public class WeatherServiceTests
{
    private readonly WeatherService _sut = new();

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(14)]
    public void GetForecast_ReturnsDaysEntries(int days)
    {
        var result = _sut.GetForecast(days).ToList();

        Assert.Equal(days, result.Count);
    }

    [Fact]
    public void GetForecast_DefaultDaysIsFive()
    {
        var result = _sut.GetForecast().ToList();

        Assert.Equal(5, result.Count);
    }

    [Fact]
    public void GetForecast_DatesAreAscending()
    {
        var result = _sut.GetForecast(3).ToList();

        Assert.True(result[0].Date < result[1].Date);
        Assert.True(result[1].Date < result[2].Date);
    }

    [Fact]
    public void GetForecast_TemperatureFIsCorrect()
    {
        var forecast = _sut.GetForecast(1).Single();
        var expectedF = 32 + (int)(forecast.TemperatureC / 0.5556);

        Assert.Equal(expectedF, forecast.TemperatureF);
    }
}
