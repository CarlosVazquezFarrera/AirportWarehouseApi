namespace AirportWarehouse.Infrastructure.Service
{
    public class ConfigSettings
    {
        public ConfigSettings(string connectionString,string? secretKey)
        {
            ConnectionString = connectionString;
            SecretKey = secretKey ?? "";
        }
        public string ConnectionString { get; set; }
        public string SecretKey { get; set; } = string.Empty;

    }
}
