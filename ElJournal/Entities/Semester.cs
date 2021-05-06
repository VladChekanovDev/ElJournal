﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Entities
{
    class Semester
    {
        public int SemesterID { get; set; }
        public int GroupToSubjectID { get; set; }
        public int Value { get; set; }
        public List<Lesson> Lessons { get; set; }
        public GroupToSubject GroupToSubject { get; set; }

        public Semester()
        {

        }
    }
}
