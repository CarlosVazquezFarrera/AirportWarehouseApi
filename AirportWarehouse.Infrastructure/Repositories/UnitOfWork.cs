using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Data;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AirportwarehouseContext context)
        {
            _context = context;
        }

        private readonly AirportwarehouseContext _context;
        private IRepository<Egress> _egressRepository;
        private IRepository<Supply> _supplyRepository;
        private IRepository<Agent> _agentRepository;
        private IRepository<Airport> _airportRepository;


        public IRepository<Egress> EgressRepository => _egressRepository ?? new BaseRepositoty<Egress>(_context);
        public IRepository<Supply> SupplyRepository => _supplyRepository ?? new BaseRepositoty<Supply>(_context);
        public IRepository<Agent> AgentRepository => _agentRepository ?? new BaseRepositoty<Agent>(_context);
        public IRepository<Airport> AirportRepository => _airportRepository ?? new BaseRepositoty<Airport>(_context);

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task SaveChanguesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
