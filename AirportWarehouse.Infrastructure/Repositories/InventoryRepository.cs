using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryRepository(AirportwarehouseContext context)
        {
            _context = context;
        }
        private readonly AirportwarehouseContext _context;

        public IEnumerable<InventoryItem> GetIventoryByAirport(Guid IdAirport)
        {
            var result = (from p in _context.Products
                         join s in _context.Supplies on p.Id equals s.ProductId
                         join ai in _context.Airports on s.AirportId equals ai.Id
                         where ai.Id.Equals(IdAirport)
                         select new InventoryItem()
                         {
                             Id = s.Id,
                             Name = p.Name,
                             SupplierPart = p.SupplierPart,
                             CurrentQuantity = s.CurrentQuantity,
                             Airport = ai.Name
                         }).AsQueryable();
            return (result);
        }

        public async Task<InventoryItem> GetSuplyByIdAndAirport(Guid IdSupply, Guid IdAirport)
        {
            var supply = await (from p in _context.Products
                          join s in _context.Supplies on p.Id equals s.ProductId
                          join ai in _context.Airports on s.AirportId equals ai.Id
                          where ai.Id.Equals(IdAirport) && s.Id.Equals(IdSupply)
                          select new InventoryItem()
                          {
                              Id = s.Id,
                              Name = p.Name,
                              SupplierPart = p.SupplierPart,
                              CurrentQuantity = s.CurrentQuantity,
                              Airport = ai.Name
                          }).AsNoTracking().FirstOrDefaultAsync();
            return supply!;
        }
    }
}
