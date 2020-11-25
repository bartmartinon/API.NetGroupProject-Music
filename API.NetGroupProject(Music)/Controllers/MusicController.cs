using API.NetGroupProject_Music_.Models;
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
        public MusicController(MusicDAL dal)
        {
            _dal = dal;
        }
        public async Task<IActionResult> Index()
        {
            var result = _dal.GetAlbumsAsync();
            return View();
        }
    }
}
