using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class TeacherToSubject
    {
        public int TeacherToSubjectID { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
