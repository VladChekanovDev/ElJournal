﻿using ElJournal.Entities;
using ElJournal.Other;
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
    }
}