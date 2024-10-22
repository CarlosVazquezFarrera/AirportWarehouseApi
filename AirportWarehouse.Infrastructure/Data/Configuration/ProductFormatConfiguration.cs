using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class ProductFormatConfiguration : IEntityTypeConfiguration<ProductFormat>
    {
        public void Configure(EntityTypeBuilder<ProductFormat> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_ProductFormat_Id");
            builder.ToTable("ProductFormat");
            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
