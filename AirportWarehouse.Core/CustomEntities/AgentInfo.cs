using AirportWarehouse.Core.DTOs;

namespace AirportWarehouse.Core.CustomEntities
{
    public class AgentInfo
    {
        public AgentBaseInfo Agent { get; set; } = new AgentBaseInfo();
        public string Token { get; set; } = string.Empty;
    }
}
