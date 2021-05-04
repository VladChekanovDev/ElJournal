using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminSubjectsDialogs
{
    class AddGroupDialogViewModel: BaseViewModel
    {
        #region Поля

        private List<Group> _groupsList;
        private Group _selectedGroup;
        private DelegateCommand _addGroup;

        #endregion

        #region Конструктор

        public AddGroupDialogViewModel()
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

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public bool IsAddActive => _selectedGroup != null;

        #endregion

        #region Команды

        public DelegateCommand AddGroup
        {
            get
            {
                return _addGroup ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
