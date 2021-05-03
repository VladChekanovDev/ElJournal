using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElJournal.Dialogs
{
    class ConfirmDialogViewModel: BaseViewModel
    {
        private DelegateCommand _confirm;

        public DelegateCommand Confirm
        {
            get
            {
                return _confirm ??= new DelegateCommand((arg) =>
                {
                    var window = (Window)arg;
                    window.DialogResult = true;
                });
            }
        }
    }
}
