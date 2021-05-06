using ElJournal.Entities;
using ElJournal.Other;
using Microsoft.EntityFrameworkCore;
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

        public bool IsSemesterExists(int gtsid, int value)
        {
            using (var db = new ElJournalDbContext())
            {
                if (db.Semesters.FirstOrDefault(s => s.GroupToSubjectID == gtsid && s.Value == value) != null)
                {
                    return true;
                }
                else return false;
            }
        }

        public List<Semester> GetSemesters(int groupid, int subjectid)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Semesters.Include(s => s.GroupToSubject)
                    .Where(s => s.GroupToSubject.GroupID == groupid && s.GroupToSubject.SubjectID == subjectid)
                    .ToList();
            }
        }
    }
}
