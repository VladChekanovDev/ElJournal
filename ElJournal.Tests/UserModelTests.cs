using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System.Linq;

namespace ElJournal.Tests
{
    [TestFixture]
    class UserModelTests
    {
        [Test]
        public void AddTest()
        {
            var newuser = new User()
            {
                Login = "vlad",
                Pass = "123",
                UserType = 0
            };
            UserModel usermodel = new UserModel();
            usermodel.Add(newuser);
            using (var db = new ElJournalDbContext())
            {
                var finduser = db.Users.FirstOrDefault(u => u.Login == "vlad" && u.Pass == "123" && u.UserType == 0);
                Assert.AreNotEqual(null, finduser);
            }
        }

        [Test]
        public void RemoveTest()
        {
            using (var db = new ElJournalDbContext())
            {
                var finduser = db.Users.FirstOrDefault(u => u.Login == "vlad" && u.Pass == "123" && u.UserType == 0);
                new UserModel().Remove(finduser);
                var newfinduser = db.Users.FirstOrDefault(u => u.Login == "vlad" && u.Pass == "123" && u.UserType == 0);
                Assert.AreEqual(null, newfinduser);
            }
        }

        [Test]
        public void FindTest()
        {
            using (var db = new ElJournalDbContext())
            {
                var expecteduser = db.Users.FirstOrDefault(u => u.UserID == 1);
                var actualuser = new UserModel().GetItemByID(1);
                Assert.AreEqual(expecteduser, actualuser);
            }
        }
    }
}
