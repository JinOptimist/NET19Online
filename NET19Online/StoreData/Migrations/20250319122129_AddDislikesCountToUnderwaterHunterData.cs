using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations
{
    /// <inheritdoc />
    public partial class AddDislikesCountToUnderwaterHunterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DislikesCount",
                table: "UnderwaterHunters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DislikesCount",
                table: "UnderwaterHunters");
        }
    }
}
