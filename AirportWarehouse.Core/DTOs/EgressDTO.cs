namespace AirportWarehouse.Core.Dtos
{
    public class EgressDto : BaseDto
    {
        public int AmountRemoved { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAfter { get; set; }
        public DateTime? Date { get; set; }
        public Guid ApproverId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
