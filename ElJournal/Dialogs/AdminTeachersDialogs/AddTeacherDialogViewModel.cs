
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs.AdminTeachersDialogs
{
    class AddTeacherDialogViewModel: BaseViewModel
    {
        #region Поля

        private string _lastName;
        private string _firstName;
        private string _patronymic;
        private string _login;
        private string _password;
        private string _confirmPassword;
        private DelegateCommand _addTeacher;

        #endregion

        #region Свойства

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string Patrnoymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(IsAddActive));
            }
        }

        public bool IsAddActive => !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_firstName)
            && !string.IsNullOrWhiteSpace(_patronymic) && !string.IsNullOrWhiteSpace(_login)
            && !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_confirmPassword);

        #endregion

        #region Команды

        public DelegateCommand AddTeacher
        {
            get
            {
                return _addTeacher ??= new DelegateCommand((arg) =>
                {
                    if (Validation.LoginValidate(_login))
                    {
                        if (Validation.PasswordValidate(_password))
                        {
                            if (Validation.IncorrectInputValidate(_password, _confirmPassword))
                            {
                                var usermodel = new UserModel();
                                if (usermodel.IsUserExist(_login))
                                {
                                    var err = new ErrorDialog(Validation.UserExistsError);
                                    err.ShowDialog();
                                }
                                else
                                {
                                    var window = (Window)arg;
                                    window.DialogResult = true;
                                }
                            }
                            else
                            {
                                var err = new ErrorDialog(Validation.PasswordsDoNotMatchError);
                                err.ShowDialog();
                            }
                        }
                        else
                        {
                            var err = new ErrorDialog(Validation.PasswordError);
                            err.ShowDialog();
                        }
                    }
                    else
                    {
                        var err = new ErrorDialog(Validation.LoginError);
                        err.ShowDialog();
                    }
                });
            }
        }

        #endregion
    }
}
