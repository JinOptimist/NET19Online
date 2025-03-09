using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Premisson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JerseysComments_Users_AuthorId",
                table: "JerseysComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterId",
                table: "UnderwaterHunterComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UnderwaterHunterComments_Users_AuthorId",
                table: "UnderwaterHunterComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sweets");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UnderwaterHunterComments_AuthorId",
                table: "UnderwaterHunterComments");

            migrationBuilder.DropIndex(
                name: "IX_JerseysComments_AuthorId",
                table: "JerseysComments");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "UnderwaterHunterComments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "JerseysComments");

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
