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
        private List<string> _regularvalues = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Нб" };
        private List<string> _laboratoryvalues = new List<string>() { "Не зачтено", "Зачтено", "Нб" };

        #endregion

        #region Свойства

        public List<Mark> StudentsList => new MarkModel().GetMarksByLesson(CurrentInfo.CurrentSelectedLesson.LessonID);

        public Mark SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(IsStudentSelected));
            }
        }

        public List<string> ValuesList
        {
            get
            {
                switch (CurrentInfo.CurrentSelectedLesson.LessonType)
                {
                    case "Лабораторная": 
                        return _laboratoryvalues;
                    case "Практическая":
                        return _regularvalues;
                    case "Контрольная":
                        return _regularvalues;
                    case "Лекция":
                        return _regularvalues;
                    default: return null;
                }
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
