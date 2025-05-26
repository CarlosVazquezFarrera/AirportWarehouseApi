using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Infrastructure.Data;

public partial class AirportwarehouseContext : DbContext
{
    public AirportwarehouseContext()
    {
    }

    public AirportwarehouseContext(DbContextOptions<AirportwarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<AgentPermission> AgentPermissions { get; set; }
    public virtual DbSet<Airport> Airports { get; set; }
    public virtual DbSet<Egress> Egresses { get; set; }
    public virtual DbSet<Entry> Entries { get; set; }
    public virtual DbSet<PackagingType> PackagingTypes { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<Presentation> Presentations { get; set; }
    public virtual DbSet<ProductFormat> ProductFormats { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PackagingTypeConfiguration());

        modelBuilder.ApplyConfiguration(new PresentationConfiguration());

        modelBuilder.ApplyConfiguration(new AgentConfiguration());

        modelBuilder.ApplyConfiguration(new AgentPermissionConfiguration());

        modelBuilder.ApplyConfiguration(new AirportConfiguration());

        modelBuilder.ApplyConfiguration(new EgressConfiguration());

        modelBuilder.ApplyConfiguration(new EntryConfiguration());

        modelBuilder.ApplyConfiguration(new PermissionConfiguration());

        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        modelBuilder.ApplyConfiguration(new ProductFormatConfiguration());

        modelBuilder.ApplyConfiguration(new DepartamentConfiguration());

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
