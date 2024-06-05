using AirportWarehouse.Core.DTOs;

namespace AirportWarehouse.Core.CustomEntities
{
    public class AgentInfo
    {
        public LoginAgent Agent { get; set; } = new LoginAgent();
        public string Token { get; set; } = string.Empty;
    }
}
