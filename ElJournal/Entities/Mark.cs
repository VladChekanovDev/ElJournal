using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Mark
    {
        public int MarkID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string Value { get; set; }
        public int LessonID { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public Mark()
        {

        }
    }
}
