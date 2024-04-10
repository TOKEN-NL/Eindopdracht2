using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eindopdracht2.Data;
using Eindopdracht2.Models;

namespace Eindopdracht2.Controllers
{
    public class SongsController : Controller
    {
        private readonly Eindopdracht2Context _context;

        public SongsController(Eindopdracht2Context context)
        {
            _context = context;
        }
        
        // GET: Songs
        public async Task<IActionResult> Index(string searchTerm)
        {
            if (_context.Songs == null)
            {
                return Problem("Entity set 'Eindopdracht2Context.Songs' is null.");
            }

            // Fetch alle songs uit de database
            var allSongs = await _context.Songs.ToListAsync();

            // Als searchTerm leeg is, toon alle nummers
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(allSongs);
            }

            // Anders, voer client-side filtering uit
            var matchingSongs = allSongs
                .Where(song => song.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                               song.Artist.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                               song.Genre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View(matchingSongs);
        }
        public async Task<IActionResult> Search(string searchTerm)
        {

            if (_context.Songs == null)
            {
                return Problem("Entity set 'Eindopdracht2Context.Songs' is null.");
            }

            // Ensure searchTerm is not null
            searchTerm ??= string.Empty;

            // Fetch all songs from the database
            var allSongs = await _context.Songs.ToListAsync();

            // Perform client-side filtering
            var matchingSongs = allSongs
                .Where(song => song.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View("Index", matchingSongs);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Artist,Genre,ReleaseDate,DurationInSeconds")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Artist,Genre,ReleaseDate,DurationInSeconds")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Songs == null)
            {
                return Problem("Entity set 'Eindopdracht2Context.Songs'  is null.");
            }
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
          return (_context.Songs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public ActionResult Play(string title, int durationInSeconds)
        {
            addSongToTracks()
            // ... code om het nummer af te spelen met de titel en duur ...
        }
    }


}
}
