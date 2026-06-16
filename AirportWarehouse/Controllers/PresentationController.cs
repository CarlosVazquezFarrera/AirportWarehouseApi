using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

namespace AirportWarehouse.Controllers
{
    public class PresentationController : GenericGetController<Presentation, PresentationDto>
    {
        public PresentationController(IGenericService<Presentation, PresentationDto> service) : base(service) 
        {
        }
    }
}
