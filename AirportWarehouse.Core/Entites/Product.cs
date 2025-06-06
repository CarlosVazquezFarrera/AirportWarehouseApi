﻿namespace AirportWarehouse.Core.Entites
{
    public partial class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string SupplierPart { get; set; } = null!;
        public Guid PackagingTypeId { get; set; }
        public Guid PresentationId { get; set; }
        public int PresentationQuantity { get; set; }
        public Guid ProductFormatId { get; set; }
        public int FormatQuantity { get; set; }
        public int Stock { get; set; }
        public Guid AirportId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual PackagingType PackagingType { get; set; } = null!;
        public virtual Presentation Presentation { get; set; } = null!;
        public virtual ProductFormat ProductFormat { get; set; } = null!;
        public virtual Airport Airport { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Egress> Egresses { get; set; } = new List<Egress>();
        public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    }
}
