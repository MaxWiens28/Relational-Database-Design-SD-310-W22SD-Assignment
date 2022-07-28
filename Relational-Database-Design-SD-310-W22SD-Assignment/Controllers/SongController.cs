using Microsoft.AspNetCore.Mvc;
using Relational_Database_Design_SD_310_W22SD_Assignment.Models;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Controllers
{
    public class SongController : Controller
    {
        private MusicPlayerContext _db;
        public SongController(MusicPlayerContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult TopThreeRatedSongs()
        {
           return View(_db.Songs.OrderBy(s => s.Rating).Take(3).ToList());
        }
        public IActionResult MostBoughtSong()
        {
            return View(_db.Songs.OrderBy(s => s.TimesBought).Take(1).ToList());
        }
    }
}
