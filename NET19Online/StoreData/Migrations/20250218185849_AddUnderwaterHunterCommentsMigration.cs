using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddUnderwaterHunterCommentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnderwaterHunterComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HunterIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderwaterHunterComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterIdId",
                        column: x => x.HunterIdId,
                        principalTable: "UnderwaterHunters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnderwaterHunterComments_HunterIdId",
                table: "UnderwaterHunterComments",
                column: "HunterIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnderwaterHunterComments");
        }
    }
}
