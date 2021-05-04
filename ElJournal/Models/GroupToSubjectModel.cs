﻿using ElJournal.Entities;
using ElJournal.Other;
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
    }
}
