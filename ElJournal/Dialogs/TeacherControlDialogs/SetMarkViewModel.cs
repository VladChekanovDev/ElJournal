using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.TeacherControlDialogs
{
    class SetMarkViewModel: BaseViewModel
    {
        #region Поля

        private Mark _selectedStudent;
        private string _selectedValue;
        private DelegateCommand _setMark;

        #endregion

        #region Свойства

        public List<Mark> StudentsList => new MarkModel().GetMarksByLesson(SelectedLesson.CurrentSelectedLesson.LessonID);

        public Mark SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(IsStudentSelected));
            }
        }

        public string SelectedValue
        {
            get => _selectedValue;
            set
            {
                _selectedValue = value;
                OnPropertyChanged(nameof(IsValueSelected));
            }
        }

        #region Активаторы

        public bool IsStudentSelected => _selectedStudent != null;

        public bool IsValueSelected => _selectedValue != null;

        #endregion

        #endregion

        #region Команды

        public DelegateCommand SetMark
        {
            get
            {
                return _setMark ??= new DelegateCommand((arg) =>
                {
                    ((Window)arg).DialogResult = true;
                });
            }
        }

        #endregion
    }
}
