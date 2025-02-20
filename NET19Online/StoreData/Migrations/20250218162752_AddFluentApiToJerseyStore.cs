using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddFluentApiToJerseyStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JerseysComments_Jerseys_IdolId",
                table: "JerseysComments");

            migrationBuilder.RenameColumn(
                name: "IdolId",
                table: "JerseysComments",
                newName: "JerseyId");

            migrationBuilder.RenameIndex(
                name: "IX_JerseysComments_IdolId",
                table: "JerseysComments",
                newName: "IX_JerseysComments_JerseyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JerseysComments_Jerseys_JerseyId",
                table: "JerseysComments",
                column: "JerseyId",
                principalTable: "Jerseys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JerseysComments_Jerseys_JerseyId",
                table: "JerseysComments");

            migrationBuilder.RenameColumn(
                name: "JerseyId",
                table: "JerseysComments",
                newName: "IdolId");

            migrationBuilder.RenameIndex(
                name: "IX_JerseysComments_JerseyId",
                table: "JerseysComments",
                newName: "IX_JerseysComments_IdolId");

            migrationBuilder.AddForeignKey(
                name: "FK_JerseysComments_Jerseys_IdolId",
                table: "JerseysComments",
                column: "IdolId",
                principalTable: "Jerseys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
