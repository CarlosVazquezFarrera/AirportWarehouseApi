using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

namespace AirportWarehouse.Controllers
{
    public class ProductFormatController : GenericGetController<ProductFormat, ProductFormatDto>
    {
        public ProductFormatController(IGenericService<ProductFormat, ProductFormatDto> service) : base (service)
        {
        }

    }
}
