using Microsoft.AspNetCore.Mvc.Rendering;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models.ViewModels
{
    public class ArtistSelectViewModel
    {
        public Artist? SelectedArtist { get; set; }
        public List<Song>? ArtistsSongs { get; set; }
        public List<SelectListItem> ArtistSelectItems{ get; set; }   
        public ArtistSelectViewModel(List<Artist> artists)
        {
            ArtistSelectItems = new List<SelectListItem>();

            foreach(Artist a in artists)
            {
                ArtistSelectItems.Add(new SelectListItem(a.ArtistsName, a.Id.ToString()));
            }

        }
        public ArtistSelectViewModel(List<Artist> artists, Artist selectedArtist, List<Song> artistsSongs)
        {
            ArtistSelectItems = new List<SelectListItem>();

            SelectedArtist = selectedArtist;
            ArtistsSongs = artistsSongs;

            foreach (Artist a in artists)
            {
                ArtistSelectItems.Add(new SelectListItem(a.ArtistsName, a.Id.ToString()));
            }
        }
    }
}