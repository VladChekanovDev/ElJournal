using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminStudentsDialogs
{
    class AddStudentDialogViewModel: BaseViewModel
    {
        #region Поля

        private string _lastName;
        private string _firstName;
        private string _patronymic;
        private Group _selectedGroup;
        private List<Group> _groupsList;
        private DelegateCommand _addStudent;

        #endregion

        #region Конструктор

        public AddStudentDialogViewModel()
        {
            var groupmodel = new GroupModel();
            _groupsList = groupmodel.GetList();
        }

        #endregion

        #region Свойства

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public List<Group> GroupsList
        {
            get => _groupsList;
            set
            {
                _groupsList = value;
                OnPropertyChanged(nameof(GroupsList));
            }
        }

        public bool IsAddActive => !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_firstName)
            && !string.IsNullOrWhiteSpace(_patronymic) && _selectedGroup != null;

        #endregion

        #region Команды

        public DelegateCommand AddStudent
        {
            get
            {
                return _addStudent ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
