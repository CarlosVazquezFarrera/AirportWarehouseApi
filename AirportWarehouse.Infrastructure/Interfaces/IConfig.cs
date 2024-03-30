namespace AirportWarehouse.Infrastructure.Interfaces
{
    public interface IConfig
    {
        string ConnectionString { get; set; }
        string SecretKey { get; set; }
        string ApiUrl { get; set; }

    }
}
