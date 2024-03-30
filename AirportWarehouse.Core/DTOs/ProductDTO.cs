namespace AirportWarehouse.Core.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? SupplierPart { get; set; }
    }
}
