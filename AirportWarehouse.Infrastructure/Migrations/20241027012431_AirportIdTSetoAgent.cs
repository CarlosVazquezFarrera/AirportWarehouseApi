using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AirportIdTSetoAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AirportId",
                table: "Agent",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agent_AirportId",
                table: "Agent",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports",
                table: "Agent",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports",
                table: "Agent");

            migrationBuilder.DropIndex(
                name: "IX_Agent_AirportId",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Agent");
        }
    }
}
