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

        private DelegateCommand _setMark;

        #endregion

        #region Свойства

        public List<Mark> MarksList
        {
            get => new MarkModel().GetMarksByLesson(CurrentInfo.CurrentSelectedLesson.LessonID);
        }

        #endregion

        #region Команды

        public DelegateCommand SetMark
        {
            get
            {
                return _setMark ??= new DelegateCommand((obj) =>
                {
                    var setmarkdialog = new SetMarkDialog();
                    if (setmarkdialog.ShowDialog() == true)
                    {
                        var smvm = (SetMarkViewModel)setmarkdialog.DataContext;
                        new MarkModel().SetValue(smvm.SelectedStudent.MarkID, smvm.SelectedValue);
                        OnPropertyChanged(nameof(MarksList));
                    }
                });
            }
        }

        #endregion
    }
}
