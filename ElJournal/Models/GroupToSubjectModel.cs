using ElJournal.Entities;
using ElJournal.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.Models
{
    class GroupToSubjectModel: IModel<GroupToSubject>
    {
        public void Add(GroupToSubject grouptosubject)
        {
            using (var db = new ElJournalDbContext())
            {
                db.GroupToSubjects.Add(grouptosubject);
                db.SaveChanges();
            }
        }

        public void Remove(GroupToSubject grouptosubject)
        {
            using (var db = new ElJournalDbContext())
            {
                db.GroupToSubjects.Remove(grouptosubject);
                db.SaveChanges();
            }
        }

        public GroupToSubject GetItemByID(int id)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.GroupToSubjects.FirstOrDefault(gts => gts.GroupToSubjectID == id);
            }
        }

        public bool ConnectionExists(int groupid, int subjectid)
        {
            using (var db = new ElJournalDbContext())
            {
                if (db.GroupToSubjects.FirstOrDefault(gts => gts.SubjectID == subjectid && gts.GroupID == groupid) != null)
                    return true;
                else return false;
            }
        }

        public List<GroupToSubject> GetGroupsBySubject(int subjectid)
        {
            using (var db = new ElJournalDbContext())
            {
                return db.GroupToSubjects.Where(gts => gts.SubjectID == subjectid)
                    .Include(gts => gts.Group)
                    .ToList();
            }
        }
    }
}
