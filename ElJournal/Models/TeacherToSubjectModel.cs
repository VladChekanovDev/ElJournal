using ElJournal.Entities;
using ElJournal.Other;
using Microsoft.EntityFrameworkCore;
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

        public bool ConnectionExists(int teacherid, int subjectid)
        {
            using (var db = new ElJournalDbContext())
            {
                if (db.TeacherToSubjects.FirstOrDefault(tts => tts.SubjectID == subjectid && tts.TeacherID == teacherid) != null)
                    return true;
                else return false;
            }
        }

        public List<TeacherToSubject> GetTTSsByTeacher(int teacherid)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.TeacherToSubjects.Where(tts => tts.TeacherID == teacherid).Include(tts => tts.Subject).ToList();
            }
        }

        //public void CreateConnection(int teacherid, int subjectid)
        //{
        //    using (var db = new ElJournalDbContext())
        //    {
        //        var teachertosubject = new TeacherToSubject(subjectid, teacherid);
        //        Add(teachertosubject);
        //    }
        //}
    }
}
