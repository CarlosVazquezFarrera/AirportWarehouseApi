﻿namespace AirportWarehouse.Core.Entites
{
    public partial class Egress : BaseEntity
    {
        public int AmountRemoved { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAfter { get; set; }
        public DateTime? Date { get; set; }
        public Guid PetitionerId { get; set; }
        public Guid ApproverId { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Agent Approver { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Agent Petitioner { get; set; } = null!;
    }
}
