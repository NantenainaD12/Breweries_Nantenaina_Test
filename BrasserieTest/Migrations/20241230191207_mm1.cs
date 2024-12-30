using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasserieTest.Migrations
{
    /// <inheritdoc />
    public partial class mm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockWholeSalers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    beerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    wholesalerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockLeft = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockWholeSalers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockWholeSalers");
        }
    }
}
