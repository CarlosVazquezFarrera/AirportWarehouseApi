using AirportWarehouse.Core.CustomEntities;

namespace AirportWarehouse.Core.DTOs
{
    public class AgentDTO : AgentEditableInfo
    {
        public bool IsActive { get; set; }
    }
}
