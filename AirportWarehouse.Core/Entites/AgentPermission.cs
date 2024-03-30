namespace AirportWarehouse.Core.Entites
{
    public partial class AgentPermission
    {
        public Guid Id { get; set; }

        public Guid AgentId { get; set; }

        public Guid PermissionId { get; set; }

        public virtual Agent Agent { get; set; } = null!;

        public virtual Permission Permission { get; set; } = null!;
    }
}
