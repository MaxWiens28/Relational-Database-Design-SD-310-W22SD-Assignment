using System;
using System.Collections.Generic;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models
{
    public partial class SongList
    {
        public int Id { get; set; }
        public int ArtistsId { get; set; }
        public int SongId { get; set; }

        public virtual Artist Artists { get; set; } = null!;
        public virtual Song Song { get; set; } = null!;
    }
}
