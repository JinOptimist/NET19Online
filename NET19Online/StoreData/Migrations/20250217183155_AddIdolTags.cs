using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddIdolTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdolTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdolTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdolDataIdolTagData",
                columns: table => new
                {
                    IdolsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdolDataIdolTagData", x => new { x.IdolsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_IdolDataIdolTagData_IdolTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "IdolTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdolDataIdolTagData_Idols_IdolsId",
                        column: x => x.IdolsId,
                        principalTable: "Idols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdolDataIdolTagData_TagsId",
                table: "IdolDataIdolTagData",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdolDataIdolTagData");

            migrationBuilder.DropTable(
                name: "IdolTags");
        }
    }
}
