namespace AirportWarehouse.Core.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; } = null!;
        public string SupplierPart { get; set; } = null!;
        public Guid PackagingTypeId { get; set; }
        public Guid PresentationId { get; set; }
        public int PresentationQuantity { get; set; }
        public Guid ProductFormatId { get; set; }
        public int FormatQuantity { get; set; }
        public Guid AirportId { get; set; }
    }
}
