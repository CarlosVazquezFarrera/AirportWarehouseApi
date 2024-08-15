using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    AgentNumber = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "character varying(45)", unicode: false, maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false),
                    LastName = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Password = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false),
                    SupplierPart = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgentPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentPermission_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentHasPermissions",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionOwnsAgent",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    CurrentQuantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    AirportId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportSupply",
                        column: x => x.AirportId,
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductSupply",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Egress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    AmountRemoved = table.Column<int>(type: "integer", nullable: false),
                    QuantityBefore = table.Column<int>(type: "integer", nullable: false),
                    QuantityAfter = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    PetitionerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egress_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EgressApprover",
                        column: x => x.ApproverId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EgressPetitioner",
                        column: x => x.PetitionerId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EgressSupply",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    QuantityIncoming = table.Column<int>(type: "integer", nullable: false),
                    QuantityBefore = table.Column<int>(type: "integer", nullable: false),
                    QuantityAfter = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryAgent",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntrySupply",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentPermission_AgentId",
                table: "AgentPermission",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPermission_PermissionId",
                table: "AgentPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Egress_ApproverId",
                table: "Egress",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Egress_PetitionerId",
                table: "Egress",
                column: "PetitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Egress_SupplyId",
                table: "Egress",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_AgentId",
                table: "Entry",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_SupplyId",
                table: "Entry",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_AirportId",
                table: "Supply",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_ProductId",
                table: "Supply",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentPermission");

            migrationBuilder.DropTable(
                name: "Egress");

            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
