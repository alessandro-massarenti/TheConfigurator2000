using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheConfigurator2000.Migrations
{
    public partial class AddedCountFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductQuotation");

            migrationBuilder.DropTable(
                name: "ProductQuotations");

            migrationBuilder.CreateTable(
                name: "QuotationProduct",
                columns: table => new
                {
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationProduct", x => new { x.QuotationId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_QuotationProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationProduct_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuotationProduct_ProductId",
                table: "QuotationProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotationProduct");

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

            migrationBuilder.CreateTable(
                name: "ProductQuotations",
                columns: table => new
                {
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuotation_QuotationsId",
                table: "ProductQuotation",
                column: "QuotationsId");
        }
    }
}
