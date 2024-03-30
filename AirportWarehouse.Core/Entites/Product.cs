namespace AirportWarehouse.Core.Entites
{
    public partial class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? SupplierPart { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
    }
}
