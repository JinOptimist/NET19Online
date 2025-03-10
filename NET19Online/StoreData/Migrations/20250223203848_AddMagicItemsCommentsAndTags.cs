using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddMagicItemsCommentsAndTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MagicItemComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagicItemId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItemComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicItemComments_MagicItems_MagicItemId",
                        column: x => x.MagicItemId,
                        principalTable: "MagicItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MagicItemComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MagicItemTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItemTags", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemComments_AuthorId",
                table: "MagicItemComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemComments_MagicItemId",
                table: "MagicItemComments",
                column: "MagicItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemDataMagicItemTagData_TagsId",
                table: "MagicItemDataMagicItemTagData",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
 
        }
    }
}
