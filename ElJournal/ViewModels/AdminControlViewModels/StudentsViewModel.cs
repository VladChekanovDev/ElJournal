using ElJournal.Dialogs.AdminStudentsDialogs;
using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.ViewModels.AdminControlViewModels
{
    class StudentsViewModel: BaseViewModel
    {
        #region Поля

        private List<Student> _studentsList;
        private string _filter;
        private List<Student> _filteredStudents;
        private DelegateCommand _addStudent;
        private DelegateCommand _deleteStudents;
        private DelegateCommand _editStudent;

        #endregion

        #region Конструктор

        public StudentsViewModel()
        {
            var studentmodel = new StudentModel();
            _studentsList = studentmodel.GetList();
        }

        #endregion

        #region Свойства

        public List<Student> StudentsList
        {
            get => _studentsList;
            set
            {
                _studentsList = value;
                OnPropertyChanged(nameof(StudentsList));
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

        public IEnumerable<Student> FilteredList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_filter))
                {
                    var filteredlist = StudentsList.Where(s => s.FirstName.ToLower().Contains(_filter.ToLower()) || s.FirstName.ToLower() == _filter.ToLower()
                    || s.LastName.ToLower().Contains(_filter.ToLower()) || s.LastName.ToLower() == _filter.ToLower()
                    || s.Patronymic.ToLower().Contains(_filter.ToLower()) || s.Patronymic.ToLower() == _filter.ToLower());
                    return filteredlist;
                }
                else
                    return StudentsList;
            }
        }

        #endregion

        #region Команды

        public DelegateCommand AddStudent
        {
            get
            {
                return _addStudent ??= new DelegateCommand((obj) =>
                {
                    var addstudentdialog = new AddStudentDialog();
                    if (addstudentdialog.ShowDialog() == true)
                    {

                    }
                });
            }
        }

        public DelegateCommand DeleteStudents
        {
            get
            {
                return _deleteStudents ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        public DelegateCommand EditStudent
        {
            get
            {
                return _editStudent ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        #endregion
    }
}
