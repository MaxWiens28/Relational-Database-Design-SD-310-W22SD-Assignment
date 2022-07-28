using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relational_Database_Design_SD_310_W22SD_Assignment.Models;
using Relational_Database_Design_SD_310_W22SD_Assignment.Models.ViewModels;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Controllers
{
    public class ArtistController : Controller
    {
        private MusicPlayerContext _db;
        public ArtistController(MusicPlayerContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            ArtistSelectViewModel avm = new ArtistSelectViewModel(_db.Artists.ToList());
            return View(avm);
        }
        
        public IActionResult MostArtist()
        {
            return View(_db.Artists.Include(sl => sl.SongLists).ThenInclude(s => s.Song).OrderBy(sl => sl.SongLists.Max(s => s.Song.TimesBought)).Take(1));
        }
       

        public IActionResult ArtistDetails(int? id)
        {
            ArtistSelectViewModel vm;
            if (id == null)
            {
                vm = new ArtistSelectViewModel(_db.Artists.ToList());
                return View(vm);
            }
            else
            {
                try
                {
                    Artist selectedArtist = _db.Artists.First(a => a.Id == id);

                    List<Song> songs = _db.Songs.Include(s => s.SongLists)
                        .ThenInclude(s => s.Artists).Where(s => s.SongLists.Any(s => s.Artists.Id  == id)).ToList();

                    vm = new ArtistSelectViewModel(_db.Artists.ToList(), selectedArtist, songs);
                    return View(vm);
                }catch(Exception ex)
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }
    }
}
