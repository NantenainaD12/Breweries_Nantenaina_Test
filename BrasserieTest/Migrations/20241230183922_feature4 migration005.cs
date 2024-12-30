using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasserieTest.Migrations
{
    /// <inheritdoc />
    public partial class feature4migration005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WholesalersBeers_Beers_IdBeer",
                table: "WholesalersBeers");

            migrationBuilder.DropForeignKey(
                name: "FK_WholesalersBeers_Wholesalers_IdWholesaler",
                table: "WholesalersBeers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WholesalersBeers",
                table: "WholesalersBeers");

            migrationBuilder.DropIndex(
                name: "IX_WholesalersBeers_IdWholesaler",
                table: "WholesalersBeers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "WholesalersBeers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BeerId",
                table: "WholesalersBeers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WholesalerId",
                table: "WholesalersBeers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WholesalersBeers",
                table: "WholesalersBeers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WholesalersBeers_BeerId",
                table: "WholesalersBeers",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesalersBeers_WholesalerId",
                table: "WholesalersBeers",
                column: "WholesalerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalersBeers_Beers_BeerId",
                table: "WholesalersBeers",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalersBeers_Wholesalers_WholesalerId",
                table: "WholesalersBeers",
                column: "WholesalerId",
                principalTable: "Wholesalers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WholesalersBeers_Beers_BeerId",
                table: "WholesalersBeers");

            migrationBuilder.DropForeignKey(
                name: "FK_WholesalersBeers_Wholesalers_WholesalerId",
                table: "WholesalersBeers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WholesalersBeers",
                table: "WholesalersBeers");

            migrationBuilder.DropIndex(
                name: "IX_WholesalersBeers_BeerId",
                table: "WholesalersBeers");

            migrationBuilder.DropIndex(
                name: "IX_WholesalersBeers_WholesalerId",
                table: "WholesalersBeers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WholesalersBeers");

            migrationBuilder.DropColumn(
                name: "BeerId",
                table: "WholesalersBeers");

            migrationBuilder.DropColumn(
                name: "WholesalerId",
                table: "WholesalersBeers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WholesalersBeers",
                table: "WholesalersBeers",
                columns: new[] { "IdBeer", "IdWholesaler" });

            migrationBuilder.CreateIndex(
                name: "IX_WholesalersBeers_IdWholesaler",
                table: "WholesalersBeers",
                column: "IdWholesaler");

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalersBeers_Beers_IdBeer",
                table: "WholesalersBeers",
                column: "IdBeer",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalersBeers_Wholesalers_IdWholesaler",
                table: "WholesalersBeers",
                column: "IdWholesaler",
                principalTable: "Wholesalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
