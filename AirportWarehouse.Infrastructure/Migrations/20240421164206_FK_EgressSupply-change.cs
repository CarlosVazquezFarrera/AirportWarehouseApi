using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FK_EgressSupplychange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EgressSupply",
                table: "Egress");

            migrationBuilder.CreateIndex(
                name: "IX_Egress_SupplyId",
                table: "Egress",
                column: "SupplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EgressSupply",
                table: "Egress",
                column: "SupplyId",
                principalTable: "Supply",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EgressSupply",
                table: "Egress");

            migrationBuilder.DropIndex(
                name: "IX_Egress_SupplyId",
                table: "Egress");

            migrationBuilder.AddForeignKey(
                name: "FK_EgressSupply",
                table: "Egress",
                column: "ApproverId",
                principalTable: "Supply",
                principalColumn: "Id");
        }
    }
}
