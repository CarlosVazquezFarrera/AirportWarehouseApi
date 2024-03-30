using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Product__3214EC074A2930E5");

            builder.ToTable("Product");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Name).IsUnicode(false);
            builder.Property(e => e.SupplierPart).IsUnicode(false);
        }
    }
}
