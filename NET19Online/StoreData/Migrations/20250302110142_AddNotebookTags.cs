using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddNotebookTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotebookComments_Notebooks_NotebookId",
                table: "NotebookComments");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "NotebookComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotebookTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotebookDataNotebookTagData",
                columns: table => new
                {
                    NotebooksId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookDataNotebookTagData", x => new { x.NotebooksId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_NotebookDataNotebookTagData_NotebookTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "NotebookTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotebookDataNotebookTagData_Notebooks_NotebooksId",
                        column: x => x.NotebooksId,
                        principalTable: "Notebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotebookComments_AuthorId",
                table: "NotebookComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_NotebookDataNotebookTagData_TagsId",
                table: "NotebookDataNotebookTagData",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookComments_Notebooks_NotebookId",
                table: "NotebookComments",
                column: "NotebookId",
                principalTable: "Notebooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookComments_Users_AuthorId",
                table: "NotebookComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotebookComments_Notebooks_NotebookId",
                table: "NotebookComments");

            migrationBuilder.DropForeignKey(
                name: "FK_NotebookComments_Users_AuthorId",
                table: "NotebookComments");

            migrationBuilder.DropTable(
                name: "NotebookDataNotebookTagData");

            migrationBuilder.DropTable(
                name: "NotebookTags");

            migrationBuilder.DropIndex(
                name: "IX_NotebookComments_AuthorId",
                table: "NotebookComments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "NotebookComments");

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookComments_Notebooks_NotebookId",
                table: "NotebookComments",
                column: "NotebookId",
                principalTable: "Notebooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
