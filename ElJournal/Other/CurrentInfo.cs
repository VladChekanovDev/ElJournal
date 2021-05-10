using ElJournal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Other
{
    static class CurrentInfo
    {
        public static Lesson CurrentSelectedLesson { get; set; }
        public static Group CurrentSelectedGroup { get; set; }

        public static Semester CurrentSelectedSemester { get; set; }
    }
}
