using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models
{
    public partial class MusicPlayerContext : DbContext
    {
        public MusicPlayerContext()
        {
        }

        public MusicPlayerContext(DbContextOptions<MusicPlayerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<SongList> SongLists { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersSongList> UsersSongLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MusicPlayer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArtistsName).HasMaxLength(50);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SongName).HasMaxLength(50);
            });

            modelBuilder.Entity<SongList>(entity =>
            {
                entity.ToTable("SongList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArtistsId).HasColumnName("ArtistsID");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.HasOne(d => d.Artists)
                    .WithMany(p => p.SongLists)
                    .HasForeignKey(d => d.ArtistsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ArtistToSongList");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongLists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SongToSongList");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UsersSongList>(entity =>
            {
                entity.ToTable("UsersSongList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.UsersSongLists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SongToUsersSongList");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersSongLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UsersToUsersSongList");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
