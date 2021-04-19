using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElJournal.Entities;
using ElJournal.Other;

namespace ElJournal.Models
{
    class AdminModel: IModel<Admin>
    {
        public void Add(Admin admin)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Admins.Add(admin);
                db.SaveChanges();
            }
        }

        public void Remove(Admin admin)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Admins.Remove(admin);
                db.SaveChanges();
            }
        }

        public Admin GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Admins.FirstOrDefault(a => a.AdminID == id);
            }
        }
    }
}
