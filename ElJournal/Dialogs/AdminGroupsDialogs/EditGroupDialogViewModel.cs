using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ElJournal.Dialogs.AdminGroupsDialogs
{
    class EditGroupDialogViewModel: BaseViewModel
    {
        #region Поля

        private string _newName;
        private string _selectedCourse;
        private DelegateCommand _editGroup;

        #endregion

        #region Конструктор

        public EditGroupDialogViewModel()
        {
        }

        #endregion

        #region Свойства

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

        public bool IsEditActivated => !string.IsNullOrWhiteSpace(_newName) && !string.IsNullOrWhiteSpace(_selectedCourse);
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
