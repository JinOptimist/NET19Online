using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddHunterTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterIdId",
                table: "UnderwaterHunterComments");

            migrationBuilder.AlterColumn<int>(
                name: "HunterIdId",
                table: "UnderwaterHunterComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UnderwaterHunterTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderwaterHunterTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnderwaterHunterDataUnderwaterHunterTagData",
                columns: table => new
                {
                    HuntersId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderwaterHunterDataUnderwaterHunterTagData", x => new { x.HuntersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_UnderwaterHunterDataUnderwaterHunterTagData_UnderwaterHunterTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "UnderwaterHunterTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnderwaterHunterDataUnderwaterHunterTagData_UnderwaterHunters_HuntersId",
                        column: x => x.HuntersId,
                        principalTable: "UnderwaterHunters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnderwaterHunterDataUnderwaterHunterTagData_TagsId",
                table: "UnderwaterHunterDataUnderwaterHunterTagData",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterIdId",
                table: "UnderwaterHunterComments",
                column: "HunterIdId",
                principalTable: "UnderwaterHunters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterIdId",
                table: "UnderwaterHunterComments");

            migrationBuilder.DropTable(
                name: "UnderwaterHunterDataUnderwaterHunterTagData");

            migrationBuilder.DropTable(
                name: "UnderwaterHunterTags");

            migrationBuilder.AlterColumn<int>(
                name: "HunterIdId",
                table: "UnderwaterHunterComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterIdId",
                table: "UnderwaterHunterComments",
                column: "HunterIdId",
                principalTable: "UnderwaterHunters",
                principalColumn: "Id");
        }
    }
}
