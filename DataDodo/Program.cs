using DataDodo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWeatherService, WeatherService>();

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (IWeatherService weatherService, ILogger<Program> logger) =>
{
    logger.LogInformation("Weather forecast requested");
    var result = weatherService.GetForecasts();
    logger.LogInformation("Returning {Count} forecasts", result.Length);
    return result;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

public partial class Program { }
