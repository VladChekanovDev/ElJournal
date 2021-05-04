using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElJournal.Entities
{
    class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public List<Student> Students { get; set; }
        public List<GroupToSubject> GroupToSubjects { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }

        public Group()
        {

        }

        public Group(string name, int course)
        {
            this.Name = name;
            this.Course = course;
        }
    }
}
