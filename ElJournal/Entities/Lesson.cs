using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Lesson
    {
        public int LessonID { get; set; }
        public int SubjectID { get; set; }
        public int SemesterID { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string LessonType { get; set; }
        public List<Mark> Marks { get; set; }
        public Semester Semester { get; set; }

        public Lesson()
        {

        }

        public Lesson(int semesterid, DateTime date, string topic, string lessontype)
        {
            SemesterID = semesterid;
            Date = date;
            Topic = topic;
            LessonType = lessontype;
        }
    }
}
