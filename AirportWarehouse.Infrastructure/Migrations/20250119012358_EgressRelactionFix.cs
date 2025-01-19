using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EgressRelactionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
