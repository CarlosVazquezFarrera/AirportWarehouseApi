namespace AirportWarehouse.Core.CustomEntities
{
    public class InventoryItem
    {
        public string Name { get; set; } = string.Empty;
        public string Airport { get; set; } = string.Empty;
        public string? SupplierPart { get; set; } 
        public int CurrentQuantity { get; set; }
    }
}
