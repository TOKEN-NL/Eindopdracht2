using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eindopdracht2.Models;

namespace Eindopdracht2.Data
{
    public class Eindopdracht2Context : DbContext
    {
        public Eindopdracht2Context(DbContextOptions<Eindopdracht2Context> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumSong>()
                .HasKey(sa => new { sa.SongId, sa.AlbumId });

            modelBuilder.Entity<AlbumSong>()
                .HasOne(sa => sa.Song)
                .WithMany(song => song.AlbumSongs)
                .HasForeignKey(sa => sa.SongId);

            modelBuilder.Entity<AlbumSong>()
                .HasOne(sa => sa.Album)
                .WithMany(album => album.AlbumSongs)
                .HasForeignKey(sa => sa.AlbumId);


            base.OnModelCreating(modelBuilder);
        }

    }
}