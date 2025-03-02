﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreData;

#nullable disable

namespace StoreData.Migrations.StoreDb
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20250302113017_FilmsMigration0204")]
    partial class FilmsMigration0204
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IdolDataIdolTagData", b =>
                {
                    b.Property<int>("IdolsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("IdolsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("IdolDataIdolTagData");
                });

            modelBuilder.Entity("JerseyDataJerseyTagData", b =>
                {
                    b.Property<int>("JerseysId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("JerseysId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("JerseyDataJerseyTagData");
                });

            modelBuilder.Entity("MagicItemDataMagicItemTagData", b =>
                {
                    b.Property<int>("MagicItemsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("MagicItemsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("MagicItemDataMagicItemTagData");
                });

            modelBuilder.Entity("PlayerDataPlayerTagData", b =>
                {
                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("PlayersId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PlayerDataPlayerTagData");
                });

            modelBuilder.Entity("StoreData.Models.DescriptionFilmData", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionFilm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DescriptionFilms");
                });

            modelBuilder.Entity("StoreData.Models.FilmCommentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmCommentDatas");
                });

            modelBuilder.Entity("StoreData.Models.FilmData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FilmDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("StoreData.Models.GamingDeviceData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GamingDevices");
                });

            modelBuilder.Entity("StoreData.Models.IdolCommentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("IdolId");

                    b.ToTable("IdolComments");
                });

            modelBuilder.Entity("StoreData.Models.IdolData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Idols");
                });

            modelBuilder.Entity("StoreData.Models.IdolTagData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdolTags");
                });

            modelBuilder.Entity("StoreData.Models.JerseyCommentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("JerseyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("JerseyId");

                    b.ToTable("JerseysComments");
                });

            modelBuilder.Entity("StoreData.Models.JerseyData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AthleteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Club")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Jerseys");
                });

            modelBuilder.Entity("StoreData.Models.JerseyTagData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JerseysTags");
                });

            modelBuilder.Entity("StoreData.Models.MagicItemCommentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("MagicItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MagicItemId");

                    b.ToTable("MagicItemComments");
                });

            modelBuilder.Entity("StoreData.Models.MagicItemData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemsInStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MagicItems");
                });

            modelBuilder.Entity("StoreData.Models.MagicItemTagData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MagicItemTags");
                });

            modelBuilder.Entity("StoreData.Models.NotebookCommentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotebookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotebookId");

                    b.ToTable("NotebookComments");
                });

            modelBuilder.Entity("StoreData.Models.NotebookData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notebooks");
                });

            modelBuilder.Entity("StoreData.Models.PlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FootballPlayers");
                });

            modelBuilder.Entity("StoreData.Models.PlayerDescriptionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerDescriptions");
                });

            modelBuilder.Entity("StoreData.Models.PlayerTagData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlayerTags");
                });

            modelBuilder.Entity("StoreData.Models.RoleData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Permisson")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("StoreData.Models.SweetsData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sweets");
                });

            modelBuilder.Entity("StoreData.Models.UnderwaterHunterCommentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<int>("HunterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("HunterId");

                    b.ToTable("UnderwaterHunterComments");
                });

            modelBuilder.Entity("StoreData.Models.UnderwaterHunterData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxHuntingDepth")
                        .HasColumnType("int");

                    b.Property<string>("NameHunter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnderwaterHunters");
                });

            modelBuilder.Entity("StoreData.Models.UnderwaterHunterTagData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnderwaterHunterTags");
                });

            modelBuilder.Entity("StoreData.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UnderwaterHunterDataUnderwaterHunterTagData", b =>
                {
                    b.Property<int>("HuntersId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("HuntersId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("UnderwaterHunterDataUnderwaterHunterTagData");
                });

            modelBuilder.Entity("IdolDataIdolTagData", b =>
                {
                    b.HasOne("StoreData.Models.IdolData", null)
                        .WithMany()
                        .HasForeignKey("IdolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreData.Models.IdolTagData", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JerseyDataJerseyTagData", b =>
                {
                    b.HasOne("StoreData.Models.JerseyData", null)
                        .WithMany()
                        .HasForeignKey("JerseysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreData.Models.JerseyTagData", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MagicItemDataMagicItemTagData", b =>
                {
                    b.HasOne("StoreData.Models.MagicItemData", null)
                        .WithMany()
                        .HasForeignKey("MagicItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreData.Models.MagicItemTagData", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayerDataPlayerTagData", b =>
                {
                    b.HasOne("StoreData.Models.PlayerData", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreData.Models.PlayerTagData", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreData.Models.DescriptionFilmData", b =>
                {
                    b.HasOne("StoreData.Models.FilmData", "Films")
                        .WithOne("DescriptionFilms")
                        .HasForeignKey("StoreData.Models.DescriptionFilmData", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Films");
                });

            modelBuilder.Entity("StoreData.Models.FilmCommentData", b =>
                {
                    b.HasOne("StoreData.Models.FilmData", "Film")
                        .WithMany("Comments")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("StoreData.Models.IdolCommentData", b =>
                {
                    b.HasOne("StoreData.Models.UserData", "Author")
                        .WithMany("IdolComments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("StoreData.Models.IdolData", "Idol")
                        .WithMany("Comments")
                        .HasForeignKey("IdolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Idol");
                });

            modelBuilder.Entity("StoreData.Models.JerseyCommentData", b =>
                {
                    b.HasOne("StoreData.Models.UserData", "Author")
                        .WithMany("JerseyComments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("StoreData.Models.JerseyData", "Jersey")
                        .WithMany("Comments")
                        .HasForeignKey("JerseyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Jersey");
                });

            modelBuilder.Entity("StoreData.Models.MagicItemCommentData", b =>
                {
                    b.HasOne("StoreData.Models.UserData", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("StoreData.Models.MagicItemData", "MagicItem")
                        .WithMany("Comments")
                        .HasForeignKey("MagicItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("MagicItem");
                });

            modelBuilder.Entity("StoreData.Models.NotebookCommentData", b =>
                {
                    b.HasOne("StoreData.Models.NotebookData", "Notebook")
                        .WithMany("Comments")
                        .HasForeignKey("NotebookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notebook");
                });

            modelBuilder.Entity("StoreData.Models.PlayerDescriptionData", b =>
                {
                    b.HasOne("StoreData.Models.UserData", "Author")
                        .WithMany("PlayerDescriptions")
                        .HasForeignKey("AuthorId");

                    b.HasOne("StoreData.Models.PlayerData", "Player")
                        .WithMany("Descriptions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("StoreData.Models.UnderwaterHunterCommentData", b =>
                {
                    b.HasOne("StoreData.Models.UserData", "Author")
                        .WithMany("HunterComments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("StoreData.Models.UnderwaterHunterData", "Hunter")
                        .WithMany("Comments")
                        .HasForeignKey("HunterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Hunter");
                });

            modelBuilder.Entity("StoreData.Models.UserData", b =>
                {
                    b.HasOne("StoreData.Models.RoleData", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UnderwaterHunterDataUnderwaterHunterTagData", b =>
                {
                    b.HasOne("StoreData.Models.UnderwaterHunterData", null)
                        .WithMany()
                        .HasForeignKey("HuntersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreData.Models.UnderwaterHunterTagData", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreData.Models.FilmData", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("DescriptionFilms")
                        .IsRequired();
                });

            modelBuilder.Entity("StoreData.Models.IdolData", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StoreData.Models.JerseyData", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StoreData.Models.MagicItemData", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StoreData.Models.NotebookData", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StoreData.Models.PlayerData", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("StoreData.Models.RoleData", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("StoreData.Models.UnderwaterHunterData", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StoreData.Models.UserData", b =>
                {
                    b.Navigation("HunterComments");

                    b.Navigation("IdolComments");

                    b.Navigation("JerseyComments");

                    b.Navigation("PlayerDescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
