using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntriesAndEgressWithProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EgressSupply",
                table: "Egress");

            migrationBuilder.DropForeignKey(
                name: "FK_EntrySupply",
                table: "Entry");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropIndex(
                name: "IX_Entry_SupplyId",
                table: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Egress_SupplyId",
                table: "Egress");

            migrationBuilder.DropColumn(
                name: "SupplyId",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "SupplyId",
                table: "Egress");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierPart",
                table: "Product",
                type: "text",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Entry",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Egress",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entry_ProductId",
                table: "Entry",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Egress_ProductId",
                table: "Egress",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_EgressProduct",
                table: "Egress",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryProduct",
                table: "Entry",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EgressProduct",
                table: "Egress");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryProduct",
                table: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Entry_ProductId",
                table: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Egress_ProductId",
                table: "Egress");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Egress");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierPart",
                table: "Product",
                type: "text",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldUnicode: false);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplyId",
                table: "Entry",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SupplyId",
                table: "Egress",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    AirportId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentQuantity = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Entry_SupplyId",
                table: "Entry",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Egress_SupplyId",
                table: "Egress",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_AirportId",
                table: "Supply",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_ProductId",
                table: "Supply",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_EgressSupply",
                table: "Egress",
                column: "SupplyId",
                principalTable: "Supply",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntrySupply",
                table: "Entry",
                column: "SupplyId",
                principalTable: "Supply",
                principalColumn: "Id");
        }
    }
}
