using ElJournal.Entities;
using ElJournal.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class StudentModel: IModel<Student>
    {
        public void Add(Student student)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void Remove(Student student)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public Student GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Students.FirstOrDefault(s => s.StudentID == id);
            }
        }

        public List<Student> GetList()
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Students.ToList();
            }
        }

        public List<Student> GetConnectionedList()
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Students.Include(s => s.Group).ToList();
            }
        }

        public void EditStudent(int id, Student newstudent)
        {
            using (var db = new ElJournalDbContext())
            {
                var student = db.Students.FirstOrDefault(s => s.StudentID == id);
                student.FirstName = newstudent.FirstName;
                student.LastName = newstudent.LastName;
                student.Patronymic = newstudent.Patronymic;
                student.GroupID = newstudent.GroupID;
                db.SaveChanges();
            }
        }

        public List<Student> GetStudentsByGroup(int groupid)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Students.Where(s => s.GroupID == groupid).ToList();
            }
        }
    }
}
