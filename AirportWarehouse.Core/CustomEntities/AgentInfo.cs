using AirportWarehouse.Core.DTOs;

namespace AirportWarehouse.Core.CustomEntities
{
    public class AgentInfo
    {
        public AgentDTO Agent { get; set; } = new AgentDTO();
        public string Token { get; set; } = string.Empty;
    }
}
