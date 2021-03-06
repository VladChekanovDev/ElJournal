using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    public class GroupToSubject
    {
        public int GroupToSubjectID { get; set; }
        public int GroupID { get; set; }
        public int SubjectID { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public List<Semester> Semesters { get; set; }

        public GroupToSubject()
        {

        }

        public GroupToSubject(int groupid, int subjectid)
        {
            this.GroupID = groupid;
            this.SubjectID = subjectid;
        }
    }
}
