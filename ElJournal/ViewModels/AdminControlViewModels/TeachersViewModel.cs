using ElJournal.Dialogs;
using ElJournal.Dialogs.AdminTeachersDialogs;
using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElJournal.ViewModels.AdminControlViewModels
{
    class TeachersViewModel: BaseViewModel 
    {
        #region Поля

        private List<Teacher> _teachersList;
        private string _filter;
        private Teacher _selectedTeacher;
        private DelegateCommand _addTeacher;
        private DelegateCommand _deleteTeachers;
        private DelegateCommand _editTeacher;
        private DelegateCommand _addSubject;

        #endregion

        #region Конструктор

        public TeachersViewModel()
        {
            var teachermodel = new TeacherModel();
            _teachersList = teachermodel.GetConnectionedList();
        }

        #endregion

        #region Свойства

        public List<Teacher> TeachersList
        {
            get => _teachersList;
            set
            {
                _teachersList = value;
                OnPropertyChanged(nameof(FilteredList));
            }
        }

        public Teacher SelectedTeacher
        {
            get => _selectedTeacher;
            set
            {
                _selectedTeacher = value;
                OnPropertyChanged();
            }
        }

        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Teacher> FilteredList
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_filter))
                {
                    return TeachersList.Where(t => t.FirstName.ToLower().Contains(_filter.ToLower()) || t.FirstName.ToLower() == _filter.ToLower()
                    || t.LastName.ToLower().Contains(_filter.ToLower()) || t.LastName.ToLower() == _filter.ToLower()
                    || t.Patronymic.ToLower().Contains(_filter.ToLower()) || t.Patronymic.ToLower() == _filter.ToLower());
                }
                else return TeachersList;
            }
        }

        #endregion

        #region Команды

        public DelegateCommand AddTeacher
        {
            get
            {
                return _addTeacher ??= new DelegateCommand((obj) =>
                {
                    var addteacherdialog = new AddTeacherDialog();
                    if (addteacherdialog.ShowDialog() == true)
                    {
                        var atdvm = (AddTeacherDialogViewModel)addteacherdialog.DataContext;
                        var newuser = new User(atdvm.Login, atdvm.Password, 1);
                        var newteacher = new Teacher(atdvm.FirstName, atdvm.LastName, atdvm.Patrnoymic);
                        var usermodel = new UserModel();
                        usermodel.AddTeacher(newteacher, newuser);
                        var teachermodel = new TeacherModel();
                        TeachersList = teachermodel.GetList();
                    }
                });
            }
        }

        public DelegateCommand DeleteTeacher
        {
            get
            {
                return _deleteTeachers ??= new DelegateCommand((obj) =>
                {
                    if (_selectedTeacher != null)
                    {
                        var teachermodel = new TeacherModel();
                        var usermodel = new UserModel();
                        usermodel.Remove(usermodel.GetItemByID(_selectedTeacher.UserID));
                        TeachersList = teachermodel.GetList();
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.ItemIsNotSelectedError);
                        err.ShowDialog();
                    }
                });
            }
        }

        public DelegateCommand EditTeacher
        {
            get
            {
                return _editTeacher ??= new DelegateCommand((obj) =>
                {
                    if (_selectedTeacher != null)
                    {
                        var editteacherdialog = new EditTeacherDialog();
                        if (editteacherdialog.ShowDialog() == true)
                        {
                            var etdvm = (EditTeacherDialogViewModel)editteacherdialog.DataContext;
                            var newteacher = new Teacher(etdvm.NewFirstName, etdvm.NewLastName, etdvm.NewPatrnomyic);
                            var teachermodel = new TeacherModel();
                            teachermodel.EditTeacher(_selectedTeacher.TeacherID, newteacher);
                            TeachersList = teachermodel.GetList();
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

        public DelegateCommand AddSubject
        {
            get
            {
                return _addSubject ??= new DelegateCommand((obj) =>
                {
                    if (_selectedTeacher != null)
                    {
                        var addsubjectdialog = new AddSubjectDialog();
                        if (addsubjectdialog.ShowDialog() == true)
                        {
                            var asdvm = (AddSubjectDialogViewModel)addsubjectdialog.DataContext;
                            var teachertosubjectmodel = new TeacherToSubjectModel();
                            if (!teachertosubjectmodel.ConnectionExists(_selectedTeacher.TeacherID, asdvm.SelectedSubject.SubjectID))
                            {
                                var newtts = new TeacherToSubject(asdvm.SelectedSubject.SubjectID, _selectedTeacher.TeacherID);
                                teachertosubjectmodel.Add(newtts);
                                TeachersList = new TeacherModel().GetConnectionedList();
                            }
                            else
                            {
                                var err = new ErrorDialog(Validation.ConnectionExist);
                                err.ShowDialog();
                            }
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
