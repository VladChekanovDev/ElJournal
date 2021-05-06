using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.TeacherControlDialogs
{
    class AddSemesterViewModel: BaseViewModel
    {
        #region Поля

        private string _semester;
        private DelegateCommand _addSemester;

        #endregion

        #region Свойства

        public string Semester
        {
            get => _semester;
            set
            {
                _semester = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public bool IsAddActive => !string.IsNullOrWhiteSpace(_semester);

        #endregion

        #region Команды

        public DelegateCommand AddSemester
        {
            get
            {
                return _addSemester ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
