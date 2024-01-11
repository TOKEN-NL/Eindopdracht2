using Eindopdracht2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht2.Controllers
{
    public class PlayController : Controller
    {
        public IActionResult Index()
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

            // Implementeer logica om het nummer af te spelen
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

            // Implementeer logica om de afspeellijst af te spelen
            return View(playlist);
        }
    }
}
