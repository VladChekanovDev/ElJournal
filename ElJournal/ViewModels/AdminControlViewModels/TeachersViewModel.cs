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
        private DelegateCommand _addTeacher;
        private DelegateCommand _deleteTeachers;
        private DelegateCommand _editTeacher;

        #endregion

        #region Конструктор

        public TeachersViewModel()
        {
            var teachermodel = new TeacherModel();
            _teachersList = teachermodel.GetList();
        }

        #endregion

        #region Свойства

        public List<Teacher> TeachersList
        {
            get => _teachersList;
            set
            {
                _teachersList = value;
                OnPropertyChanged(nameof(TeachersList));
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

                    }
                });
            }
        }

        public DelegateCommand DeleteTeachers
        {
            get
            {
                return _deleteTeachers ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        public DelegateCommand EditTeacher
        {
            get
            {
                return _editTeacher ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        #endregion
    }
}
