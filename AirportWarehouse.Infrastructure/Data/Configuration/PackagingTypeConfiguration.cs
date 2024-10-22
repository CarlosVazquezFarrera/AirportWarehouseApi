using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class PackagingTypeConfiguration : IEntityTypeConfiguration<PackagingType>
    {
        public void Configure(EntityTypeBuilder<PackagingType> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_PackagingType_Id");
            builder.ToTable("PackagingType");
            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
