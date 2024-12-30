using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasserieTest.Migrations
{
    /// <inheritdoc />
    public partial class beertobrewerymigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beer_Brewerys_breweryId",
                table: "Beer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beer",
                table: "Beer");

            migrationBuilder.RenameTable(
                name: "Beer",
                newName: "Beers");

            migrationBuilder.RenameIndex(
                name: "IX_Beer_breweryId",
                table: "Beers",
                newName: "IX_Beers_breweryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beers",
                table: "Beers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brewerys_breweryId",
                table: "Beers",
                column: "breweryId",
                principalTable: "Brewerys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewerys_breweryId",
                table: "Beers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beers",
                table: "Beers");

            migrationBuilder.RenameTable(
                name: "Beers",
                newName: "Beer");

            migrationBuilder.RenameIndex(
                name: "IX_Beers_breweryId",
                table: "Beer",
                newName: "IX_Beer_breweryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beer",
                table: "Beer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beer_Brewerys_breweryId",
                table: "Beer",
                column: "breweryId",
                principalTable: "Brewerys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
