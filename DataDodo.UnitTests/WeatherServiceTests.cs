using DataDodo.Api.Services;

namespace DataDodo.UnitTests;

public class WeatherServiceTests
{
    [Fact]
    public void GetForecasts_ReturnsFiveForecasts()
    {
        // Arrange
        var weatherService = new WeatherService();

        // Act
        var result = weatherService.GetForecasts();

        // Assert
        Assert.Equal(5, result.Length);
    }

    [Fact]
    public void GetForecasts_ReturnsValidTemperatures()
    {
        // Arrange
        var weatherService = new WeatherService();

        // Act
        var result = weatherService.GetForecasts();

        // Assert
        Assert.All(result, forecast => Assert.InRange(forecast.TemperatureC, -20, 55));
    }

    [Fact]
    public void GetForecasts_ReturnsValidDates()
    {
        // Arrange
        var weatherService = new WeatherService();

        // Act
        var result = weatherService.GetForecasts();

        // Assert
        Assert.All(result, forecast => Assert.True(forecast.Date > DateOnly.FromDateTime(DateTime.Now)));
    }

    [Fact]
    public void GetForecasts_ReturnsSummaries()
    {
        // Arrange
        var weatherService = new WeatherService();

        // Act
        var result = weatherService.GetForecasts();

        // Assert
        Assert.All(result, forecast => Assert.False(string.IsNullOrEmpty(forecast.Summary)));
    }
}