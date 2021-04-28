using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.ViewModels.AdminControlViewModels
{
    class SubjectsViewModel: BaseViewModel
    {
        #region Поля

        private List<Subject> _subjectsList;
        private string _filter;
        private DelegateCommand _addSubject;
        private DelegateCommand _deleteSubjects;
        private DelegateCommand _editSubject;

        #endregion

        #region Конструктор

        public SubjectsViewModel()
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
                OnPropertyChanged(nameof(FilteredList));
            }
        }

        public string Filter
        {
            get => _filter;
            set
            {
                OnPropertyChanged(nameof(FilteredList));
            }
        }

        public IEnumerable<Subject> FilteredList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_filter))
                {
                    return _subjectsList.Where(s => s.Name.ToLower().Contains(_filter.ToLower()) || s.Name.ToLower() == _filter.ToLower());
                }
                else
                    return _subjectsList;
            }
        }

        #endregion

        #region Команды

        public DelegateCommand AddSubject
        {
            get
            {
                return _addSubject ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        public DelegateCommand DeleteSubjects
        {
            get
            {
                return _deleteSubjects ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        public DelegateCommand EditSubject
        {
            get
            {
                return _editSubject ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        #endregion
    }
}
