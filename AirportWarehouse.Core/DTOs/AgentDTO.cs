using AirportWarehouse.Core.CustomEntities;

namespace AirportWarehouse.Core.DTOs
{
    public class AgentDTO : AgentBaseInfo
    {
       public string Password { get; set; } = null!;

    }
}
