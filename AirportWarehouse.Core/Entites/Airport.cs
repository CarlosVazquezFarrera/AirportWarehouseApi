namespace AirportWarehouse.Core.Entites
{ 
    public partial class Airport
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
    }

}
