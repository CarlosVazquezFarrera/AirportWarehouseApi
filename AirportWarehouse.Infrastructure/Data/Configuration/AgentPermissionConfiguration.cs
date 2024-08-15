using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class AgentPermissionConfiguration : IEntityTypeConfiguration<AgentPermission>
    {
        public void Configure(EntityTypeBuilder<AgentPermission> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_AgentPermission_Id");

            builder.ToTable("AgentPermission");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()"); 

            builder.HasOne(d => d.Agent)
                .WithMany(p => p.AgentPermissions)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentHasPermissions");

            builder.HasOne(d => d.Permission)
                .WithMany(p => p.AgentPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermissionOwnsAgent");
        }
    }

}
