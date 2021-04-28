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

        private string _ID;
        private string _newFirstName;
        private string _newLastName;
        private string _newPatronymic;
        private DelegateCommand _editTeacher;

        #endregion

        #region Свойства

        public string ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(IsEditActive);
            }
        }

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

        public bool IsEditActive => !string.IsNullOrWhiteSpace(_ID) && !string.IsNullOrWhiteSpace(_newFirstName)
            && !string.IsNullOrWhiteSpace(_newLastName) && !string.IsNullOrWhiteSpace(_newPatronymic);

        #endregion

        #region Команды

        public DelegateCommand EditTeacher
        {
            get
            {
                return _editTeacher ??= new DelegateCommand((arg) =>
                {
                    if (Validation.StringToIntParse(_ID))
                    {
                        var teachermodel = new TeacherModel();
                        if (teachermodel.GetItemByID(int.Parse(_ID)) != null)
                        {
                            var window = (Window)arg;
                            window.DialogResult = true;
                        }
                        else
                        {
                            var err = new ErrorDialog(Validation.UserNotFoundError);
                            err.ShowDialog();
                        }
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.ImpossibleToParseError);
                        err.ShowDialog();
                    }
                });
            }
        }

        #endregion
    }
}
