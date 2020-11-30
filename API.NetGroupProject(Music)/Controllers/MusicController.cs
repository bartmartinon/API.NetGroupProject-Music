﻿using API.NetGroupProject_Music_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        

        public async Task<IActionResult> RemoveFavorite (int f)

        {
            var favoriteItem = await _db.Favorites.FindAsync(f + 1);
            _db.Favorites.Remove(favoriteItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Favorites));
        }


        [HttpPost]
        
            public async Task<IActionResult> AddFavorite (int f)



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
        public async Task<IActionResult> AlbumSearchAsync(int albumId)
        {
            var result = await _dal.GetAlbumAsync(albumId);
            return View("TracklistDetails", result);

        }

        //[HttpPost]
        //public IActionResult AddFavorite (Favorites f)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Favorites.Add(f);
        //        _db.SaveChanges();
        //    }
        //    return RedirectToAction("Music/Favorites");
        //}
        /* public IEnumerable<Tracks> MusicSearch()
         {
             return View(Tracks.ToList(); 
         }
        */
        [HttpPost]
        public async Task<IActionResult> GetSearchAsync(MusicSearch model)
        {
            model = new MusicSearch();
           
            


            // MusicTrack model = _db.MusicTracks.Where(x => x.id == id).FirstOrDefault();
            //var result = await _dal.MusicSearch(id);

            
            
            return View("GetSearch");
        } 
        public async Task<IActionResult> GetAlbumDetail(int id) //there is no view for this yet
        {
            Favorites adding = new Favorites(album, artist, artistid, albumid);
            _db.Favorites.Add(adding);
            _db.SaveChanges();
            return RedirectToAction(nameof(Favorites));
        }

        public IActionResult AddFavorite(Favorites f)
        {
            if (ModelState.IsValid)
            {
                _db.Favorites.Add(f);
                _db.SaveChanges();
            }
            return RedirectToAction("Music/Favorites");
        }
        [HttpPost]
        public async Task<IActionResult> AlbumSearchAsync(int albumId)
        {
            var result = await _dal.GetAlbumAsync(albumId);



        //}

        public async Task<IActionResult> MusicSearchResultsAsync(string data)
        {
            var result = await _dal.GetSearchAsync(data);
            return View(result);



        }

    }

           
        

    
}
