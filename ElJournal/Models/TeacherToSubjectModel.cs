using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class TeacherToSubjectModel: IModel<TeacherToSubject>
    {
        public void Add(TeacherToSubject teacherToSubject)
        {
            using (var db = new ElJournalDbContext())
            {
                db.TeacherToSubjects.Add(teacherToSubject);
                db.SaveChanges();
            }
        }

        public void Remove(TeacherToSubject teacherToSubject)
        {
            using (var db = new ElJournalDbContext())
            {
                db.TeacherToSubjects.Remove(teacherToSubject);
                db.SaveChanges();
            }
        }

        public TeacherToSubject GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.TeacherToSubjects.FirstOrDefault(u => u.TeacherToSubjectID == id);
            }
        }
    }
}
