using Eindopdracht2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht2.Controllers
{
    public class PlayController : Controller
    {
        public IActionResult Player()
        {
            return View();
        }
        private readonly Eindopdracht2Context _dbContext;

        public PlayController(Eindopdracht2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult PlaySong(int songId)
        {
            var song = _dbContext.Songs.FirstOrDefault(s => s.Id == songId);

            if (song == null)
            {
                return NotFound();
            }
            // ToDo: logica nummer afspelen
            return View(song);
        }

        public IActionResult PlayAlbum(int playlistId)
        {
            var playlist = _dbContext.Albums
                .Include(p => p.Songs) 
                .FirstOrDefault(p => p.Id == playlistId);

            if (playlist == null)
            {
                return NotFound();
            }

            // ToDo: logica afspeellijst afspelen
            
            return View();
        }
        [HttpGet]
        public IActionResult GetSongDuration(string title)
        {
            var song = _dbContext.Songs.FirstOrDefault(s => s.Title == title);
            if (song != null)
            {
                return Ok(song.DurationInSeconds);
            }

            return NotFound("Nummer niet gevonden.");
        }
    }
}
