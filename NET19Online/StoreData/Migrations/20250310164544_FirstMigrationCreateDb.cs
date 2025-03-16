using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreData.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationCreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamingDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingDevices", x => x.Id);
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
                name: "Idols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idols", x => x.Id);
                });

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
                name: "Jerseys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Club = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AthleteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jerseys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JerseysTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JerseysTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagicItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemsInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagicItemTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItemTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                });

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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permisson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sweets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sweets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnderwaterHunters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameHunter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHuntingDepth = table.Column<int>(type: "int", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderwaterHunters", x => x.Id);
                });

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
                name: "DescriptionFilms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DescriptionFilm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionFilms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionFilms_Films_Id",
                        column: x => x.Id,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmCommentDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCommentDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmCommentDatas_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "JerseyDataJerseyTagData",
                columns: table => new
                {
                    JerseysId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JerseyDataJerseyTagData", x => new { x.JerseysId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_JerseyDataJerseyTagData_JerseysTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "JerseysTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JerseyDataJerseyTagData_Jerseys_JerseysId",
                        column: x => x.JerseysId,
                        principalTable: "Jerseys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicItemDataMagicItemTagData",
                columns: table => new
                {
                    MagicItemsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItemDataMagicItemTagData", x => new { x.MagicItemsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_MagicItemDataMagicItemTagData_MagicItemTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "MagicItemTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicItemDataMagicItemTagData_MagicItems_MagicItemsId",
                        column: x => x.MagicItemsId,
                        principalTable: "MagicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "IdolComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdolId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdolComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdolComments_Idols_IdolId",
                        column: x => x.IdolId,
                        principalTable: "Idols",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdolComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JerseysComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JerseyId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JerseysComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JerseysComments_Jerseys_JerseyId",
                        column: x => x.JerseyId,
                        principalTable: "Jerseys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JerseysComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MagicItemComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagicItemId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItemComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicItemComments_MagicItems_MagicItemId",
                        column: x => x.MagicItemId,
                        principalTable: "MagicItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MagicItemComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotebookComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotebookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotebookComments_Notebooks_NotebookId",
                        column: x => x.NotebookId,
                        principalTable: "Notebooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotebookComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerDescriptions_FootballPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerDescriptions_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnderwaterHunterComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HunterId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderwaterHunterComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnderwaterHunterComments_UnderwaterHunters_HunterId",
                        column: x => x.HunterId,
                        principalTable: "UnderwaterHunters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnderwaterHunterComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
             name: "Singers",
             columns: table => new
             {
                 Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                 Pseudonym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Style = table.Column<string>(type: "nvarchar(max)", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Singers", x => x.Id);
             });

            migrationBuilder.CreateTable(
                name: "Singers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudonym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SingerComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SingerDataId = table.Column<int>(type: "int", nullable: false),
                    AuthotId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingerComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingerComments_Singers_SingerDataId",
                        column: x => x.SingerDataId,
                        principalTable: "Singers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SingerComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });


            migrationBuilder.CreateIndex(
                name: "IX_FilmCommentDatas_FilmId",
                table: "FilmCommentDatas",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingDeviceDataGamingDeviceStockData_StocksId",
                table: "GamingDeviceDataGamingDeviceStockData",
                column: "StocksId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingDeviceReviews_GamingDeviceId",
                table: "GamingDeviceReviews",
                column: "GamingDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdolComments_AuthorId",
                table: "IdolComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_IdolComments_IdolId",
                table: "IdolComments",
                column: "IdolId");

            migrationBuilder.CreateIndex(
                name: "IX_IdolDataIdolTagData_TagsId",
                table: "IdolDataIdolTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_JerseyDataJerseyTagData_TagsId",
                table: "JerseyDataJerseyTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_JerseysComments_AuthorId",
                table: "JerseysComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_JerseysComments_JerseyId",
                table: "JerseysComments",
                column: "JerseyId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemComments_AuthorId",
                table: "MagicItemComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemComments_MagicItemId",
                table: "MagicItemComments",
                column: "MagicItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemDataMagicItemTagData_TagsId",
                table: "MagicItemDataMagicItemTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_NotebookComments_AuthorId",
                table: "NotebookComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_NotebookComments_NotebookId",
                table: "NotebookComments",
                column: "NotebookId");

            migrationBuilder.CreateIndex(
                name: "IX_NotebookDataNotebookTagData_TagsId",
                table: "NotebookDataNotebookTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDataPlayerTagData_TagsId",
                table: "PlayerDataPlayerTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDescriptions_AuthorId",
                table: "PlayerDescriptions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDescriptions_PlayerId",
                table: "PlayerDescriptions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_UnderwaterHunterComments_AuthorId",
                table: "UnderwaterHunterComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UnderwaterHunterComments_HunterId",
                table: "UnderwaterHunterComments",
                column: "HunterId");

            migrationBuilder.CreateIndex(
                name: "IX_UnderwaterHunterDataUnderwaterHunterTagData_TagsId",
                table: "UnderwaterHunterDataUnderwaterHunterTagData",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SingerComments_AuthorId",
                table: "SingerComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_SingerComments_SingerDataId",
                table: "SingerComments",
                column: "SingerDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookComments_Notebooks_NotebookId",
                table: "NotebookComments",
                column: "NotebookId",
                principalTable: "Notebooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptionFilms");

            migrationBuilder.DropTable(
                name: "FilmCommentDatas");

            migrationBuilder.DropTable(
                name: "GamingDeviceDataGamingDeviceStockData");

            migrationBuilder.DropTable(
                name: "GamingDeviceReviews");

            migrationBuilder.DropTable(
                name: "IdolComments");

            migrationBuilder.DropTable(
                name: "IdolDataIdolTagData");

            migrationBuilder.DropTable(
                name: "JerseyDataJerseyTagData");

            migrationBuilder.DropTable(
                name: "JerseysComments");

            migrationBuilder.DropTable(
                name: "MagicItemComments");

            migrationBuilder.DropTable(
                name: "MagicItemDataMagicItemTagData");

            migrationBuilder.DropTable(
                name: "NotebookComments");

            migrationBuilder.DropTable(
                name: "NotebookDataNotebookTagData");

            migrationBuilder.DropTable(
                name: "PlayerDataPlayerTagData");

            migrationBuilder.DropTable(
                name: "PlayerDescriptions");

            migrationBuilder.DropTable(
                name: "Sweets");

            migrationBuilder.DropTable(
                name: "UnderwaterHunterComments");

            migrationBuilder.DropTable(
                name: "UnderwaterHunterDataUnderwaterHunterTagData");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "GamingDeviceStocks");

            migrationBuilder.DropTable(
                name: "GamingDevices");

            migrationBuilder.DropTable(
                name: "IdolTags");

            migrationBuilder.DropTable(
                name: "Idols");

            migrationBuilder.DropTable(
                name: "JerseysTags");

            migrationBuilder.DropTable(
                name: "Jerseys");

            migrationBuilder.DropTable(
                name: "MagicItemTags");

            migrationBuilder.DropTable(
                name: "MagicItems");

            migrationBuilder.DropTable(
                name: "NotebookTags");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "PlayerTags");

            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UnderwaterHunterTags");

            migrationBuilder.DropTable(
                name: "UnderwaterHunters");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SingerComments");

            migrationBuilder.DropTable(
                name: "Singers");

        }
    }
}
