namespace AirportWarehouse.Utils.Helpers.Claims
{
    public interface IClaimHelper
    {
        Guid GetUserId();
        Guid GetAirportId();
    }
}
