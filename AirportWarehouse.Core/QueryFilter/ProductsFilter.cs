namespace AirportWarehouse.Core.QueryFilter
{
    public class ProductsFilter : BasePagedParameter, IFilterParameter
    {
        public Guid AirportId { get; set; }
        public string? Search {get; set; }
    }
}
