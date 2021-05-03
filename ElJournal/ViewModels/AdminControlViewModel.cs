using ElJournal.Entities;
using ElJournal.Other;
using ElJournal.ViewModels.AdminControlViewModels;
using ElJournal.Views;
using ElJournal.Views.AdminControlViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ElJournal.ViewModels
{
    class AdminControlViewModel: BaseViewModel
    {
        #region Поля
        private UserControl _selectedUserControl;
        private DelegateCommand _changeSelection;
        private DelegateCommand _logout;

        #endregion

        #region Свойства

        public UserControl SelectedUserControl
        {
            get => _selectedUserControl;
            set
            {
                _selectedUserControl = value;
                OnPropertyChanged(nameof(SelectedUserControl));
            }
        }

        #endregion

        #region Команды

        public DelegateCommand ChangeSelection
        {
            get
            {
                return _changeSelection ??= new DelegateCommand((arg) =>
                {
                    var vmname = (Button)arg;
                    switch (vmname.Name)
                    {
                        case "Teachers":
                            SelectedUserControl = new TeachersView();
                            break;
                        case "Students":
                            SelectedUserControl = new StudentsView();
                            break;
                        case "Subjects":
                            SelectedUserControl = new SubjectsView();
                            break;
                        case "Groups":
                            SelectedUserControl = new GroupsView();
                            break;
                    }
                });
            }
        }

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
