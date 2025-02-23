using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddTagsAndCommentsToJerseyStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JerseysComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JerseysComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JerseysComments_Jerseys_IdolId",
                        column: x => x.IdolId,
                        principalTable: "Jerseys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JerseysTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JerseysTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JerseyDataJerseyTagData",
                columns: table => new
                {
                    JerseysId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JerseyDataJerseyTagData", x => new { x.JerseysId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_JerseyDataJerseyTagData_JerseysTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "JerseysTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JerseyDataJerseyTagData_Jerseys_JerseysId",
                        column: x => x.JerseysId,
                        principalTable: "Jerseys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JerseyDataJerseyTagData_TagsId",
                table: "JerseyDataJerseyTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_JerseysComments_IdolId",
                table: "JerseysComments",
                column: "IdolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JerseyDataJerseyTagData");

            migrationBuilder.DropTable(
                name: "JerseysComments");

            migrationBuilder.DropTable(
                name: "JerseysTags");
        }
    }
}
