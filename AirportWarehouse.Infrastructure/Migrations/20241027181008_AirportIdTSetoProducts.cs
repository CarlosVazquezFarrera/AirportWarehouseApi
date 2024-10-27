using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AirportIdTSetoProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AirportId",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AirportId",
                table: "Agent",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_AirportId",
                table: "Product",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirportId",
                table: "Product",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirportId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AirportId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "AirportId",
                table: "Agent",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
