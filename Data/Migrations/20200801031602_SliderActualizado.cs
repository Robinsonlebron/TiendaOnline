using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaOnline.Data.Migrations
{
    public partial class SliderActualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image1",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "image2",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "image3",
                table: "Slider");

            migrationBuilder.RenameColumn(
                name: "image4",
                table: "Slider",
                newName: "image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "Slider",
                newName: "image4");

            migrationBuilder.AddColumn<string>(
                name: "image1",
                table: "Slider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image2",
                table: "Slider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image3",
                table: "Slider",
                nullable: true);
        }
    }
}
