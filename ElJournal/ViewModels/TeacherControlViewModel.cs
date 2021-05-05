using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using ElJournal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.ViewModels
{
    class TeacherControlViewModel: BaseViewModel
    {
        #region Поля

        private List<TeacherToSubject> _subjectsList;
        private TeacherToSubject _selectedSubject;
        private Teacher _currentTeacher;
        private DelegateCommand _logout;

        #endregion

        #region Конструктор

        public TeacherControlViewModel()
        {
            var teachermodel = new TeacherModel();
            _currentTeacher = teachermodel.GetTeacherByUserID(CurrentUser.UserID);
            var teachertosubjectmodel = new TeacherToSubjectModel();
            _subjectsList = teachertosubjectmodel.GetTTSsByTeacher(_currentTeacher.TeacherID);
        }

        #endregion

        #region Свойства

        public List<TeacherToSubject> SubjectsList
        {
            get => _subjectsList;
            set
            {
                _subjectsList = value;
                OnPropertyChanged();
            }
        }

        public TeacherToSubject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(IsGroupsListActive));
                OnPropertyChanged(nameof(GroupsList));
            }
        }

        public List<GroupToSubject> GroupsList
        {
            get
            {
                if (IsGroupsListActive)
                {
                    return new GroupToSubjectModel().GetGroupsBySubject(_selectedSubject.SubjectID);
                }
                else return null;
            }
        }

        public bool IsGroupsListActive => _selectedSubject != null;

        #endregion

        #region Команды

        public DelegateCommand Logout
        {
            get
            {
                return _logout ??= new DelegateCommand((arg) =>
                {
                    var logform = new LoginFormView();
                    CurrentUser.UserID = 0;
                    CurrentUser.UserType = null;
                    logform.Show();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = logform;
                });
            }
        }

        #endregion
    }
}
