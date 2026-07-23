using AirportWarehouse.Core.Dtos;

namespace AirportWarehouse.Core.CustomEntities;

public class LedgerEgressMovement : BaseDto
{
    public string Name { get; set; } = null!;
    public string SupplierPart { get; set; } = null!;
    public int TotalMovements { get; set; }
    public int UnitsRemoved { get; set; }
}
