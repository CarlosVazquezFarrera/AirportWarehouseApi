namespace AirportWarehouse.Core.QueryFilter
{
    public class InventoryParameters : BasePagedParameter, IFilterParameter
    {
        public Guid IdAiport { get; set; }
        public string? Search { get; set ; }
    }
}
