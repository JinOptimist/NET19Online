using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddUserFootballPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "PlayerDescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDescriptions_AuthorId",
                table: "PlayerDescriptions",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerDescriptions_Users_AuthorId",
                table: "PlayerDescriptions",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerDescriptions_Users_AuthorId",
                table: "PlayerDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PlayerDescriptions_AuthorId",
                table: "PlayerDescriptions");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "PlayerDescriptions");
        }
    }
}
