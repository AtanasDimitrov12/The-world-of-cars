using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCarRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarExtras_Cars_CarId1",
                table: "CarExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPictures_Cars_CarId",
                table: "CarPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_CarExtras_CarId1",
                table: "CarExtras");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "CarExtras");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPictures_Cars_CarId",
                table: "CarPictures",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPictures_Cars_CarId",
                table: "CarPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "CarExtras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarExtras_CarId1",
                table: "CarExtras",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarExtras_Cars_CarId1",
                table: "CarExtras",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPictures_Cars_CarId",
                table: "CarPictures",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
