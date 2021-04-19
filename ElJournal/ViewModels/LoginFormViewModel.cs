using ElJournal.Models;
using ElJournal.Other;
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
                OnPropertyChanged(nameof(Login));
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
                OnPropertyChanged(nameof(Password));
            }
        }

        #endregion

        #region Команды

        public DelegateCommand LoginUser
        {
            get
            {
                return _loginUser ??
                    (_loginUser = new DelegateCommand((obj) =>
                {
                    var um = new UserModel();
                    um.LoginUser(_login, _password);
                }));
            }
        }

        public DelegateCommand CloseApp
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Application.Current.Shutdown();
                });
            }
        }

        public DelegateCommand MinimizeWindow
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });
            }
        }

        #endregion
    }
}
