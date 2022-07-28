using Microsoft.AspNetCore.Mvc.Rendering;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models.ViewModels
{
    public class UserSelectViewModel
    {
        public User? SelectedUser { get; set; }
        public List<Song>? UserSongs { get; set; }
        public List<SelectListItem> UserSelectItems { get; set; }
        public UserSelectViewModel(List<User> users)
        {
            UserSelectItems = new List<SelectListItem>();

            foreach (User u in users)
            {
                UserSelectItems.Add(new SelectListItem(u.Name, u.Id.ToString()));
            }

        }
        public UserSelectViewModel(List<User> users, User selectedUser, List<Song> userSongs)
        {
            UserSelectItems = new List<SelectListItem>();

            SelectedUser = selectedUser;
            UserSongs = userSongs;

            foreach (User u in users)
            {
                UserSelectItems.Add(new SelectListItem(u.Name, u.Id.ToString()));
            }
        }
    }
}
