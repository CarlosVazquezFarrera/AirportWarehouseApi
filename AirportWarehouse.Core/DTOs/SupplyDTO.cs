namespace AirportWarehouse.Core.DTOs
{
    public class SupplyDTO : BaseDTO
    {
        public int CurrentQuantity { get; set; }

        public Guid ProductId { get; set; }

        public Guid AirportId { get; set; }
    }
}
