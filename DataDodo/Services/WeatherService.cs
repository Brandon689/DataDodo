    using DataDodo.Api.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace DataDodo.Api.Services
{
    public interface IWeatherService
    {
        WeatherForecast[] GetForecasts();
    }

    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger = null)
        {
            _logger = logger ?? NullLogger<WeatherService>.Instance;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast[] GetForecasts()
        {
            _logger.LogInformation("Generating weather forecast");

            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
                .ToArray();

            _logger.LogInformation("Generated {Count} weather forecasts", forecast.Length);

            return forecast;
        }
    }
}
