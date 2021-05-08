using ElJournal.Entities;
using ElJournal.Other;
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
                return db.Marks.Where(m => m.LessonID == lessonid).ToList();
            }
        }
    }
}
