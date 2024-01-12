using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Eindopdracht2.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int DurationInSeconds { get; set; }
        public ICollection<AlbumSong> AlbumSongs { get; set; }
    }
}
