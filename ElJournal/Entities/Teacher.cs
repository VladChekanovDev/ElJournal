using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public bool IsSelected { get; set; }

        public Teacher()
        {

        }

        public Teacher(string firstname, string lastname, string patronymic)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Patronymic = patronymic;
        }
    }
}
