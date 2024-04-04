﻿using AirportWarehouse.Core.CustomEntities;
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

        public async Task<IEnumerable<InventoryItem>> GetIventoryByAirport(Guid IdAirport)
        {
            var result = await (from p in _context.Products
                         join s in _context.Supplies on p.Id equals s.ProductId
                         join ai in _context.Airports on s.AirportId equals ai.Id
                         where ai.Id.Equals(IdAirport)
                         select new InventoryItem()
                         {
                             Name = p.Name,
                             SupplierPart = p.SupplierPart,
                             CurrentQuantity = s.CurrentQuantity,
                             Airport = ai.Name
                         }).ToListAsync();
            return (result);
        }
    }
}
