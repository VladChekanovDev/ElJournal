using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Teacher
    {
        public int TeacherID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public User User { get; set; }
        public List<TeacherToSubject> TeacherToSubjects { get; set; }
    }
}
