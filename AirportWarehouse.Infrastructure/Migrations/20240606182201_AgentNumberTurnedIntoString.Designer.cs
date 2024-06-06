﻿// <auto-generated />
using System;
using AirportWarehouse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    [DbContext(typeof(AirportwarehouseContext))]
    [Migration("20240606182201_AgentNumberTurnedIntoString")]
    partial class AgentNumberTurnedIntoString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("AgentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PK__Agent__3214EC07891175A9");

                    b.ToTable("Agent", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.AgentPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__AgentPer__3214EC0741F713B0");

                    b.HasIndex("AgentId");

                    b.HasIndex("PermissionId");

                    b.ToTable("AgentPermission", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Airport__3214EC07AE2EBFDF");

                    b.ToTable("Airport", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Egress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("AmountRemoved")
                        .HasColumnType("int");

                    b.Property<Guid>("ApproverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("PetitionerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("int");

                    b.Property<Guid>("SupplyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Egress__3214EC0790C1F779");

                    b.HasIndex("ApproverId");

                    b.HasIndex("PetitionerId");

                    b.HasIndex("SupplyId");

                    b.ToTable("Egress", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("int");

                    b.Property<int>("QuantityIncoming")
                        .HasColumnType("int");

                    b.Property<Guid>("SupplyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Entry__3214EC07CFD94E38");

                    b.HasIndex("AgentId");

                    b.HasIndex("SupplyId");

                    b.ToTable("Entry", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Permissi__3214EC07211C4D86");

                    b.ToTable("Permission", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SupplierPart")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Product__3214EC074A2930E5");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Supply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("AirportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentQuantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Supply__3214EC070EC2A5DA");

                    b.HasIndex("AirportId");

                    b.HasIndex("ProductId");

                    b.ToTable("Supply", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.AgentPermission", b =>
                {
                    b.HasOne("AirportWarehouse.Core.Entites.Agent", "Agent")
                        .WithMany("AgentPermissions")
                        .HasForeignKey("AgentId")
                        .IsRequired()
                        .HasConstraintName("FK_AgentHasPermissions");

                    b.HasOne("AirportWarehouse.Core.Entites.Permission", "Permission")
                        .WithMany("AgentPermissions")
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("FK_PermissionOwnsAgent");

                    b.Navigation("Agent");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Egress", b =>
                {
                    b.HasOne("AirportWarehouse.Core.Entites.Agent", "Approver")
                        .WithMany("EgressApprovers")
                        .HasForeignKey("ApproverId")
                        .IsRequired()
                        .HasConstraintName("FK_EgressApprover");

                    b.HasOne("AirportWarehouse.Core.Entites.Agent", "Petitioner")
                        .WithMany("EgressPetitioners")
                        .HasForeignKey("PetitionerId")
                        .IsRequired()
                        .HasConstraintName("FK_EgressPetitioner");

                    b.HasOne("AirportWarehouse.Core.Entites.Supply", "ApproverNavigation")
                        .WithMany("Egresses")
                        .HasForeignKey("SupplyId")
                        .IsRequired()
                        .HasConstraintName("FK_EgressSupply");

                    b.Navigation("Approver");

                    b.Navigation("ApproverNavigation");

                    b.Navigation("Petitioner");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Entry", b =>
                {
                    b.HasOne("AirportWarehouse.Core.Entites.Agent", "Agent")
                        .WithMany("Entries")
                        .HasForeignKey("AgentId")
                        .IsRequired()
                        .HasConstraintName("FK_EntryAgent");

                    b.HasOne("AirportWarehouse.Core.Entites.Supply", "Supply")
                        .WithMany("Entries")
                        .HasForeignKey("SupplyId")
                        .IsRequired()
                        .HasConstraintName("FK_EntrySupply");

                    b.Navigation("Agent");

                    b.Navigation("Supply");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Supply", b =>
                {
                    b.HasOne("AirportWarehouse.Core.Entites.Airport", "Airport")
                        .WithMany("Supplies")
                        .HasForeignKey("AirportId")
                        .IsRequired()
                        .HasConstraintName("FK_AirportSupply");

                    b.HasOne("AirportWarehouse.Core.Entites.Product", "Product")
                        .WithMany("Supplies")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_AgentSupply");

                    b.Navigation("Airport");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Agent", b =>
                {
                    b.Navigation("AgentPermissions");

                    b.Navigation("EgressApprovers");

                    b.Navigation("EgressPetitioners");

                    b.Navigation("Entries");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Airport", b =>
                {
                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Permission", b =>
                {
                    b.Navigation("AgentPermissions");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Product", b =>
                {
                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Supply", b =>
                {
                    b.Navigation("Egresses");

                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
