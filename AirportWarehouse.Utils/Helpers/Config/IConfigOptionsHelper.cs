namespace AirportWarehouse.Utils.Helpers.Config;

public interface IConfigOptionsHelper
{
    string GetSecretKey();
    string GetConnectionString();
}
