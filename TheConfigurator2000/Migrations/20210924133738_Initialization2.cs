using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheConfigurator2000.Migrations
{
    public partial class Initialization2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductQuotations",
                columns: table => new
                {
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductQuotations");
        }
    }
}
