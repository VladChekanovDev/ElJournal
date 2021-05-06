﻿using ElJournal.Dialogs;
using ElJournal.Dialogs.TeacherControlDialogs;
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
        private GroupToSubject _selectedGroup;
        private Teacher _currentTeacher;
        private DelegateCommand _logout;
        private DelegateCommand _addSemester;

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

        public GroupToSubject SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(IsSemestersActive));
                OnPropertyChanged(nameof(SemestersList));
            }
        }

        public List<Semester> SemestersList
        {
            get
            {
                if (IsSemestersActive)
                {
                    return new SemesterModel().GetSemesters(_selectedGroup.GroupID, _selectedSubject.SubjectID);
                }
                else return null;
            }
        }

        public bool IsGroupsListActive => _selectedSubject != null;
        public bool IsSemestersActive => _selectedGroup != null;

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

        public DelegateCommand AddSemester
        {
            get
            {
                return _addSemester ??= new DelegateCommand((obj) =>
                {
                    var addsemesterdialog = new AddSemesterDialog();
                    if (addsemesterdialog.ShowDialog() == true)
                    {
                        var asvm = (AddSemesterViewModel)addsemesterdialog.DataContext;
                        var semestermodel = new SemesterModel();
                        if (!semestermodel.IsSemesterExists(_selectedGroup.GroupToSubjectID, int.Parse(asvm.Semester)))
                        {
                            var newsemester = new Semester(_selectedGroup.GroupToSubjectID, int.Parse(asvm.Semester));
                            semestermodel.Add(newsemester);
                            OnPropertyChanged(nameof(SemestersList));
                        }
                        else
                        {
                            var err = new ErrorDialog(Validation.SemesterExistError);
                            err.ShowDialog();
                        }
                    }
                });
            }
        }

        #endregion
    }
}
