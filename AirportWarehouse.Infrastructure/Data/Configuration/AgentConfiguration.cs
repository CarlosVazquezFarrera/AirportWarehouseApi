using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Agent_Id");

            builder.ToTable("Agent");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.Email).IsUnicode(false);
            builder.Property(e => e.LastName).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
            builder.Property(e => e.Password).IsUnicode(false);

            builder.Property(e => e.ShortName)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.HasOne(d => d.Airports)
              .WithMany(p => p.Agents)
              .HasForeignKey(d => d.AirportId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Airports");
        }
    }

}
