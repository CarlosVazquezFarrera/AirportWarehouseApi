using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class SupplyConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Supply__3214EC070EC2A5DA");

            builder.ToTable("Supply");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.HasOne(d => d.Airport).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.AirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AirportSupply");

            builder.HasOne(d => d.Product).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentSupply");
        }
    }
}
