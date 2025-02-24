using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddUsersToJerseyStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "JerseysComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JerseysComments_AuthorId",
                table: "JerseysComments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_JerseysComments_Users_AuthorId",
                table: "JerseysComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JerseysComments_Users_AuthorId",
                table: "JerseysComments");

            migrationBuilder.DropIndex(
                name: "IX_JerseysComments_AuthorId",
                table: "JerseysComments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "JerseysComments");
        }
    }
}
