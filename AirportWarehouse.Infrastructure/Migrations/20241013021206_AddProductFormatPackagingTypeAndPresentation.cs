using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductFormatPackagingTypeAndPresentation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormatQuantity",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PackagingTypeId",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PresentationId",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PresentationQuantity",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductFormatId",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PackagingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagingType_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presentation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentation_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFormat_Id", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_PackagingTypeId",
                table: "Product",
                column: "PackagingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PresentationId",
                table: "Product",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductFormatId",
                table: "Product",
                column: "ProductFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagingType",
                table: "Product",
                column: "PackagingTypeId",
                principalTable: "PackagingType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presentation",
                table: "Product",
                column: "PresentationId",
                principalTable: "Presentation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFormat",
                table: "Product",
                column: "ProductFormatId",
                principalTable: "ProductFormat",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackagingType",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Presentation",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFormat",
                table: "Product");

            migrationBuilder.DropTable(
                name: "PackagingType");

            migrationBuilder.DropTable(
                name: "Presentation");

            migrationBuilder.DropTable(
                name: "ProductFormat");

            migrationBuilder.DropIndex(
                name: "IX_Product_PackagingTypeId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_PresentationId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductFormatId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FormatQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PackagingTypeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PresentationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PresentationQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductFormatId",
                table: "Product");
        }
    }
}
