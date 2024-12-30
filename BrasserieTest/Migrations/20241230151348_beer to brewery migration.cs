using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasserieTest.Migrations
{
    /// <inheritdoc />
    public partial class beertobrewerymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alcohol_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdBrewery = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    breweryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beer_Brewerys_breweryId",
                        column: x => x.breweryId,
                        principalTable: "Brewerys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beer_breweryId",
                table: "Beer",
                column: "breweryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beer");
        }
    }
}
