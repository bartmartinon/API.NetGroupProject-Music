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
        private readonly MusicDAL _dal;
        private readonly MusicProjectDbContext _db = new MusicProjectDbContext();
        public MusicController(MusicDAL dal)
        {
            _dal = dal;
        }
        public async Task<IActionResult> Index()
        {
            //var result = await _dal.GetSearchAsync();
            return View();
        }

        public async Task<IActionResult> MusicSearchAsync(string artist)
        {

            var result = await _dal.GetMusicAsync(artist);

            return View(result); 
        }
        public async Task<IActionResult> AlbumSearchAsync(string album)
        {

            var result = await _dal.GetMusicAsync(album);
            ViewBag.Album = album;

            return View(result);
        }
        public async Task<IActionResult> TrackSearchAsync(string song)
        {

            var result = await _dal.GetMusicAsync(song);
            ViewBag.Song = song;

            return View(result);
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
        public IActionResult RemoveFavorite (Favorites f)
        {
            if (ModelState.IsValid)
            {
                _db.Favorites.Remove(f);
                _db.SaveChanges();
            }
            return RedirectToAction("/MusicFavorites");
        }

        [HttpPost]
        public IActionResult AddFavorite (Favorites f)
        {
            if (ModelState.IsValid)
            {
                _db.Favorites.Add(f);
                _db.SaveChanges();
            }
            return RedirectToAction("Music/Favorites");
        }

        public IActionResult MusicSearch()
        public async Task<IActionResult> GetAlbumDetail(int id) //there is no view for this yet
        {

            var result = await _dal.GetAlbumAsync(id);

            return View(result);
        }

        public async Task<IActionResult> GetSearchAsync(string data)
        {
            var result = await _dal.GetSearchAsync(data);
            return View(result);



        }

        public async Task<IActionResult> MusicSearchResultsAsync(string data)
        {
            var result = await _dal.GetSearchAsync(data);
            return View(result);



        }

    }
}
