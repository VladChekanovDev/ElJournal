using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ElJournal.Dialogs.AdminTeachersDialogs
{
    class ShowSubjectsDialogViewModel: BaseViewModel
    {
        #region Поля

        private ObservableCollection<Teacher> _teachersList;
        private Teacher _selectedTeacher;

        #endregion

        #region Конструктор

        public ShowSubjectsDialogViewModel()
        {
            var teachermodel = new TeacherModel();
            _teachersList = teachermodel.GetConnectionedList();
        }

        #endregion

        #region Свойства

        public ObservableCollection<Teacher> TeachersList
        {
            get => _teachersList;
            set
            {
                _teachersList = value;
                OnPropertyChanged();
            }
        }

        public Teacher SelectedTeacher
        {
            get => _selectedTeacher;
            set
            {
                _selectedTeacher = value;
                OnPropertyChanged(nameof(SubjectsList));
            }
        }

        public List<TeacherToSubject> SubjectsList
        {
            get
            {
                if (_selectedTeacher != null)
                {
                    return _selectedTeacher.TeacherToSubjects;
                }
                else
                    return null;
            }
        }

        #endregion
    }
}
