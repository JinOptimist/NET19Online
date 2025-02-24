using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddLinksBetweenHunterCommentsAndAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "UnderwaterHunterComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnderwaterHunterComments_AuthorId",
                table: "UnderwaterHunterComments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnderwaterHunterComments_Users_AuthorId",
                table: "UnderwaterHunterComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnderwaterHunterComments_Users_AuthorId",
                table: "UnderwaterHunterComments");

            migrationBuilder.DropIndex(
                name: "IX_UnderwaterHunterComments_AuthorId",
                table: "UnderwaterHunterComments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "UnderwaterHunterComments");
        }
    }
}
