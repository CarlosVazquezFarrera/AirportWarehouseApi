﻿namespace AirportWarehouse.Core.Entites
{ 
    public partial class Airport : BaseEntity
    {

        public string Name { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>(); 
        public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
    }

}
