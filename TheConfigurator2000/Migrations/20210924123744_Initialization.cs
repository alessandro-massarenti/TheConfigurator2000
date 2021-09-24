using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheConfigurator2000.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuotation",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuotationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuotation", x => new { x.ProductsId, x.QuotationsId });
                    table.ForeignKey(
                        name: "FK_ProductQuotation_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductQuotation_Quotations_QuotationsId",
                        column: x => x.QuotationsId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuotation_QuotationsId",
                table: "ProductQuotation",
                column: "QuotationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductQuotation");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Quotations");
        }
    }
}
