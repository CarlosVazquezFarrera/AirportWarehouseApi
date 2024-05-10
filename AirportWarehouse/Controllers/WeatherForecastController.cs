using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherRepository _weatherRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepository weatherRepository)
        {
            _logger = logger;
            _weatherRepository = weatherRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<List<WeatherForecast>> Get()
        {
            return await _weatherRepository.GetInfo();
        }

        [HttpGet("Name")]
        public string GetName()
        {
            return Environment.GetEnvironmentVariable("name") ?? "Sin valor";
        }
    }
}
