using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Models
{
    class LessonModel : IModel<Lesson>
    {
        public void Add(Lesson lesson)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
            }
        }

        public void Remove(Lesson lesson)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Lessons.Remove(lesson);
                db.SaveChanges();
            }
        }

        public Lesson GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Lessons.Find(id);
            }
        }
    }
}
