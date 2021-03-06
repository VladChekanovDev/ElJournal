using ElJournal.Dialogs;
using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    public class UserModel: IModel<User>
    {
        public void Add(User user)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Remove(User user)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public User GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Users.FirstOrDefault(u => u.UserID == id);
            }
        }

        public bool LoginUser(string login, string pass)
        {
            using (var db = new ElJournalDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Login == login && u.Pass == pass);
                if (user == null)
                {
                    //var errDialog = new ErrorDialog(Validation.UserNotFoundError);
                    //errDialog.ShowDialog();
                    return false;
                }
                else
                {
                    CurrentUser.UserID = user.UserID;
                    CurrentUser.UserType = user.UserType;
                    return true;
                }
            }
        }

        public bool IsUserExist(string login)
        {
            using (var db = new ElJournalDbContext())
            {
                if (db.Users.FirstOrDefault(u => u.Login == login) != null)
                    return true;
                else
                    return false;
            }
        }

        public void AddTeacher(Teacher teacher, User user)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                var newuser = db.Users.FirstOrDefault(u => u.Login == user.Login);
                teacher.UserID = newuser.UserID;
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
        }

        public void AddAdmin(Admin admin, User user)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                var newuser = db.Users.FirstOrDefault(u => u.Login == user.Login);
                admin.UserID = newuser.UserID;
                db.Admins.Add(admin);
                db.SaveChanges();
            }
        }
    }
}
