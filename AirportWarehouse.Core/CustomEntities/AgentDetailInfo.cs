namespace AirportWarehouse.Core.CustomEntities
{
    public class AgentDetailInfo : AgentBaseInfo
    {
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
