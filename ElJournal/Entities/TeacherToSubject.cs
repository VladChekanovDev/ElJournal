using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    public class TeacherToSubject
    {
        public int TeacherToSubjectID { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }

        public TeacherToSubject()
        {

        }

        public TeacherToSubject(int subjectid, int teacherid)
        {
            this.SubjectID = subjectid;
            this.TeacherID = teacherid;
        }
    }
}
