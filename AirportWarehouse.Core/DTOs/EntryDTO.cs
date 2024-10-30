namespace AirportWarehouse.Core.DTOs
{
    public class EntryDTO : BaseDTO
    {
        public int QuantityIncoming { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAfter { get; set; }
        public DateTime? Date { get; set; }
        public Guid AgentId { get; set; }
        public Guid ProductId { get; set; }

    }
}
