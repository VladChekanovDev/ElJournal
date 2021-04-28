using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class TeacherModel: IModel<Teacher>
    {
        public void Add(Teacher teacher)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
        }

        public void Remove(Teacher teacher)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Teachers.Remove(teacher);
                db.SaveChanges();
            }
        }

        public Teacher GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Teachers.FirstOrDefault(t => t.TeacherID == id);
            }
        }

        public List<Teacher> GetList()
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Teachers.ToList();
            }
        }
    }
}
