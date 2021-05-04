using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.Dialogs.AdminSubjectsDialogs
{
    class ShowGroupsDialogViewModel: BaseViewModel
    {
        #region Поля

        private List<Subject> _subjectsList;
        private Subject _selectedSubject;

        #endregion

        #region Конструктор

        public ShowGroupsDialogViewModel()
        {
            var subjectmodel = new SubjectModel();
            _subjectsList = subjectmodel.GetConnectionedList();
        }

        #endregion

        #region Свойства

        public List<Subject> SubjectsList
        {
            get => _subjectsList;
            set
            {
                _subjectsList = value;
                OnPropertyChanged();
            }
        }

        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }

        public List<GroupToSubject> GroupsList
        {
            get
            {
                if (_selectedSubject != null)
                {
                    return _selectedSubject.GroupToSubjects;
                }
                else return null;
            }
        }

        #endregion
    }
}
