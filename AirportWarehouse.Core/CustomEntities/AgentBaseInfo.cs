using AirportWarehouse.Core.DTOs;

namespace AirportWarehouse.Core.CustomEntities
{
    public class AgentBaseInfo: BaseDTO
    {
        public string AgentNumber { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
