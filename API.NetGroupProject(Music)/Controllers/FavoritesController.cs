using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.NetGroupProject_Music_.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.NetGroupProject_Music_.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly MusicProjectDbContext _context;

        public FavoritesController(MusicProjectDbContext context)
        {
            _context = context;
        }

        // GET: Favorites
        public async Task<IActionResult> Index()
        {
            var musicProjectDbContext = _context.Favorites.Include(f => f.User);
            return View(await musicProjectDbContext.ToListAsync());
        }

        // GET: Favorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorites == null)
            {
                return NotFound();
            }

            return View(favorites);
        }

        // GET: Favorites/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Favorites, "Id", "Id");
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArtistId,AlbumId,TrackId,Track,Album,Artist,UserId")] Favorites favorites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Favorites, "Id", "Id", favorites.UserId);
            return View(favorites);
        }

        // GET: Favorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites.FindAsync(id);
            if (favorites == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Favorites, "Id", "Id", favorites.UserId);
            return View(favorites);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistId,AlbumId,TrackId,Track,Album,Artist,UserId")] Favorites favorites)
        {
            if (id != favorites.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoritesExists(favorites.Id))
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
            ViewData["UserId"] = new SelectList(_context.Favorites, "Id", "Id", favorites.UserId);
            return View(favorites);
        }

        // GET: Favorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorites == null)
            {
                return NotFound();
            }

            return View(favorites);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorites = await _context.Favorites.FindAsync(id);
            _context.Favorites.Remove(favorites);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoritesExists(int id)
        {
            return _context.Favorites.Any(e => e.Id == id);
        }
    }
}
