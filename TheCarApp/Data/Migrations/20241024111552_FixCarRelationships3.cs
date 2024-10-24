using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCarRelationships3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPictures_Cars_CarId1",
                table: "CarPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarId1",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CarId1",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPictures",
                table: "CarPictures");

            migrationBuilder.DropIndex(
                name: "IX_CarPictures_CarId1",
                table: "CarPictures");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "CarPictures");

            migrationBuilder.RenameColumn(
                name: "CarId1",
                table: "CarPictures",
                newName: "CarPictureId");

            migrationBuilder.AlterColumn<int>(
                name: "CarPictureId",
                table: "CarPictures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPictures",
                table: "CarPictures",
                column: "CarPictureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPictures",
                table: "CarPictures");

            migrationBuilder.RenameColumn(
                name: "CarPictureId",
                table: "CarPictures",
                newName: "CarId1");

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CarId1",
                table: "CarPictures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "CarPictures",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPictures",
                table: "CarPictures",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId1",
                table: "Rentals",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_CarPictures_CarId1",
                table: "CarPictures",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPictures_Cars_CarId1",
                table: "CarPictures",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cars_CarId1",
                table: "Rentals",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
