using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
