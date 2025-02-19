﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreData;

#nullable disable

namespace StoreData.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("StoreData.Models.GamingDeviceData", b =>
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

                    b.ToTable("FilmDatas");
                    b.ToTable("GamingDevices");
                });

            modelBuilder.Entity("StoreData.Models.IdolCommentData", b =>
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

                    b.Property<int>("IdolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("JerseyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

            modelBuilder.Entity("StoreData.Models.IdolCommentData", b =>
                {
                    b.HasOne("StoreData.Models.IdolData", "Idol")
                        .WithMany("Comments")
                        .HasForeignKey("IdolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Idol");
                });

            modelBuilder.Entity("StoreData.Models.JerseyCommentData", b =>
                {
                    b.HasOne("StoreData.Models.JerseyData", "Jersey")
                        .WithMany("Comments")
                        .HasForeignKey("JerseyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Jersey");
                });

            modelBuilder.Entity("StoreData.Models.IdolData", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StoreData.Models.JerseyData", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
