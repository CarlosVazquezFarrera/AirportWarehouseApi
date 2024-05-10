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
            _egressRepository = new BaseRepositoty<Egress>(_context);
            _supplyRepository = new BaseRepositoty<Supply>(_context);
            _agentRepository = new BaseRepositoty<Agent>(_context);
            _airportRepository = new BaseRepositoty<Airport>(_context);
            _entryRepository = new BaseRepositoty<Entry>(_context);
        }

        private readonly AirportwarehouseContext _context;
        private readonly IRepository<Egress> _egressRepository;
        private readonly IRepository<Supply> _supplyRepository;
        private readonly IRepository<Agent>  _agentRepository;
        private readonly IRepository<Airport> _airportRepository;
        private readonly IRepository<Entry> _entryRepository;


        public IRepository<Egress> EgressRepository => _egressRepository ?? new BaseRepositoty<Egress>(_context);
        public IRepository<Supply> SupplyRepository => _supplyRepository ?? new BaseRepositoty<Supply>(_context);
        public IRepository<Agent> AgentRepository => _agentRepository ?? new BaseRepositoty<Agent>(_context);
        public IRepository<Airport> AirportRepository => _airportRepository ?? new BaseRepositoty<Airport>(_context);
        public IRepository<Entry> EntryRepository => _entryRepository ?? new BaseRepositoty<Entry>(_context);


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
