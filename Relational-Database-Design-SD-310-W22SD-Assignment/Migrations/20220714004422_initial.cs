using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SongList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistsID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongList", x => x.ID);
                    table.ForeignKey(
                        name: "ArtistToSongList",
                        column: x => x.ArtistsID,
                        principalTable: "Artist",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "SongToSongList",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UsersSongList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSongList", x => x.ID);
                    table.ForeignKey(
                        name: "SongToUsersSongList",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "UsersToUsersSongList",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongList_ArtistsID",
                table: "SongList",
                column: "ArtistsID");

            migrationBuilder.CreateIndex(
                name: "IX_SongList_SongID",
                table: "SongList",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSongList_SongID",
                table: "UsersSongList",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSongList_UserID",
                table: "UsersSongList",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongList");

            migrationBuilder.DropTable(
                name: "UsersSongList");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
