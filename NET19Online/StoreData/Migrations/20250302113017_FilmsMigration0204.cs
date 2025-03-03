using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class FilmsMigration0204 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmCommentDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCommentDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmCommentDatas_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });


            migrationBuilder.CreateIndex(
                name: "IX_FilmCommentDatas_FilmId",
                table: "FilmCommentDatas",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionFilms_Films_Id",
                table: "DescriptionFilms");

            migrationBuilder.DropTable(
                name: "FilmCommentDatas");

            migrationBuilder.DropTable(
                name: "MagicItemDataMagicItemTagData");

            migrationBuilder.DropTable(
                name: "PlayerDataPlayerTagData");
        }
    }
}
