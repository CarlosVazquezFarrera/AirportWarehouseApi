﻿using AirportWarehouse.Core.Entites;
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
                .WithMany(p => p.Egresses)
                .HasForeignKey(d => d.ApproverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EgressApprover");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Egresses)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull) 
                .HasConstraintName("FK_EgressProduct");

            builder.HasOne(d => d.Department)
                .WithMany(p => p.Egresses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EgressDepartment");
        }

    }
}
