using ElJournal.Entities;
using ElJournal.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    public class GroupModel: IModel<Group>
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

        public List<Group> GetList()
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Groups.ToList();
            }
        }

        public void EditGroup(int id, Group group)
        {
            using (var db = new ElJournalDbContext())
            {
                var selectedGroup = db.Groups.FirstOrDefault(g => g.GroupID == id);
                selectedGroup.Name = group.Name;
                selectedGroup.Course = group.Course;
                db.SaveChanges();
            }
        }

        public List<string> GetNamesList()
        {
            var groupsList = GetList();
            List<string> names = new List<string>();
            foreach (var item in groupsList)
            {
                names.Add(item.Name);
            }
            return names;
        }

        public List<Group> GetConnectionedList()
        {
            using (var db = new ElJournalDbContext())
            {
                return db.Groups.Include(g => g.GroupToSubjects).ThenInclude(gts => gts.Subject).ToList();
            }
        }
    }
}
