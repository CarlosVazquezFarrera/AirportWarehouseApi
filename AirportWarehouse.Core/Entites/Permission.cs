namespace AirportWarehouse.Core.Entites
{
    public partial class Permission: BaseEntity
    {

        public string Name { get; set; } = null!;

        public virtual ICollection<AgentPermission> AgentPermissions { get; set; } = new List<AgentPermission>();
    }
}
