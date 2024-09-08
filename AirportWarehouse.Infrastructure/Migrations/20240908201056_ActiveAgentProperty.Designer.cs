﻿// <auto-generated />
using System;
using AirportWarehouse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    [DbContext(typeof(AirportwarehouseContext))]
    [Migration("20240908201056_ActiveAgentProperty")]
    partial class ActiveAgentProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("AgentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("character varying(45)");

                    b.HasKey("Id")
                        .HasName("PK_Agent_Id");

                    b.ToTable("Agent", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.AgentPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_AgentPermission_Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("PermissionId");

                    b.ToTable("AgentPermission", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_Airport_Id");

                    b.ToTable("Airport", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Egress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("AmountRemoved")
                        .HasColumnType("integer");

                    b.Property<Guid>("ApproverId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("PetitionerId")
                        .HasColumnType("uuid");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("integer");

                    b.Property<Guid>("SupplyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Egress_Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("PetitionerId");

                    b.HasIndex("SupplyId");

                    b.ToTable("Egress", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityIncoming")
                        .HasColumnType("integer");

                    b.Property<Guid>("SupplyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Entry_Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("SupplyId");

                    b.ToTable("Entry", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_Permission_Id");

                    b.ToTable("Permission", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("SupplierPart")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_Product_Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("AirportWarehouse.Core.Entites.Supply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AirportId")
                        .HasColumnType("uuid");

                    b.Property<int>("CurrentQuantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Supply_Id");

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
                        .HasConstraintName("FK_ProductSupply");

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
