using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Migrations
{
    public partial class addnewfeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Wallet",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesBought",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "TimesBought",
                table: "Song");
        }
    }
}
