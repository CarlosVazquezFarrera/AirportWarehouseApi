using AirportWarehouse.Infrastructure.Interfaces;

namespace AirportWarehouse.Infrastructure.Service
{
    public class Config(string? connectionString, string? secretKey) : IConfig
    {
        public string ConnectionString { get; set; } = connectionString ?? string.Empty;
        public string SecretKey { get; set; } = secretKey ?? string.Empty;
        public string ApiUrl { get; set; } = string.Empty;
    }
}
