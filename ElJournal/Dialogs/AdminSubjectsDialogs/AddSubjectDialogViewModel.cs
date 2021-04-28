using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminSubjectsDialogs
{
    class AddSubjectDialogViewModel: BaseViewModel
    {
        #region Поля

        private string _shortName;
        private string _name;
        private DelegateCommand _addSubject;

        #endregion

        #region Свойства

        public string ShortName
        {
            get => _shortName;
            set
            {
                _shortName = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public bool IsAddActive => !string.IsNullOrWhiteSpace(_shortName) && !string.IsNullOrWhiteSpace(_name);

        #endregion

        #region Команды

        public DelegateCommand AddSubject
        {
            get
            {
                return _addSubject = new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
