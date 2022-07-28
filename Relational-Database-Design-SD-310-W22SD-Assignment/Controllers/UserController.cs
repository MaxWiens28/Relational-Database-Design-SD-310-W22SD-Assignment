using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relational_Database_Design_SD_310_W22SD_Assignment.Models;
using Relational_Database_Design_SD_310_W22SD_Assignment.Models.ViewModels;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Controllers
{
    public class UserController : Controller
    {
        private MusicPlayerContext _db;
        public UserController(MusicPlayerContext context)
        {
            _db = context;
        }
        public IActionResult Users()
        {
            return View(_db.Users);
        }
        public IActionResult Index()
        {
            UserSelectViewModel vm = new UserSelectViewModel(_db.Users.ToList());
            return View(vm);
        }

        public IActionResult UserPurchasingList(int? id)
        {
            UserSelectViewModel vm;
            if (id == null)
            {
                vm = new UserSelectViewModel(_db.Users.ToList());
                return View(vm);
            }
            else
            {
                try
                {
                    User selectedUser = _db.Users.First(a => a.Id == id);

                    List<Song> songs = _db.Songs.Include(s => s.UsersSongLists)
                        .ThenInclude(s => s.User).Where(s => s.UsersSongLists.Any(s => s.User.Id != id)).OrderBy(s => s.SongName).ToList();

                    vm = new UserSelectViewModel(_db.Users.ToList(), selectedUser, songs);
                    return View(vm);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        public IActionResult UserDetails(int? id)
        {
            UserSelectViewModel vm;
            if (id == null)
            {
                vm = new UserSelectViewModel(_db.Users.ToList());
                return View(vm);
            }
            else
            {
                try
                {
                    User selectedUser = _db.Users.First(a => a.Id == id);

                    List<Song> songs = _db.Songs.Include(s => s.UsersSongLists)
                        .ThenInclude(s => s.User).Where(s => s.UsersSongLists.Any(s => s.User.Id == id)).OrderBy(s => s.SongName).ToList();

                    vm = new UserSelectViewModel(_db.Users.ToList(), selectedUser, songs);
                    return View(vm);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string SongName, TimeSpan Length)
        {
            Song NewSong = new Song();
            NewSong.SongName = SongName;
            NewSong.Length = Length;    
            _db.Songs.Add(NewSong);
            _db.SaveChanges();
            return View();
        }
    }
}
