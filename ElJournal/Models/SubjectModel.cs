using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class SubjectModel: IModel<Subject>
    {
        public void Add(Subject subject)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }
        }

        public void Remove(Subject subject)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Subjects.Remove(subject);
                db.SaveChanges();
            }
        }

        public Subject GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Subjects.FirstOrDefault(s => s.SubjectID == id);
            }
        }

        public List<Subject> GetList()
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Subjects.ToList();
            }
        }

        public void EditSubject(int id, Subject newsubject)
        {
            using (var db = new ElJournalDbContext())
            {
                var subject = db.Subjects.FirstOrDefault(s => s.SubjectID == id);
                subject.ShortName = newsubject.ShortName;
                subject.Name = newsubject.Name;
                db.SaveChanges();
            }
        }
    }
}
