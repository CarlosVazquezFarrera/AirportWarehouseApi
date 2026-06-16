namespace AirportWarehouse.Utils.Helpers.Password;

public interface IPassWordHelper
{
    void Check(string hash, string password);

    string HashPassword(string plaintText);
}
