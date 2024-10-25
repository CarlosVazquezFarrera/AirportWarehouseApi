using System.Runtime.ConstrainedExecution;

namespace AirportWarehouse.Core.Entites
{
    public partial class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? SupplierPart { get; set; }
        public Guid? PackagingTypeId { get; set; }
        public Guid? PresentationId { get; set; }
        public int PresentationQuantity { get; set; }
        public Guid? ProductFormatId { get; set; }
        public int FormatQuantity { get; set; }
        public int Stock { get; set; }
        public virtual PackagingType PackagingType { get; set; } = null!;
        public virtual Presentation Presentation { get; set; } = null!;
        public virtual ProductFormat ProductFormat { get; set; } = null!;
        public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();

    }
}
