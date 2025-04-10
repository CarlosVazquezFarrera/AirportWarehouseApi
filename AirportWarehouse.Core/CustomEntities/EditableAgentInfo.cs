using AirportWarehouse.Core.DTOs;

namespace AirportWarehouse.Core.CustomEntities
{
    public class EditableAgentInfo : BaseDTO
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string AgentNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid AirportId { get; set; }
        public string ShortName { get; set; } = null!;
    }
}
