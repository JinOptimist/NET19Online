using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorToDeviceReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "GamingDeviceReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamingDeviceReviews_AuthorId",
                table: "GamingDeviceReviews",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamingDeviceReviews_Users_AuthorId",
                table: "GamingDeviceReviews",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamingDeviceReviews_Users_AuthorId",
                table: "GamingDeviceReviews");

            migrationBuilder.DropIndex(
                name: "IX_GamingDeviceReviews_AuthorId",
                table: "GamingDeviceReviews");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "GamingDeviceReviews");
        }
    }
}
