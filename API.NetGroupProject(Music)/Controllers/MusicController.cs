using API.NetGroupProject_Music_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NetGroupProject_Music_.Controllers
{
    public class MusicController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> MusicSearchAsync(string data, string SearchBy)
        {
            if (SearchBy == "artist")
            {
                ViewBag.Artist = data.ToLower();

                var result = await _dal.GetMusicAsync(data);

                return View("MusicSearchResultsArtist", result);
            }
            if (SearchBy == "album")
            {
                ViewBag.Album = data.ToLower();

                var result = await _dal.GetMusicAsync(data);

                return View("MusicSearchResultsAlbum", result);
            }
            if (SearchBy == "song")
            {
                ViewBag.Track = data.ToLower();

                var result = await _dal.GetMusicAsync(data);

                return View("MusicSearchResultsTrack", result);
            }
            else
                return View("index");
        }
        private readonly MusicDAL _dal;
        private readonly MusicProjectDbContext _db;
        public MusicController(MusicDAL dal, MusicProjectDbContext db)
        {
            _dal = dal;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            //var result = await _dal.GetSearchAsync();
            return View();
        }

        public IActionResult Favorites()
        {
            return View(_db.Favorites.ToList());
        }

        [Authorize]
        public IActionResult UserFavorites()
        {
            return View(_db.UserFavorites.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            var favoriteItem = await _db.Favorites.FindAsync(id + 1);
            _db.Favorites.Remove(favoriteItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Favorites));
        }

        [HttpPost]
        public IActionResult AddFavorite(string album, string artist, int artistid, int albumid, int trackid)
        {
            Favorites adding = new Favorites(album, artist, artistid, albumid, trackid);
            _db.Favorites.Add(adding);
            _db.SaveChanges();
            return RedirectToAction(nameof(Favorites));
        }

        public IActionResult AddFavoriteLink(string album, string artist, int artistid, int albumid, int trackid)
        {
            Favorites adding = new Favorites(album, artist, artistid, albumid, trackid);
            _db.Favorites.Add(adding);
            _db.SaveChanges();
            return RedirectToAction(nameof(Favorites));
        }

        [HttpPost]
        public async Task<IActionResult> AlbumSearchAsync(int albumId)
        {
            var result = await _dal.GetAlbumAsync(albumId);

            return View("TracklistDetails", result);
        }

    }
}
