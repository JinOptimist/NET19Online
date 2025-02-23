using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddPlayerTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerDataPlayerTagData",
                columns: table => new
                {
                    PlayersId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDataPlayerTagData", x => new { x.PlayersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PlayerDataPlayerTagData_FootballPlayers_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerDataPlayerTagData_PlayerTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "PlayerTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDataPlayerTagData_TagsId",
                table: "PlayerDataPlayerTagData",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDataPlayerTagData");

            migrationBuilder.DropTable(
                name: "PlayerTags");
        }
    }
}
