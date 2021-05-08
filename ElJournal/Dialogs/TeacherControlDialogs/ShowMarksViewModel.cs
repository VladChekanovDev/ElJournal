using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Dialogs.TeacherControlDialogs
{
    class ShowMarksViewModel: BaseViewModel
    {
        #region Поля



        #endregion

        #region Свойства

        public List<Mark> MarksList
        {
            get => new MarkModel().GetMarksByLesson(SelectedLesson.CurrentSelectedLesson.LessonID);
        }

        #endregion
    }
}
