using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    public class Mark
    {
        public int MarkID { get; set; }
        public int StudentID { get; set; }
        public string Value { get; set; }
        public int LessonID { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public Mark()
        {

        }

        public Mark(int studentid, int lessonid)
        {
            StudentID = studentid;
            LessonID = lessonid;
            Value = "";
        }
    }
}
