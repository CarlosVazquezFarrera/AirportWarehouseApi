namespace AirportWarehouse.Core.Dtos
{
    public class AgentPermissionDTO : BaseDto
    {

        public Guid AgentId { get; set; }

        public Guid PermissionId { get; set; }
    }
}
