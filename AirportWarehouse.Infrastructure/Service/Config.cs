using AirportWarehouse.Infrastructure.Interfaces;

namespace AirportWarehouse.Infrastructure.Service
{
    public class Config : IConfig
    {
        public Config(string? connectionString, string? secretKey)
        {
            ConnectionString = connectionString ?? string.Empty;
            SecretKey = secretKey ?? string.Empty;
        }
        public string ConnectionString { get ; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string ApiUrl { get; set; } = string.Empty;
    }
}
