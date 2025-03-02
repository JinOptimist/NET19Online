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

            migrationBuilder.CreateTable(
                name: "MagicItemDataMagicItemTagData",
                columns: table => new
                {
                    MagicItemsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItemDataMagicItemTagData", x => new { x.MagicItemsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_MagicItemDataMagicItemTagData_MagicItemTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "MagicItemTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicItemDataMagicItemTagData_MagicItems_MagicItemsId",
                        column: x => x.MagicItemsId,
                        principalTable: "MagicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerDataPlayerTagData",
                columns: table => new
                {
                    PlayersId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDataPlayerTagData", x => new { x.PlayersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PlayerDataPlayerTagData_FootballPlayers_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerDataPlayerTagData_PlayerTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "PlayerTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmCommentDatas_FilmId",
                table: "FilmCommentDatas",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemDataMagicItemTagData_TagsId",
                table: "MagicItemDataMagicItemTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDataPlayerTagData_TagsId",
                table: "PlayerDataPlayerTagData",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionFilms_Films_Id",
                table: "DescriptionFilms",
                column: "Id",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
