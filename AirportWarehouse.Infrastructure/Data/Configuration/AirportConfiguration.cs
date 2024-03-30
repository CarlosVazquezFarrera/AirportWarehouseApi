using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Airport__3214EC07AE2EBFDF");

            builder.ToTable("Airport");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Name).IsUnicode(false);
        }
    }
}
