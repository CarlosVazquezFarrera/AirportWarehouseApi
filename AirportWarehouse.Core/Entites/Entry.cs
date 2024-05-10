namespace AirportWarehouse.Core.Entites
{
    public partial class Entry : BaseEntity
    {

        public int QuantityIncoming { get; set; }

        public int QuantityBefore { get; set; }

        public int QuantityAfter { get; set; }

        public DateTime? Date { get; set; }

        public Guid AgentId { get; set; }

        public Guid SupplyId { get; set; }

        public virtual Agent Agent { get; set; } = null!;

        public virtual Supply Supply { get; set; } = null!;
    }
}
