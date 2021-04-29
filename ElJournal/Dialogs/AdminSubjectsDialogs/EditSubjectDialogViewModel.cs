using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminSubjectsDialogs
{
    class EditSubjectDialogViewModel: BaseViewModel
    {
        #region Поля

        private string _ID;
        private string _newShortName;
        private string _newName;
        private DelegateCommand _editSubject;

        #endregion

        #region Свойства

        public string ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(IsEditActive));
            }
        }

        public string NewShortName
        {
            get => _newShortName;
            set
            {
                _newShortName = value;
                OnPropertyChanged(nameof(IsEditActive));
            }
        }

        public string NewName
        {
            get => _newName;
            set
            {
                _newName = value;
                OnPropertyChanged(nameof(IsEditActive));
            }
        }

        public bool IsEditActive => !string.IsNullOrWhiteSpace(_ID)
            && !string.IsNullOrWhiteSpace(_newShortName)
            && !string.IsNullOrWhiteSpace(_newName);

        #endregion

        #region Команды

        public DelegateCommand EditSubject
        {
            get
            {
                return _editSubject ??= new DelegateCommand((arg) =>
                {
                    if (Validation.StringToIntParse(_ID))
                    {
                        var subjectmodel = new SubjectModel();
                        if (subjectmodel.GetItemByID(int.Parse(_ID)) != null)
                        {
                            var window = (Window)arg;
                            window.DialogResult = true;
                        }
                        else
                        {
                            var err = new ErrorDialog(Validation.SubjectNotFound);
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
