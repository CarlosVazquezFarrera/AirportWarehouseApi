namespace AirportWarehouse.Core.Entites
{
    public partial class Supply
    {
        public Guid Id { get; set; }

        public int CurrentQuantity { get; set; }

        public Guid ProductId { get; set; }

        public Guid AirportId { get; set; }

        public virtual Airport Airport { get; set; } = null!;

        public virtual ICollection<Egress> Egresses { get; set; } = new List<Egress>();

        public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

        public virtual Product Product { get; set; } = null!;
    }
}
