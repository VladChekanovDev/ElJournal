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
    class LoginFormViewModel: BaseViewModel
    {
        #region Поля

        private string _login;
        private string _password;
        private DelegateCommand _loginUser;
        private DelegateCommand _closeApp;
        private DelegateCommand _minimizeWindow;

        #endregion

        #region Свойства

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }

        public bool IsLoginEnabled => !string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password);

        #endregion

        #region Команды

        public DelegateCommand LoginUser
        {
            get
            {
                return _loginUser ??= new DelegateCommand((obj) =>
                {
                    var um = new UserModel();
                    if (um.LoginUser(_login, _password))
                    {
                        var mv = new MainView();
                        mv.Show();
                        Application.Current.MainWindow.Close();
                    }
                });
            }
        }

        public DelegateCommand CloseApp
        {
            get
            {
                return _closeApp ??= new DelegateCommand((obj) =>
                {
                    Application.Current.Shutdown();
                });
            }
        }

        public DelegateCommand MinimizeWindow
        {
            get
            {
                return _minimizeWindow ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.WindowState = WindowState.Minimized;
                });
            }
        }

        #endregion
    }
}
