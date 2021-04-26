using ElJournal.Dialogs;
using ElJournal.Entities;
using ElJournal.Models;
using ElJournal.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElJournal.ViewModels.AdminControlViewModels
{
    class GroupsViewModel: BaseViewModel
    {
        #region Поля

        private List<Group> _groupsList;
        private DelegateCommand _addGroup;
        private DelegateCommand _deleteGroups;

        #endregion

        public GroupsViewModel()
        {
            var gm = new GroupModel();
            _groupsList = gm.GetList();
        }

        #region Команды

        public DelegateCommand AddGroup
        {
            get
            {
                return _addGroup ??= new DelegateCommand((obj) =>
                {
                    var addgroupdialog = new AddGroupDialog();
                    addgroupdialog.ShowDialog();
                });
            }
        }

        public DelegateCommand DeleteGroups
        {
            get
            {
                return _deleteGroups ??= new DelegateCommand((obj) =>
                {

                });
            }
        }

        #endregion
    }
}
