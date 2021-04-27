using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public bool IsSelected { get; set; }

        public Student()
        {

        }

        public Student(string firstName, string lastName, string patronymic, int groupID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patronymic = patronymic;
            this.GroupID = groupID;
        }
    }
}
