namespace AirportWarehouse.Utils.Helpers.Config;

public class ConfigOptionsHelper : IConfigOptionsHelper
{
    public string GetConnectionString()
    {
        return Environment.GetEnvironmentVariable("ConnectionString") ??
            "Host=localhost; Port=5432; Database=airportwarehouse_; Username=postgres; Password=local12345; Pooling=true;";
    }

    public string GetSecretKey()
    {
        return Environment.GetEnvironmentVariable("SecretKey")!;
    }
}
