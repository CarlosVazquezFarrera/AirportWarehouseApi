
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using System;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<WeatherForecast>> GetInfo()
        {
            var data = Enumerable.Range(0, 10).Select(index =>
            new WeatherForecast{
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
            await Task.Delay(10);
            return data;
        }
    }
}
