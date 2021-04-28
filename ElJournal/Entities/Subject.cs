using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public List<Mark> Marks { get; set; }
        public List<TeacherToSubject> TeacherToSubjects { get; set; }
    }
}
