using System;
using System.Collections.Generic;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models
{
    public partial class Artist
    {
        public Artist()
        {
            SongLists = new HashSet<SongList>();
        }

        public int Id { get; set; }
        public string ArtistsName { get; set; }

        public virtual ICollection<SongList> SongLists { get; set; }
    }
}
