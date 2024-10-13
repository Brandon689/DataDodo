using DataDodo.Api.Models;
using System.Net;
using System.Net.Http.Json;

namespace DataDodo.IntegrationTests.Tests
{
    public class WeatherForecastEndpointTests : IntegrationTestBase
    {
        public WeatherForecastEndpointTests(IntegrationTestFixture fixture) : base(fixture) { }

        [Fact]
        public async Task GetWeatherForecast_ReturnsSuccessStatusCode()
        {
            // Arrange
            // Act
            var response = await HttpClientWrapper.GetAsync("/weatherforecast");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetWeatherForecast_ReturnsWeatherForecastData()
        {
            // Arrange
            // Act
            var response = await HttpClientWrapper.GetAsync("/weatherforecast");
            var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

            // Assert
            Assert.NotNull(forecasts);
            Assert.NotEmpty(forecasts);
        }

        [Fact]
        public async Task GetWeatherForecast_ReturnsCorrectNumberOfForecasts()
        {
            // Arrange
            const int expectedCount = 5; // Assuming the default behavior returns 5 forecasts

            // Act
            var response = await HttpClientWrapper.GetAsync("/weatherforecast");
            var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

            // Assert
            Assert.Equal(expectedCount, forecasts.Count());
        }
    }
}
