namespace AirportWarehouse.Core.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        void Check(string hash, string password);
    }
}
