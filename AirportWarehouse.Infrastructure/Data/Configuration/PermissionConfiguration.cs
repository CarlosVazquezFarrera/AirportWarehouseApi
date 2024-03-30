using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07211C4D86");

            builder.ToTable("Permission");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Name).IsUnicode(false);
        }
    }
}
