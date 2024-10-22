using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    internal class PresentationConfiguration : IEntityTypeConfiguration<Presentation>
    {
        public void Configure(EntityTypeBuilder<Presentation> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Presentation_Id");
            builder.ToTable("Presentation");
            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
