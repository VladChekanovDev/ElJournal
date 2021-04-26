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
        private string _course;
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

        public string Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged(nameof(IsAddButtonActive));
            }
        }

        public bool IsAddButtonActive => !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_course);

        #endregion

        #region Команды

        public DelegateCommand AddGroup
        {
            get
            {
                return _addGroup ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    if (!Validation.StringToIntParse(_course))
                    {
                        var ed = new ErrorDialog(Validation.ImpossibleToParseError);
                        ed.ShowDialog();
                    }
                    else
                        window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
