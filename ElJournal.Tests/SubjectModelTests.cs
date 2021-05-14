using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using NUnit.Framework;

namespace ElJournal.Tests
{
    [TestFixture]
    class SubjectModelTests
    {
        [Test]
        public void AddTest()
        {
            var newsubject = new Subject()
            {
                ShortName = "БД",
                Name = "Базы данных"
            };
            var subjectmodel = new SubjectModel();
            subjectmodel.Add(newsubject);
            using (var db = new ElJournalDbContext())
            {
                var find = db.Subjects.FirstOrDefault(f => f.ShortName == "БД" && f.Name == "Базы данных");
                Assert.AreNotEqual(null, find);
            }
        }

        [Test]
        public void RemoveTest()
        {
            using (var db = new ElJournalDbContext())
            {
                var find = db.Subjects.FirstOrDefault(f => f.ShortName == "БД" && f.Name == "Базы данных");
                new SubjectModel().Remove(find);
                var newfind = db.Subjects.FirstOrDefault(f => f.ShortName == "БД" && f.Name == "Базы данных");
                Assert.AreEqual(null, newfind);
            }
        }

        [Test]
        public void FindTest()
        {
            using (var db = new ElJournalDbContext())
            {
                var expected = db.Subjects.FirstOrDefault(e => e.SubjectID == 1);
                var actual = new SubjectModel().GetItemByID(1);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
