using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Agent__3214EC07891175A9");

            builder.ToTable("Agent");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Email).IsUnicode(false);
            builder.Property(e => e.LastName).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
            builder.Property(e => e.Password).IsUnicode(false);
            builder.Property(e => e.ShortName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
