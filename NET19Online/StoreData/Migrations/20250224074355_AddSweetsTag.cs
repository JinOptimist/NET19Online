using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddSweetsTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SweetsTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetsTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SweetsDataSweetsTagData",
                columns: table => new
                {
                    SweetsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetsDataSweetsTagData", x => new { x.SweetsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_SweetsDataSweetsTagData_SweetsTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "SweetsTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SweetsDataSweetsTagData_Sweets_SweetsId",
                        column: x => x.SweetsId,
                        principalTable: "Sweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SweetsDataSweetsTagData_TagsId",
                table: "SweetsDataSweetsTagData",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SweetsDataSweetsTagData");

            migrationBuilder.DropTable(
                name: "SweetsTags");
        }
    }
}
