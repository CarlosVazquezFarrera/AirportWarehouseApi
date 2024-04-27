namespace AirportWarehouse.Core.QueryFilter
{
    public abstract class BasePagedParameter
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
