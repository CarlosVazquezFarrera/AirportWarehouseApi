﻿using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IEgressService
    {
        Task<Egress> Create(Egress egress);
    }
}
