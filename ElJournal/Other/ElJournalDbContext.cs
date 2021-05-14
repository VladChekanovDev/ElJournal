using ElJournal.Entities;
using ElJournal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Other
{
    public class ElJournalDbContext: DbContext
    {
        public ElJournalDbContext(): base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=./ElJournalDB.db");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherToSubject> TeacherToSubjects { get; set; }
        public DbSet<GroupToSubject> GroupToSubjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Semester> Semesters { get; set; }
    }
}
