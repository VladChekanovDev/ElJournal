using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Lesson
    {
        public int LessonID { get; set; }
        public int SubjectID { get; set; }
        public int GTSID { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public int Semester { get; set; }
        public List<Mark> Marks { get; set; }
        public GroupToSubject GroupToSubject { get; set; }

        public Lesson()
        {

        }
    }
}
