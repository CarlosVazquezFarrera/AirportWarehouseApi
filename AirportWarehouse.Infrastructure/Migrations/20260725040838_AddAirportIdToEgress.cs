using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAirportIdToEgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Egress",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Egress",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<Guid>(
                name: "AirportId",
                table: "Egress",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Egress_AirportId",
                table: "Egress",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_EgressAirport",
                table: "Egress",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EgressAirport",
                table: "Egress");

            migrationBuilder.DropIndex(
                name: "IX_Egress_AirportId",
                table: "Egress");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Egress");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Product",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Egress",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Egress",
                type: "timestamp",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
