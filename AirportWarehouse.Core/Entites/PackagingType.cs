namespace AirportWarehouse.Core.Entites
{
    public partial class PackagingType : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; }  = new List<Product>();

    }
}
