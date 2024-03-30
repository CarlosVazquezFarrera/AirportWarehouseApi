using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class EgressConfiguration : IEntityTypeConfiguration<Egress>
    {
        public void Configure(EntityTypeBuilder<Egress> builder)
        {

            builder.HasKey(e => e.Id).HasName("PK__Egress__3214EC0790C1F779");

            builder.ToTable("Egress");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.HasOne(d => d.Approver).WithMany(p => p.EgressApprovers)
                .HasForeignKey(d => d.ApproverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EgressApprover");

            builder.HasOne(d => d.ApproverNavigation).WithMany(p => p.Egresses)
                .HasForeignKey(d => d.ApproverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EgressSupply");

            builder.HasOne(d => d.Petitioner).WithMany(p => p.EgressPetitioners)
                .HasForeignKey(d => d.PetitionerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EgressPetitioner");
        }
    }
}
