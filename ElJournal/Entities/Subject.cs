using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElJournal.Entities
{
    class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<TeacherToSubject> TeacherToSubjects { get; set; }
        public List<GroupToSubject> GroupToSubjects { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }

        public Subject()
        {

        }

        public Subject(string shortname, string name)
        {
            ShortName = shortname;
            Name = name;
        }
    }
}
