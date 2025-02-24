using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    /// <inheritdoc />
    public partial class AddGamingDeviceReviewsAndStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamingDeviceReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamingDeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingDeviceReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamingDeviceReviews_GamingDevices_GamingDeviceId",
                        column: x => x.GamingDeviceId,
                        principalTable: "GamingDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingDeviceStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingDeviceStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamingDeviceDataGamingDeviceStockData",
                columns: table => new
                {
                    GamingDevicesId = table.Column<int>(type: "int", nullable: false),
                    StocksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingDeviceDataGamingDeviceStockData", x => new { x.GamingDevicesId, x.StocksId });
                    table.ForeignKey(
                        name: "FK_GamingDeviceDataGamingDeviceStockData_GamingDeviceStocks_StocksId",
                        column: x => x.StocksId,
                        principalTable: "GamingDeviceStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamingDeviceDataGamingDeviceStockData_GamingDevices_GamingDevicesId",
                        column: x => x.GamingDevicesId,
                        principalTable: "GamingDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamingDeviceDataGamingDeviceStockData_StocksId",
                table: "GamingDeviceDataGamingDeviceStockData",
                column: "StocksId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingDeviceReviews_GamingDeviceId",
                table: "GamingDeviceReviews",
                column: "GamingDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamingDeviceDataGamingDeviceStockData");

            migrationBuilder.DropTable(
                name: "GamingDeviceReviews");

            migrationBuilder.DropTable(
                name: "GamingDeviceStocks");
        }
    }
}
