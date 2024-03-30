using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class EntryConfiguration : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Entry__3214EC07CFD94E38");

            builder.ToTable("Entry");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.HasOne(d => d.Agent).WithMany(p => p.Entries)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntryAgent");

            builder.HasOne(d => d.Supply).WithMany(p => p.Entries)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntrySupply");
        }
    }
}
