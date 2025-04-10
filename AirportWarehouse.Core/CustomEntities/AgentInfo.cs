using AirportWarehouse.Core.DTOs;

namespace AirportWarehouse.Core.CustomEntities
{
    public class AgentInfo
    {
        public EditableAgentInfo Agent { get; set; } = new EditableAgentInfo();
        public string Token { get; set; } = string.Empty;
    }
}
