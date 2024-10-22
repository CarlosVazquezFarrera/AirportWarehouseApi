namespace AirportWarehouse.Core.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; } = null!;
        public string? SupplierPart { get; set; }
        public int PresentationQuantity { get; set; }
        public int FormatQuantity { get; set; }
    }
}
