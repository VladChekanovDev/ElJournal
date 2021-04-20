using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.ViewModels
{
    class MainViewModel: BaseViewModel
    {
        #region Поля

        private DelegateCommand _closeApp;
        private DelegateCommand _minimizeWindow;

        #endregion

        #region Команды
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
                return _minimizeWindow ??= new DelegateCommand((obj) =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });
            }
        }
        #endregion
    }
}
