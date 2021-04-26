using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs
{
    class AddGroupDialogViewModel: BaseViewModel
    {
        #region Поля

        private string _name;
        private DelegateCommand _addGroup;

        #endregion

        #region Свойства

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(IsAddButtonActive));
            }
        }

        public bool IsAddButtonActive => !string.IsNullOrWhiteSpace(_name);

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
