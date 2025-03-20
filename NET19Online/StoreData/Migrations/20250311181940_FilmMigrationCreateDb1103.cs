using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations
{
    /// <inheritdoc />
    public partial class FilmMigrationCreateDb1103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCommentDatas_Films_FilmId",
                table: "FilmCommentDatas");



            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCommentDatas",
                table: "FilmCommentDatas");

            migrationBuilder.RenameTable(
                name: "FilmCommentDatas",
                newName: "FilmComments");



            migrationBuilder.RenameIndex(
                name: "IX_FilmCommentDatas_FilmId",
                table: "FilmComments",
                newName: "IX_FilmComments_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmComments",
                table: "FilmComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmComments_Users_UserId",
                table: "FilmComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmComments",
                table: "FilmComments");

            migrationBuilder.RenameTable(
                name: "FilmComments",
                newName: "FilmCommentDatas");

            migrationBuilder.RenameIndex(
                name: "IX_FilmComments_UserId",
                table: "FilmCommentDatas",
                newName: "IX_FilmCommentDatas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmComments_FilmId",
                table: "FilmCommentDatas",
                newName: "IX_FilmCommentDatas_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCommentDatas",
                table: "FilmCommentDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCommentDatas_Films_FilmId",
                table: "FilmCommentDatas",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCommentDatas_Users_UserId",
                table: "FilmCommentDatas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
