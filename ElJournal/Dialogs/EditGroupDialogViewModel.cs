using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ElJournal.Dialogs
{
    class EditGroupDialogViewModel: BaseViewModel
    {
        #region Поля

        private List<Group> _namesList;
        private Group _selectedGroup;
        private string _newName;
        private string _selectedCourse;
        private DelegateCommand _editGroup;

        #endregion

        #region Конструктор

        public EditGroupDialogViewModel()
        {
            var gm = new GroupModel();
            _namesList = gm.GetList();
        }

        #endregion

        #region Свойства

        public List<Group> NamesList
        {
            get => _namesList;
            set
            {
                _namesList = value;
                OnPropertyChanged(nameof(NamesList));
            }
        }

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public string NewName
        {
            get => _newName;
            set
            {
                _newName = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public string SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                _selectedCourse = value;
                OnPropertyChanged(nameof(IsEditActivated));
            }
        }

        public bool IsEditActivated => SelectedGroup != null && !string.IsNullOrWhiteSpace(_newName) && !string.IsNullOrWhiteSpace(_selectedCourse);
        #endregion

        #region Команды

        public DelegateCommand EditGroup
        {
            get
            {
                return _editGroup ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
