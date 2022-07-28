using System;
using System.Collections.Generic;

namespace Relational_Database_Design_SD_310_W22SD_Assignment.Models
{
    public partial class User
    {
        public User()
        {
            UsersSongLists = new HashSet<UsersSongList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Wallet { get; set; }
        public virtual ICollection<UsersSongList> UsersSongLists { get; set; }
    }
}
