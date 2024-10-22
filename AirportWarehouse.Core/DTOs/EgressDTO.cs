namespace AirportWarehouse.Core.DTOs
{
    public class EgressDTO : BaseDTO
    {

        public int AmountRemoved { get; set; }

        public int QuantityBefore { get; set; }

        public int QuantityAfter { get; set; }

        public DateTime? Date { get; set; }

        public Guid PetitionerId { get; set; }

        public Guid ApproverId { get; set; }

        public Guid SupplyId { get; set; }

    }
}
