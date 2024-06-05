namespace AirportWarehouse.Core.QueryFilter
{
    public class AgentParameters : BasePagedParameter, IFilterParameter
    {
        public string? Search { get ; set; }
    }
}
