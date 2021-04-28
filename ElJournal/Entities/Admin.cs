using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Admin
    {
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

        public Admin()
        {

        }
    }
}
