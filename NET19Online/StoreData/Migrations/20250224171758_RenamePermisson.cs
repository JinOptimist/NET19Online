using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class RenamePermisson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Premisson",
                table: "Roles",
                newName: "Permisson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Permisson",
                table: "Roles",
                newName: "Premisson");
        }
    }
}
