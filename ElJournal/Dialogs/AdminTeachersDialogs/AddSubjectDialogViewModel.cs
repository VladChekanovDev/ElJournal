using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminTeachersDialogs
{
    class AddSubjectDialogViewModel: BaseViewModel
    {
        #region Поля

        private List<Subject> _subjectsList;
        private Subject _selectedSubject;
        private DelegateCommand _addSubject;

        #endregion

        #region Конструктор

        public AddSubjectDialogViewModel()
        {
            var subjectmodel = new SubjectModel();
            _subjectsList = subjectmodel.GetList();
        }

        #endregion

        #region Свойства

        public List<Subject> SubjectsList
        {
            get => _subjectsList;
            set
            {
                _subjectsList = value;
                OnPropertyChanged(nameof(SubjectsList));
            }
        }

        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public bool IsAddActive => _selectedSubject != null;

        #endregion

        #region Команды

        public DelegateCommand AddSubject
        {
            get
            {
                return _addSubject ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }

        #endregion
    }
}
