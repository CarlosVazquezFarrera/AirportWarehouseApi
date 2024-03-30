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

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AgentConfiguration());

        modelBuilder.ApplyConfiguration(new AgentPermissionConfiguration());

        modelBuilder.ApplyConfiguration(new AirportConfiguration());

        modelBuilder.ApplyConfiguration(new EgressConfiguration());

        modelBuilder.ApplyConfiguration(new EntryConfiguration());

        modelBuilder.ApplyConfiguration(new PermissionConfiguration());

        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        modelBuilder.ApplyConfiguration(new SupplyConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Initial Catalog=airportwarehouse_; User ID=airportwarehouse_;Password=C@rl0$1997#; Persist Security Info=True; Encrypt=true;TrustServerCertificate=True");




    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
