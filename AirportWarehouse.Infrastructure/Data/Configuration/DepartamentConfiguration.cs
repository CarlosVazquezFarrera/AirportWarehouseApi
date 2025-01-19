using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportWarehouse.Infrastructure.Data.Configuration
{
    public class DepartamentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Department_Id");

            builder.ToTable("Department");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.Name)
                .IsUnicode();
        }
    }
}
