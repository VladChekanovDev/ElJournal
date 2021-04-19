using ElJournal.Entities;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class GroupModel: IModel<Group>
    {
        public void Add(Group group)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Groups.Add(group);
                db.SaveChanges();
            }
        }

        public void Remove(Group group)
        {
            using (var db = new ElJournalDbContext())
            {
                db.Groups.Remove(group);
                db.SaveChanges();
            }
        }

        public Group GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Groups.FirstOrDefault(g => g.GroupID == id);
            }
        }
    }
}
