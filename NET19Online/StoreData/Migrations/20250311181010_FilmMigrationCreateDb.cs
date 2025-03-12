using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations
{
    /// <inheritdoc />
    public partial class FilmMigrationCreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCommentDatas_Users_UserId",
                table: "FilmCommentDatas");

            migrationBuilder.DropIndex(
                name: "IX_FilmCommentDatas_UserId",
                table: "FilmCommentDatas");
        }
    }
}
