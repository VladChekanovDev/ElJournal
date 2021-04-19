using ElJournal.Dialogs;
using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class UserModel: IModel<User>
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

        public void LoginUser(string login, string pass)
        {
            using (var db = new ElJournalDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Login == login && u.Pass == pass);
                if (user == null)
                {
                    var errDialog = new ErrorDialog("Пользователь не найден. Неверные данные или пароль");
                    errDialog.ShowDialog();
                }
                else
                {
                    CurrentUser.UserID = user.UserID;
                    CurrentUser.UserType = user.UserType;
                }
            }
        }
    }
}
