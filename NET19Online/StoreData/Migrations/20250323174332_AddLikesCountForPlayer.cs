using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations
{
    /// <inheritdoc />
    public partial class AddLikesCountForPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "FootballPlayers");
        }
    }
}
