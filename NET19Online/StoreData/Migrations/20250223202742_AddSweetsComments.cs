using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddSweetsComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SweetsComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SweetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetsComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SweetsComments_Sweets_SweetsId",
                        column: x => x.SweetsId,
                        principalTable: "Sweets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SweetsComments_SweetsId",
                table: "SweetsComments",
                column: "SweetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SweetsComments");
        }
    }
}
