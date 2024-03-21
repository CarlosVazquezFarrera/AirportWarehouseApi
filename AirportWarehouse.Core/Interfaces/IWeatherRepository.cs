using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IWeatherRepository
    {
        Task<List<WeatherForecast>> GetInfo();
    }
}
