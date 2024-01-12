using System.Collections.ObjectModel;

namespace Eindopdracht2.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string? CoverImage { get; set; }
        public ObservableCollection<Song>? Songs { get; set; }
       
    }
}
