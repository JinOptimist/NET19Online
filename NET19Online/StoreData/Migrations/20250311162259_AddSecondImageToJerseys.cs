using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondImageToJerseys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondImg",
                table: "Jerseys",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondImg",
                table: "Jerseys");
        }
    }
}
