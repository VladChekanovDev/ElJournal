using ElJournal.Dialogs;
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
        private Student _selectedStudent;
        private DelegateCommand _addStudent;
        private DelegateCommand _deleteStudents;
        private DelegateCommand _editStudent;

        #endregion

        #region Конструктор

        public StudentsViewModel()
        {
            var studentmodel = new StudentModel();
            _studentsList = studentmodel.GetConnectionedList();
        }

        #endregion

        #region Свойства

        public List<Student> StudentsList
        {
            get => _studentsList;
            set
            {
                _studentsList = value;
                OnPropertyChanged(nameof(FilteredList));
            }
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(IsStudentSelected);
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
                    || s.Patronymic.ToLower().Contains(_filter.ToLower()) || s.Patronymic.ToLower() == _filter.ToLower()
                    || s.Group.Name.ToLower().Contains(_filter.ToLower()) || s.Group.Name.ToLower() == _filter.ToLower());
                    return filteredlist;
                }
                else
                    return StudentsList;
            }
        }

        public bool IsStudentSelected => _selectedStudent != null;

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
                        var asdvm = (AddStudentDialogViewModel)addstudentdialog.DataContext;
                        var newstudent = new Student(asdvm.FirstName, asdvm.LastName, asdvm.Patronymic, asdvm.SelectedGroup.GroupID);
                        var studentmodel = new StudentModel();
                        studentmodel.Add(newstudent);
                        StudentsList = studentmodel.GetConnectionedList();
                    }
                });
            }
        }

        public DelegateCommand DeleteStudent
        {
            get
            {
                return _deleteStudents ??= new DelegateCommand((obj) =>
                {
                    if (_selectedStudent != null)
                    {
                        var confirmdialog = new ConfirmDeleteDialog();
                        if (confirmdialog.ShowDialog() == true)
                        {
                            var studentmodel = new StudentModel();
                            studentmodel.Remove(_selectedStudent);
                            StudentsList = studentmodel.GetConnectionedList();
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

        public DelegateCommand EditStudent
        {
            get
            {
                return _editStudent ??= new DelegateCommand((obj) =>
                {
                    if (_selectedStudent != null)
                    {
                        var editstudentdialog = new EditStudentDialog();
                        if (editstudentdialog.ShowDialog() == true)
                        {
                            var esdvm = (EditStudentDialogViewModel)editstudentdialog.DataContext;
                            var newstudent = new Student(esdvm.NewFirstName, esdvm.NewLastName, esdvm.NewPatronymic, esdvm.NewGroup.GroupID);
                            var studentmodel = new StudentModel();
                            studentmodel.EditStudent(_selectedStudent.StudentID, newstudent);
                            StudentsList = studentmodel.GetConnectionedList();
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
