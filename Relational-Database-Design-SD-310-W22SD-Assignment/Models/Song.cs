using System;
using System.Collections.Generic;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models
{
    public partial class Song
    {
        public Song()
        {
            SongLists = new HashSet<SongList>();
            UsersSongLists = new HashSet<UsersSongList>();
        }

        public int Id { get; set; }
        public string SongName { get; set; }
        public TimeSpan Length { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public int TimesBought { get; set; }

        public virtual ICollection<SongList> SongLists { get; set; }
        public virtual ICollection<UsersSongList> UsersSongLists { get; set; }
    }
}
