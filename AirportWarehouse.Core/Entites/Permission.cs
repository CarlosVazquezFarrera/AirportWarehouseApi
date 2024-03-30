namespace AirportWarehouse.Core.Entites
{
    public partial class Permission
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<AgentPermission> AgentPermissions { get; set; } = new List<AgentPermission>();
    }
}
