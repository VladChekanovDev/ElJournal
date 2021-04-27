using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminStudentsDialogs
{
    class EditStudentDialogViewModel: BaseViewModel
    {
        #region Поля

        private string _ID;
        private string _newLastName;
        private string _newFirstName;
        private string _newPatronymic;
        private Group _newGroup;
        private List<Group> _groupsList;
        private DelegateCommand _editStudent;

        #endregion

        #region Конструктор

        public EditStudentDialogViewModel()
        {
            var groupmodel = new GroupModel();
            _groupsList = groupmodel.GetList();
        }

        #endregion

        #region Свойства

        public List<Group> GroupsList
        {
            get => _groupsList;
            set
            {
                _groupsList = value;
                OnPropertyChanged(nameof(GroupsList));
            }
        }

        public string ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public string NewFirstName
        {
            get => _newFirstName;
            set
            {
                _newFirstName = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public string NewLastName
        {
            get => _newLastName;
            set
            {
                _newLastName = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public string NewPatronymic
        {
            get => _newPatronymic;
            set
            {
                _newPatronymic = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public Group NewGroup
        {
            get => _newGroup;
            set
            {
                _newGroup = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public bool IsEditActivated => !string.IsNullOrEmpty(_ID) && !string.IsNullOrEmpty(_newFirstName)
            && !string.IsNullOrEmpty(_newLastName) && !string.IsNullOrEmpty(_newPatronymic)
            && _newGroup != null;

        #endregion

        #region Команды

        public DelegateCommand EditStudent
        {
            get
            {
                return _editStudent ??= new DelegateCommand((arg) =>
                {
                    if (Validation.StringToIntParse(_ID))
                    {
                        var window = (Window)arg;
                        window.DialogResult = true;
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
