using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public List<Student> Students { get; set; }
    }
}
