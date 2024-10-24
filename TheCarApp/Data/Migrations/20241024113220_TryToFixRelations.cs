using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TryToFixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarExtras_Cars_CarId",
                table: "CarExtras");

            migrationBuilder.AddForeignKey(
                name: "FK_CarExtras_Cars_CarId",
                table: "CarExtras",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarExtras_Cars_CarId",
                table: "CarExtras");

            migrationBuilder.AddForeignKey(
                name: "FK_CarExtras_Cars_CarId",
                table: "CarExtras",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
