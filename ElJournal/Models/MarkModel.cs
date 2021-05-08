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
    }
}
