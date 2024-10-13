using DataDodo.Api.Models;
using DataDodo.Api.Services;
using Moq;

namespace DataDodo.UnitTests;
public class WeatherForecastEndpointTests
{
    [Fact]
    public void WeatherForecastEndpoint_ReturnsForecasts()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        mockWeatherService.Setup(service => service.GetForecasts())
            .Returns(new WeatherForecast[]
            {
                new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 20, "Mild")
            });

        // Act
        var result = WeatherForecastEndpoint(mockWeatherService.Object);

        // Assert
        var forecasts = Assert.IsType<WeatherForecast[]>(result);
        Assert.Single(forecasts);
        Assert.Equal("Mild", forecasts[0].Summary);
    }

    // This method simulates your endpoint logic
    private static WeatherForecast[] WeatherForecastEndpoint(IWeatherService weatherService)
    {
        return weatherService.GetForecasts();
    }
}
