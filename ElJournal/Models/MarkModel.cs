using ElJournal.Entities;
using ElJournal.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class MarkModel: IModel<Mark>
    {
        public void Add(Mark mark)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Marks.Add(mark);
                db.SaveChanges();
            }
        }

        public void Remove(Mark mark)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Marks.Remove(mark);
                db.SaveChanges();
            }
        }

        public Mark GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Marks.FirstOrDefault(m => m.MarkID == id);
            }
        }

        public List<Mark> GetMarksByLesson(int lessonid)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Marks.Where(m => m.LessonID == lessonid)
                    .Include(m => m.Student)
                    .OrderBy(m => m.Student.LastName)
                    .ToList();
            }
        }

        public void AddLessonMarks(Lesson lesson, List<Student> studentslist)
        {
            using (var db = new ElJournalDbContext())
            {
                var lessonid = db.Lessons.FirstOrDefault(l => l.Date == lesson.Date && l.Topic == l.Topic).LessonID;
                foreach(var item in studentslist)
                {
                    var newmark = new Mark(item.StudentID, lessonid);
                    Add(newmark);
                }
            }
        }

        public void SetValue(int markid, string value)
        {
            using (var db = new ElJournalDbContext())
            {
                var selectedmark = db.Marks.Find(markid);
                selectedmark.Value = value;
                db.SaveChanges();
            }
        }

        public List<Mark> GetMarksByStudentAndSemester(int studentid, int semesterid)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Marks.Include(m => m.Student)
                    .Include(m => m.Lesson)
                    .Where(m => m.StudentID == studentid && m.Lesson.SemesterID == semesterid)
                    .ToList();
            }
        }
    }
}
