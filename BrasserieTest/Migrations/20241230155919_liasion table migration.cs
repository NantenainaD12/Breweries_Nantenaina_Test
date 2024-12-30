using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasserieTest.Migrations
{
    /// <inheritdoc />
    public partial class liasiontablemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wholesalers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WholesalersBeers",
                columns: table => new
                {
                    IdBeer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdWholesaler = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholesalersBeers", x => new { x.IdBeer, x.IdWholesaler });
                    table.ForeignKey(
                        name: "FK_WholesalersBeers_Beers_IdBeer",
                        column: x => x.IdBeer,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WholesalersBeers_Wholesalers_IdWholesaler",
                        column: x => x.IdWholesaler,
                        principalTable: "Wholesalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WholesalersBeers_IdWholesaler",
                table: "WholesalersBeers",
                column: "IdWholesaler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WholesalersBeers");

            migrationBuilder.DropTable(
                name: "Wholesalers");
        }
    }
}
