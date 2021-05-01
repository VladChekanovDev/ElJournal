using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminTeachersDialogs
{
    class EditTeacherDialogViewModel : BaseViewModel
    {
        #region Поля

        private string _newFirstName;
        private string _newLastName;
        private string _newPatronymic;
        private DelegateCommand _editTeacher;

        #endregion

        #region Свойства

        public string NewFirstName
        {
            get => _newFirstName;
            set
            {
                _newFirstName = value;
                OnPropertyChanged(nameof(IsEditActive));
            }
        }

        public string NewLastName
        {
            get => _newLastName;
            set
            {
                _newLastName = value;
                OnPropertyChanged(nameof(IsEditActive));
            }
        }

        public string NewPatrnomyic
        {
            get => _newPatronymic;
            set
            {
                _newPatronymic = value;
                OnPropertyChanged(nameof(IsEditActive));
            }
        }

        public bool IsEditActive => !string.IsNullOrWhiteSpace(_newFirstName)
            && !string.IsNullOrWhiteSpace(_newLastName) && !string.IsNullOrWhiteSpace(_newPatronymic);

        #endregion

        #region Команды

        public DelegateCommand EditTeacher
        {
            get
            {
                return _editTeacher ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
