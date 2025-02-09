﻿using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IEgressService : IEntityDtoService<Egress, EgressDTO>
    {
        Task<IEnumerable<EgressDTO>> CreateEgressOrder(IEnumerable<EgressDTO> egresses);
    }
}
