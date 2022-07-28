using System;
using System.Collections.Generic;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models
{
    public partial class UsersSongList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }

        public virtual Song Song { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
