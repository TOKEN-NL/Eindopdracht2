using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Eindopdracht2.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsPrivate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();

    }
}