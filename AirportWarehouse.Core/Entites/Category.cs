﻿namespace AirportWarehouse.Core.Entites
{
    public partial class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
