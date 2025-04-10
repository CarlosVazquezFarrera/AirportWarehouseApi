using AirportWarehouse.Core.CustomEntities;

namespace AirportWarehouse.Core.DTOs
{
    public class AgentDTO : EditableAgentInfo
    {
        public bool IsActive { get; set; }
        public string Password { get; set; } = string.Empty;

    }
}
