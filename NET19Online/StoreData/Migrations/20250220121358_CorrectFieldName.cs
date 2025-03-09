using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class CorrectFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterIdId",
                table: "UnderwaterHunterComments");

            migrationBuilder.RenameColumn(
                name: "HunterIdId",
                table: "UnderwaterHunterComments",
                newName: "HunterId");

            migrationBuilder.RenameIndex(
                name: "IX_UnderwaterHunterComments_HunterIdId",
                table: "UnderwaterHunterComments",
                newName: "IX_UnderwaterHunterComments_HunterId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterId",
                table: "UnderwaterHunterComments",
                column: "HunterId",
                principalTable: "UnderwaterHunters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterId",
                table: "UnderwaterHunterComments");

            migrationBuilder.RenameColumn(
                name: "HunterId",
                table: "UnderwaterHunterComments",
                newName: "HunterIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UnderwaterHunterComments_HunterId",
                table: "UnderwaterHunterComments",
                newName: "IX_UnderwaterHunterComments_HunterIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterIdId",
                table: "UnderwaterHunterComments",
                column: "HunterIdId",
                principalTable: "UnderwaterHunters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
