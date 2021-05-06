using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class SemesterModel: IModel<Semester>
    {
        public void Add(Semester semester)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Semesters.Add(semester);
                db.SaveChanges();
            }
        }

        public void Remove(Semester semester)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Semesters.Remove(semester);
                db.SaveChanges();
            }
        }

        public Semester GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Semesters.FirstOrDefault(s => s.SemesterID == id);
            }
        }
    }
}
