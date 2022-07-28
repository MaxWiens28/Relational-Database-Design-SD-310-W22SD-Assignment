﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Relational_Database_Design_SD_310_W22SD_Assignment.Models;

#nullable disable

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Migrations
{
    [DbContext(typeof(MusicPlayerContext))]
    [Migration("20220714004422_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArtistsName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<string>("SongName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Song", (string)null);
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.SongList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArtistsId")
                        .HasColumnType("int")
                        .HasColumnName("ArtistsID");

                    b.Property<int>("SongId")
                        .HasColumnType("int")
                        .HasColumnName("SongID");

                    b.HasKey("Id");

                    b.HasIndex("ArtistsId");

                    b.HasIndex("SongId");

                    b.ToTable("SongList", (string)null);
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.UsersSongList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SongId")
                        .HasColumnType("int")
                        .HasColumnName("SongID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersSongList", (string)null);
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.SongList", b =>
                {
                    b.HasOne("Relational_Database_Design_SD_310_W22SD_Assignment.Models.Artist", "Artists")
                        .WithMany("SongLists")
                        .HasForeignKey("ArtistsId")
                        .IsRequired()
                        .HasConstraintName("ArtistToSongList");

                    b.HasOne("Relational_Database_Design_SD_310_W22SD_Assignment.Models.Song", "Song")
                        .WithMany("SongLists")
                        .HasForeignKey("SongId")
                        .IsRequired()
                        .HasConstraintName("SongToSongList");

                    b.Navigation("Artists");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.UsersSongList", b =>
                {
                    b.HasOne("Relational_Database_Design_SD_310_W22SD_Assignment.Models.Song", "Song")
                        .WithMany("UsersSongLists")
                        .HasForeignKey("SongId")
                        .IsRequired()
                        .HasConstraintName("SongToUsersSongList");

                    b.HasOne("Relational_Database_Design_SD_310_W22SD_Assignment.Models.User", "User")
                        .WithMany("UsersSongLists")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("UsersToUsersSongList");

                    b.Navigation("Song");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.Artist", b =>
                {
                    b.Navigation("SongLists");
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.Song", b =>
                {
                    b.Navigation("SongLists");

                    b.Navigation("UsersSongLists");
                });

            modelBuilder.Entity("Relational_Database_Design_SD_310_W22SD_Assignment.Models.User", b =>
                {
                    b.Navigation("UsersSongLists");
                });
#pragma warning restore 612, 618
        }
    }
}
