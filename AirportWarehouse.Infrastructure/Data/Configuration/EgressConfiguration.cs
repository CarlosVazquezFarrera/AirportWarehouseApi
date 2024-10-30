using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class EgressConfiguration : IEntityTypeConfiguration<Egress>
    {
        public void Configure(EntityTypeBuilder<Egress> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Egress_Id"); 

            builder.ToTable("Egress");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()"); 

            builder.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP") 
                .HasColumnType("timestamp");

            builder.HasOne(d => d.Approver)
                .WithMany(p => p.EgressApprovers)
                .HasForeignKey(d => d.ApproverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EgressApprover");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Egresses)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull) 
                .HasConstraintName("FK_EgressProduct"); 

            builder.HasOne(d => d.Petitioner)
                .WithMany(p => p.EgressPetitioners)
                .HasForeignKey(d => d.PetitionerId)
                .OnDelete(DeleteBehavior.ClientSetNull) 
                .HasConstraintName("FK_EgressPetitioner");
        }

    }
}
