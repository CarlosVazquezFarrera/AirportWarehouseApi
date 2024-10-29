using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Product_Id");

            builder.ToTable("Product");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.Name)
                .IsUnicode(false);

            builder.Property(e => e.SupplierPart)
                .IsUnicode(false);

            builder.HasOne(d => d.PackagingType)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.PackagingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PackagingType");

            //builder
            //    .Navigation(p => p.PackagingType)
            //    .AutoInclude();

            builder.HasOne(d => d.Presentation)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.PresentationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Presentation");

            //builder
            //    .Navigation(d => d.Presentation)
            //    .AutoInclude();

            builder.HasOne(d => d.ProductFormat)
               .WithMany(p => p.Products)
               .HasForeignKey(d => d.ProductFormatId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_ProductFormat");
            
            builder.HasOne(d => d.Airport)
             .WithMany(p => p.Products)
             .HasForeignKey(d => d.AirportId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_AirportId");
        }
    }

}
