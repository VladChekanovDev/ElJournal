using ElJournal.Entities;
using ElJournal.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Teacher> GetConnectionedList()
        {
            using (var db = new ElJournalDbContext())
            {
                return new ObservableCollection<Teacher>(db.Teachers.Include(t => t.TeacherToSubjects).ThenInclude(tts => tts.Subject).ToList());
            }
        }

        public void EditTeacher(int id, Teacher newteacher)
        {
            using (var db = new ElJournalDbContext())
            {
                var teacher = db.Teachers.FirstOrDefault(t => t.TeacherID == id);
                teacher.FirstName = newteacher.FirstName;
                teacher.LastName = newteacher.LastName;
                teacher.Patronymic = newteacher.Patronymic;
                db.SaveChanges();
            }
        }

        public Teacher GetTeacherByUserID(int userid)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Teachers.FirstOrDefault(t => t.UserID == userid);
            }
        }
    }
}
