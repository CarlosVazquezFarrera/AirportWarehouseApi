namespace AirportWarehouse.Core.DTOs
{
    public class AgentPermissionDTO : BaseDTO
    {

        public Guid AgentId { get; set; }

        public Guid PermissionId { get; set; }
    }
}
