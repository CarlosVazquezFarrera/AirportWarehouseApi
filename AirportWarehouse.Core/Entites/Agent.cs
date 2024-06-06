namespace AirportWarehouse.Core.Entites
{
    public partial class Agent : BaseEntity
    {

        public string AgentNumber { get; set; } = null!;

        public string ShortName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<AgentPermission> AgentPermissions { get; set; } = new List<AgentPermission>();

        public virtual ICollection<Egress> EgressApprovers { get; set; } = new List<Egress>();

        public virtual ICollection<Egress> EgressPetitioners { get; set; } = new List<Egress>();

        public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();
    }
}
