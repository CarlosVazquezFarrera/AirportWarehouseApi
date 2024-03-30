namespace AirportWarehouse.Core.DTOs
{
    public class EntryDTO
    {
        public Guid Id { get; set; }

        public int QuantityIncoming { get; set; }

        public int QuantityBefore { get; set; }

        public int QuantityAfter { get; set; }

        public DateTime? Date { get; set; }

        public Guid AgentId { get; set; }

        public Guid SupplyId { get; set; }

    }
}
