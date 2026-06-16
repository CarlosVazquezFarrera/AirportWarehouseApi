using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces; 
namespace AirportWarehouse.Controllers
{
    public class AirportController : GenericGetController<Airport, AirportDto>
    {
        public AirportController(IGenericService<Airport, AirportDto> service) : base(service)
        {
        }
    }
}
