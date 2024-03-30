using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class AgentPermissionConfiguration : IEntityTypeConfiguration<AgentPermission>
    {
        public void Configure(EntityTypeBuilder<AgentPermission> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__AgentPer__3214EC0741F713B0");

            builder.ToTable("AgentPermission");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.HasOne(d => d.Agent).WithMany(p => p.AgentPermissions)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentHasPermissions");

            builder.HasOne(d => d.Permission).WithMany(p => p.AgentPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermissionOwnsAgent");
        }
    }
}
