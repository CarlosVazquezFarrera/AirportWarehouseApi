using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

namespace AirportWarehouse.Controllers
{
    public class EgressController : GenericController<Egress, EgressDto>
    {
        public EgressController(IGenericService<Egress, EgressDto> service) : base(service)
        {
        }
    }
}
