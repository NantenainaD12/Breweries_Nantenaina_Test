using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasserieTest.Migrations
{
    /// <inheritdoc />
    public partial class beertobrewerymigration002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBrewery",
                table: "Beers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdBrewery",
                table: "Beers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
