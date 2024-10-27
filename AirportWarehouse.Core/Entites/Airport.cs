namespace AirportWarehouse.Core.Entites
{ 
    public partial class Airport : BaseEntity
    {

        public string Name { get; set; } = null!;

        public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
        public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
    }

}
