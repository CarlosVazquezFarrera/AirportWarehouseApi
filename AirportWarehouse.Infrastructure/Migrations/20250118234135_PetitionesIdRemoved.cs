using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PetitionesIdRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Egress_Agent_PetitionerId",
                table: "Egress");

            migrationBuilder.DropIndex(
                name: "IX_Egress_PetitionerId",
                table: "Egress");

            migrationBuilder.DropColumn(
                name: "PetitionerId",
                table: "Egress");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "Egress",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Egress_AgentId",
                table: "Egress",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Egress_Agent_AgentId",
                table: "Egress",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Egress_Agent_AgentId",
                table: "Egress");

            migrationBuilder.DropIndex(
                name: "IX_Egress_AgentId",
                table: "Egress");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Egress");

            migrationBuilder.AddColumn<Guid>(
                name: "PetitionerId",
                table: "Egress",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Egress_PetitionerId",
                table: "Egress",
                column: "PetitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Egress_Agent_PetitionerId",
                table: "Egress",
                column: "PetitionerId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
