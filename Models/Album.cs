using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Eindopdracht2.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

       
        public string? CoverImage { get; set; }


        public ICollection<AlbumSong> AlbumSongs { get; set; }


        public string Artist { get; set; }
    }
}
