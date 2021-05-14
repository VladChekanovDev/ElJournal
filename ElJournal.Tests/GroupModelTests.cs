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
    class GroupModelTests
    {
        [Test]
        public void AddTest()
        {
            var newgroup = new Group()
            {
                Name = "ПЗТ-31",
                Course = 3
            };
            GroupModel usermodel = new GroupModel();
            usermodel.Add(newgroup);
            using (var db = new ElJournalDbContext())
            {
                var findgroup = db.Groups.FirstOrDefault(g => g.Name == "ПЗТ-31" && g.Course == 3);
                Assert.AreNotEqual(null, findgroup);
            }
        }

        [Test]
        public void RemoveTest()
        {
            using (var db = new ElJournalDbContext())
            {
                var findgroup = db.Groups.FirstOrDefault(g => g.Name == "ПЗТ-31" && g.Course == 3);
                new GroupModel().Remove(findgroup);
                var newfindgroup = db.Groups.FirstOrDefault(g => g.Name == "ПЗТ-31" && g.Course == 3);
                Assert.AreEqual(null, newfindgroup);
            }
        }

        [Test]
        public void FindTest()
        {
            using (var db = new ElJournalDbContext())
            {
                var expected = db.Groups.FirstOrDefault(g => g.GroupID == 1);
                var actual = new UserModel().GetItemByID(1);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
