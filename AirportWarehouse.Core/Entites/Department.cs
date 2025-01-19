namespace AirportWarehouse.Core.Entites
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<Egress> Egresses { get; set; } = new List<Egress>();
    }
}
