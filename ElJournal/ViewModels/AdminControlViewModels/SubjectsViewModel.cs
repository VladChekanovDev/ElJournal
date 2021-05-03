using ElJournal.Dialogs;
using ElJournal.Dialogs.AdminSubjectsDialogs;
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
        private Subject _selectedSubject;
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
                _filter = value;
                OnPropertyChanged(nameof(FilteredList));
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

        public IEnumerable<Subject> FilteredList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_filter))
                {
                    return _subjectsList.Where(s => s.Name.ToLower().Contains(_filter.ToLower()) || s.Name.ToLower() == _filter.ToLower()
                    && s.ShortName.ToLower().Contains(_filter.ToLower()) || s.ShortName.ToLower() == _filter.ToLower());
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
                    var addsubjectdialog = new AddSubjectDialog();
                    if (addsubjectdialog.ShowDialog() == true)
                    {
                        var asdvm = (AddSubjectDialogViewModel)addsubjectdialog.DataContext;
                        var newsubject = new Subject(asdvm.ShortName, asdvm.Name);
                        var subjectmodel = new SubjectModel();
                        subjectmodel.Add(newsubject);
                        SubjectsList = subjectmodel.GetList();
                    }
                });
            }
        }

        public DelegateCommand DeleteSubject
        {
            get
            {
                return _deleteSubjects ??= new DelegateCommand((obj) =>
                {
                    if (_selectedSubject != null)
                    {
                        var subjectmodel = new SubjectModel();
                        subjectmodel.Remove(_selectedSubject);
                        SubjectsList = subjectmodel.GetList();
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.ItemIsNotSelectedError);
                        err.ShowDialog();
                    }
                });
            }
        }

        public DelegateCommand EditSubject
        {
            get
            {
                return _editSubject ??= new DelegateCommand((obj) =>
                {
                    if (_selectedSubject != null)
                    {
                        var editsubjectdialog = new EditSubjectDialog();
                        if (editsubjectdialog.ShowDialog() == true)
                        {
                            var esdvm = (EditSubjectDialogViewModel)editsubjectdialog.DataContext;
                            var newsubject = new Subject(esdvm.NewShortName, esdvm.NewName);
                            var subjectmodel = new SubjectModel();
                            subjectmodel.EditSubject(_selectedSubject.SubjectID, newsubject);
                            SubjectsList = subjectmodel.GetList();
                        }
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.ItemIsNotSelectedError);
                        err.ShowDialog();
                    }
                });
            }
        }

        #endregion
    }
}
