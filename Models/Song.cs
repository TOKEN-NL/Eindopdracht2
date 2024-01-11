using System;
using System.Collections.ObjectModel;

namespace Eindopdracht2.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationInSeconds { get; set; }

        public ObservableCollection<Album> Albums { get; set; }
    }
}
