namespace AirportWarehouse.Core.DTOs
{
    public class SupplyDTO
    {
        public Guid Id { get; set; }

        public int CurrentQuantity { get; set; }

        public Guid ProductId { get; set; }

        public Guid AirportId { get; set; }
    }
}
