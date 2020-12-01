using API.NetGroupProject_Music_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NetGroupProject_Music_.Controllers
{
    public class MusicController : Controller
    {


        private readonly MusicDAL _dal;
        private readonly MusicProjectDbContext _db;
        private MusicProjectDbContext db = new MusicProjectDbContext();
        public MusicController(MusicDAL dal, MusicProjectDbContext db)
        {
            _dal = dal;
            _db = db;
        }
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

                return View("showalbums", result);
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


        [HttpPost]


        public async Task<IActionResult> RemoveFavorite(int id)

        {
            var favoriteItem = await db.Favorites.FindAsync(id);
            db.Favorites.Remove(favoriteItem);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Favorites));
        }







        [HttpPost]
        public async Task<IActionResult> AlbumSearchAsync(int albumId)
        {
            var result = await _dal.GetAlbumAsync(albumId);
            return View("TracklistDetails", result);

        }

     
        [HttpPost]
        public async Task<IActionResult> GetSearchAsync(MusicSearch model)
        {
            model = new MusicSearch();




            // MusicTrack model = _db.MusicTracks.Where(x => x.id == id).FirstOrDefault();
            //var result = await _dal.MusicSearch(id);



            return View("GetSearch");
        }
        [HttpPost]
        public IActionResult AddFavorite (string album, string artist, string artistid, string albumid)
        {
            Favorites adding = new Favorites(album, artist, artistid, albumid);
            _db.Favorites.Add(adding);
            _db.SaveChanges();
            return RedirectToAction("Index", "Favorites");
        }

        

        public async Task<IActionResult> MusicSearchResultsAsync(string data)
        {
            var result = await _dal.GetSearchAsync(data);
            return View(result);



        }
        public async Task<IActionResult> MusicSearchLinkAsync(string data, string SearchBy)
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
        public async Task<IActionResult> AlbumSearchLinkAsync(int albumId)
        {
            var result = await _dal.GetAlbumAsync(albumId);

            return View("TracklistDetails", result);
        }
    }






}
